using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealthController : MonoBehaviour
{
    [SerializeField]
    float health =100.0F;

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("Toast")) 
        {
            float damage = UnityEngine.Random.Range(20,25);
            health -= damage;
            if (health <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
