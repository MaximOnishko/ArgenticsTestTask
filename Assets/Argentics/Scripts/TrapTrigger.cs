using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argentics._2D
{
    public class TrapTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject FallingObject;
        [SerializeField] private Transform spawnPos;
        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            IDying idying = other.GetComponent<IDying>();
            if (idying != null)
            {
                Invoke("SpawnObj", 0);
                Invoke("SpawnObj", 0.2f);
                Invoke("SpawnObj", 0.4f);
                //StartCoroutine(SpawnObj(0.2f));
                //StartCoroutine(SpawnObj(0.4f));
                gameObject.SetActive(false);
            }
        }
        private void SpawnObj()
        {
            Instantiate(FallingObject, spawnPos.position + Vector3.right * Random.Range(-0.8f, 0.8f), Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180)));
        }
    }
}
