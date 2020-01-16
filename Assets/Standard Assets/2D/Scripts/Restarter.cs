using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        public static Restarter instance;
        private void Start()
        {
            instance = this;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                RestartLvel();
            }
        }
        public void RestartLvel()
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }
}

