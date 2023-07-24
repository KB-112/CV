using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventsControllers : MonoBehaviour
{
    public static event Action FanRot;
   

    void Update()
    {
        if (FanRot != null)
        {
            FanRot();
        }
    }

   
}
