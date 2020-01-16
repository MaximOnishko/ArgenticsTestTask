using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        for (int i = 0; i < MonoCached.allTicks.Count; i++)
        {
            MonoCached.allTicks[i].Tick();
        }
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < MonoCached.allFixedTicks.Count; i++)
        {
            MonoCached.allTicks[i].FixedTick();
        }
    }
    private void LateUpdate()
    {
        for (int i = 0; i < MonoCached.allLateTicks.Count; i++)
        {
            MonoCached.allTicks[i].LateTick();
        }
    }
}
