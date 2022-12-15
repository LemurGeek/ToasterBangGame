using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    [SerializeField]

    CollectibleTypes collectibleType;

    [SerializeField]
    float collectibleValue = 2.0F;

    [SerializeField]
    float lifeTime = 10.0F;

    [SerializeField]
    float expireValue = -1.0F;

    bool isExpired = true;

    GameObject player;

    HealthStatusController healthStatus;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        Destroy(gameObject, lifeTime);
        healthStatus = FindObjectOfType<HealthStatusController>();



    }

    private void Update()
    {
        this.transform.Rotate(0f, 10f * Time.deltaTime, 0f, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Console.WriteLine("PLAYER");
            isExpired = false;
            Destroy(gameObject);

            //if (this.collectibleType.ToString().Equals("POISON"))
            //{
            //    session.AddScore(expireValue);
            //}

            //Me gustaria cambiar el nombre a food o apple
            if (this.collectibleType.ToString().Equals("HEALTH"))

            {
                Console.WriteLine("HEALTH");
            }
        }
    }

}
