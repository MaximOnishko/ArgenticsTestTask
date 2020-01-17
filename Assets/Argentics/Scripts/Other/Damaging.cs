using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argentics._2D
{
    public class Damaging : MonoBehaviour
    {
        [HideInInspector] public int damage = 1;
        [SerializeField] private bool isStatic;
        private void OnTriggerEnter(Collider other)
        {
            IDying idying = other.GetComponent<IDying>();
            if (idying != null)
            {
                idying.TakeDamage(damage);
            }
            if (isStatic)
                return;

            gameObject.SetActive(false);
        }
        private void OnCollisionEnter(Collision collision)
        {
            IDying idying = collision.transform.gameObject.GetComponent<IDying>();
            if (idying != null)
            {
                if (GetComponent<Rigidbody>().velocity.y < -2)
                {
                    idying.TakeDamage(damage);

                }

            }
        }
    }
}
