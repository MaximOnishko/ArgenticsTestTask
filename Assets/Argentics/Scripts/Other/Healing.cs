using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argentics._2D
{
    public class Healing : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            IDying idying = other.GetComponent<IDying>();

            if (idying != null)
            {
                idying.Healing();
                Destroy(gameObject);
            }
        }
    }
}
