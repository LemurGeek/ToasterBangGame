using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField]
    Transform primaryToastSpawnPoint;

    [SerializeField]
    Transform secundaryToastSpawnPoint;

    [SerializeField]
    GameObject[] toastPrefab;

    [SerializeField]
    float toastSpeed = 10.0F;

    [SerializeField]
    float shootRate = 0.5F;

    [SerializeField]
    float nextShoot = 0.5F;

    ToastManager toastManager;

    void Start()
    {
        toastManager = ToastManager.GetInstancia() as ToastManager;
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1") && Time.time > nextShoot)
        {
            nextShoot = Time.time + shootRate;
            ShootToast();
        }
    }

    void ShootToast()
    {
        GameObject primaryToast;
        GameObject secundaryToast;

        switch (toastManager.GetToastType())
        {
            case ToastTypes.NORMAL:
                primaryToast = Instantiate(toastPrefab[0], primaryToastSpawnPoint.position, primaryToastSpawnPoint.rotation);
                secundaryToast = Instantiate(toastPrefab[0], secundaryToastSpawnPoint.position, secundaryToastSpawnPoint.rotation);
                break;
            case ToastTypes.BIGTOAST:
                primaryToast = Instantiate(toastPrefab[1], primaryToastSpawnPoint.position, primaryToastSpawnPoint.rotation);
                secundaryToast = Instantiate(toastPrefab[1], secundaryToastSpawnPoint.position, secundaryToastSpawnPoint.rotation);
                break;
            default:
                primaryToast = Instantiate(toastPrefab[0], primaryToastSpawnPoint.position, primaryToastSpawnPoint.rotation);
                secundaryToast = Instantiate(toastPrefab[0], secundaryToastSpawnPoint.position, secundaryToastSpawnPoint.rotation);
                break;
        }

        Rigidbody rbPT = primaryToast.GetComponent<Rigidbody>();
        Rigidbody rbST = secundaryToast.GetComponent<Rigidbody>();

        rbPT.AddForce(primaryToastSpawnPoint.forward * toastSpeed, ForceMode.Impulse);
        rbST.AddForce(secundaryToastSpawnPoint.forward * toastSpeed, ForceMode.Impulse);
    }
}
