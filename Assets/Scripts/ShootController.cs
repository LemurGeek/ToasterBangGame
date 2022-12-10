using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField]
    Transform toastSpawnPoint;

    [SerializeField]
    GameObject toastPrefab;

    [SerializeField]
    float toastSpeed = 10.0F;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootToast();
        }
    }

    void ShootToast()
    {
        GameObject toast = Instantiate(toastPrefab, toastSpawnPoint.position, toastSpawnPoint.rotation);
        Rigidbody rb = toast.GetComponent<Rigidbody>();

        rb.AddForce(toastSpawnPoint.forward * toastSpeed, ForceMode.Impulse);
    }
}
