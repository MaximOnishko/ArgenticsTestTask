using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argentics._2D
{
    public class Damaging : MonoBehaviour
    {
        [HideInInspector]public int damage = 1;

        private void OnTriggerEnter(Collider other)
        {
            IDying idying = other.GetComponent<IDying>();
            if (idying != null)
            {
                idying.TakeDamage(damage);
            }
            gameObject.SetActive(false);
        }
    }
}
