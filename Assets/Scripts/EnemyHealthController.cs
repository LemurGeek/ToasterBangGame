using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealthController : MonoBehaviour
{
    [SerializeField]
    float health = 100.0F;


    private void Start()
    {
        health =  UnityEngine.Random.Range(100, 175);
    }
    private void OnTriggerEnter(Collider other)//Got toasted
    {
      
        if (other.CompareTag("Toast")) 
        {
            float damage = UnityEngine.Random.Range(20,25);
            health -= damage;
            if (health <= 0) {
                Destroy(gameObject);
            }
            Destroy(other.gameObject);

        }
        if (other.CompareTag("BigToast")) 
        {
            float damage = UnityEngine.Random.Range(30, 40);
            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(other.gameObject);

        }
    }
}
