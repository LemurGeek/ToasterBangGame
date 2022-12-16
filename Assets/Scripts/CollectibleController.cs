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

    ToastManager toastManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        Destroy(gameObject, lifeTime);
        healthStatus = FindObjectOfType<HealthStatusController>();

        toastManager = ToastManager.GetInstancia() as ToastManager;
    }

    private void Update()
    {
        this.transform.Rotate(0f, 10f * Time.deltaTime, 0f, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("PLAYER");
            isExpired = false;
            Destroy(gameObject);

            if (this.collectibleType.ToString().Equals("POWERUP"))
            {
                Debug.Log("POWERUP");
                toastManager.SetToastType(ToastTypes.BIGTOAST);
                Debug.Log(toastManager.GetToastType());
            }

            if (this.collectibleType.ToString().Equals("HEALTH"))
            {
                healthStatus.Heal(10);
                Debug.Log("HEALTH");
            }
        }
    }

}
