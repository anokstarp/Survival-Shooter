using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements.Experimental;

public class Enemy : LivingObject
{
    public LayerMask targetMask;

    private LivingObject target;
    private NavMeshAgent pathFinder;
    private Animator animator;
    private AudioSource audio;

    private bool hasTarget 
    { 
        get
        {
            return target != null && !target.dead;
        } 
    }

    private void Awake()
    {
        pathFinder = GetComponent<NavMeshAgent>();
        pathFinder.speed = 1.0f;
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }
    private void Start()
    {
        StartCoroutine(UpdatePath());
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("HasTarget", hasTarget);
    }

    private IEnumerator UpdatePath()
    {
        while(!dead)
        {
            Debug.Log(hasTarget);
            if (hasTarget)
            {
                pathFinder.isStopped = false;
                pathFinder.SetDestination(target.transform.position);
            }
            else
            {
                pathFinder.isStopped = true;

                Collider[] colliders = Physics.OverlapSphere(transform.position, 20f, targetMask);

                for(int i=0; i<colliders.Length; i++)
                {
                    var target = colliders[i].GetComponent<LivingObject>();
                    if(target != null && !target.dead) 
                    { 
                        this.target = target;
                        break;
                    }
                }
            }

            yield return new WaitForSeconds(0.25f);
        }
    }
}
