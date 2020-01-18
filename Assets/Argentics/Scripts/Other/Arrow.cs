using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [HideInInspector] public float speed;
    [HideInInspector] public Vector3 direction;

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        //transform.Translate(direction * Time.deltaTime * speed, Space.Self);
    }
    public IEnumerator DisableByTime()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
