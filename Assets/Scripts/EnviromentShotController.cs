using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentShotController : MonoBehaviour
{
        private void OnTriggerEnter(Collider other)//Got toasted
        {

            if (other.CompareTag("Toast"))
            {
                Destroy(other.gameObject);
            }
            if (other.CompareTag("BigToast"))
            {
                Destroy(other.gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Toast"))
            {
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.CompareTag("BigToast"))
            {
                Destroy(collision.gameObject);
            }
        }
}
