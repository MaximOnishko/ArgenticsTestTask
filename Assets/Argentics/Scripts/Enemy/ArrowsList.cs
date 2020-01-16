using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Argentics._2D
{
    public class ArrowsList : Singleton<ArrowsList>
    {
        public List<GameObject> arrows;

        private void Start()
        {
            foreach (Transform item in transform)
            {
                item.gameObject.SetActive(false);
                arrows.Add(item.gameObject);
            }
        }
    }
}
