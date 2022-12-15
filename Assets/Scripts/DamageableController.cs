using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableController : MonoBehaviour
{
    [SerializeField]
    float deadAnimationDelay = 1.0F;
    HealthStatusController healthStatus;

     void Start()
    {
     healthStatus = FindObjectOfType<HealthStatusController>();
        healthStatus.onHealthChanged.AddListener(OnHealthChanged);
        healthStatus.onDie.AddListener(OnDie);

    }

    void OnHealthChanged(float health)
    {
    }

    void OnDie()
    {
        StartCoroutine(OnDieCoroutine());
    }

    IEnumerator OnDieCoroutine() { 
        yield return new WaitForSeconds(deadAnimationDelay);

    }
    public void TakeDamage(float damage) { 
        healthStatus.Damage(damage);
    }
}
