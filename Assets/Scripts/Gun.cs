using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum State
    { 
        Ready,
    }

    public State state { get; private set; }

    public Transform fireTransform;
    public ParticleSystem fireFlashEffect;

    private LineRenderer bulletLineRenderer;
    private AudioSource gunAudio;

    public AudioClip fireClip;

    public int damage = 10;
    public float timeBetFire = 0.08f;
    private float lastFireTime;
    private float fireDistance = 20f;

    private void Awake()
    {
        gunAudio = GetComponent<AudioSource>();
        bulletLineRenderer = GetComponent<LineRenderer>();
        bulletLineRenderer.positionCount = 2;
        bulletLineRenderer.enabled = false;
    }

    public void Fire()
    {
        if (Time.time < lastFireTime + timeBetFire) return;

        lastFireTime = Time.time;

        var hitPosition = fireTransform.position + fireTransform.forward * fireDistance;
        var ray = new Ray(fireTransform.position, fireTransform.forward);

        if(Physics.Raycast(ray, out RaycastHit hit, fireDistance))
        {
            var target = hit.collider.GetComponent<IDamageable>();
            if(target != null)
            {
                target.OnDamage(damage, hit.point, hit.normal);
            }
            hitPosition = hit.point;
        }
        StartCoroutine(ShotEffect(hitPosition));
    }

    private IEnumerator ShotEffect(Vector3 hitPosition)
    {
        fireFlashEffect.Play();
        gunAudio.PlayOneShot(fireClip);

        bulletLineRenderer.SetPosition(0, fireTransform.position);
        bulletLineRenderer.SetPosition(1, hitPosition);

        bulletLineRenderer.enabled = true;

        yield return new WaitForSeconds(0.05f);

        bulletLineRenderer.enabled = false;
    }
}
