using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argentics._2D
{
    public class RotateColliderAfterDeath : MonoBehaviour
    {
        private CapsuleCollider _capsuleCollider;

        void Start()
        {
            _capsuleCollider = gameObject.GetComponent<CapsuleCollider>();

            PlatformerCharacter.EDeath += PlatformerCharacter_EDeath;
        }

        private void PlatformerCharacter_EDeath(object sender, System.EventArgs e)
        {
            //_capsuleCollider.center = new Vector3(0, 0.2f, 0);
            StartCoroutine(Colliderheight());
        }
        IEnumerator Colliderheight()
        {
            //_capsuleCollider.center -= new Vector3(0, 0.02f, 0);
            yield return new WaitForSeconds(1.4f);
            _capsuleCollider.direction = 3;
            //if (_capsuleCollider.center != new Vector3(0, 0.5f, 0))
            //    StartCoroutine(Colliderheight());
            //else
            //    StopCoroutine(Colliderheight());
        }

    }
}
