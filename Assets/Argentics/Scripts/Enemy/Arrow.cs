using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argentics._2D
{
    public class Arrow :MonoCached
{
        [HideInInspector] public float speed;
        [HideInInspector] public Vector3 direction;

        public override void OnTick()
        {
            //transform.position += direction * Time.deltaTime * speed;
            transform.Translate(direction * speed * Time.deltaTime);
        }
        public IEnumerator DisableByTime()
        {
            yield return new WaitForSeconds(5);
            gameObject.SetActive(false);
        }
    }
}
