using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField]
    Transform toastSpawnPoint;

    [SerializeField]
    GameObject[] toastPrefab;

    [SerializeField]
    float toastSpeed = 10.0F;

    ToastManager toastManager;

    void Start()
    {
        toastManager = ToastManager.GetInstancia() as ToastManager;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootToast();
        }
    }

    void ShootToast()
    {
        GameObject toast;

        switch (toastManager.GetToastType())
        {
            case ToastTypes.NORMAL:
                toast = Instantiate(toastPrefab[0], toastSpawnPoint.position, toastSpawnPoint.rotation);
                break;
            case ToastTypes.BIGTOAST:
                toast = Instantiate(toastPrefab[1], toastSpawnPoint.position, toastSpawnPoint.rotation);
                break;
            default:
                toast = Instantiate(toastPrefab[0], toastSpawnPoint.position, toastSpawnPoint.rotation);
                break;
        }

        Rigidbody rb = toast.GetComponent<Rigidbody>();

        rb.AddForce(toastSpawnPoint.forward * toastSpeed, ForceMode.Impulse);
    }
}
