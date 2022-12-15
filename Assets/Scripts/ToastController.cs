using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastController : MonoBehaviour
{
    [SerializeField]
    float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {

        
    }
}
