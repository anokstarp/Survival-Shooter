using System;
using UnityEngine;

public class LivingObject : MonoBehaviour, IDamageable
{
    public float maxHealth = 100;
    public float health { get; private set; }
    public bool dead { get; private set; }
    public event Action onDeath;

    protected virtual void OnEnable()
    {
        dead = false;
        health = maxHealth;
    }

    public void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        health -= damage;
        if(health <= 0 && !dead)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        if (onDeath != null)
        {
            onDeath();
        }
       dead = true;
    }
}
