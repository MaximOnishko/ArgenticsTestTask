using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argentics._2D
{
    public class RotationInPlace : MonoBehaviour
    {
        private bool itCanvas;
        private RectTransform rectTransform;
        private Transform transf;
        [SerializeField] private float speed;
        // Start is called before the first frame update
        void Start()
        {
            itCanvas = getRectTransFrom();
        }

        // Update is called once per frame
        void Update()
        {
            if (itCanvas)
                rectTransform.Rotate(Vector3.up, speed);
            if (!itCanvas)
                transf.Rotate(Vector3.up, speed);
        }
        private bool getRectTransFrom()
        {
            rectTransform = GetComponent<RectTransform>();

            if (rectTransform != null)
                return true;
            else
            {
                transf = GetComponent<Transform>();
                return false;
            }
        }
    }
}
