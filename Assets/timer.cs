using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapObject.Clock;

public class timer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        int adjustTime = (int)(Time.deltaTime * 100);
        Clock.minute += adjustTime;
        if (Clock.minute >= 60)
        {
            Clock.minute = 0;
            if (Clock.hour == 24)
            {
                Clock.hour = -1;
            }
            Clock.hour += 1;
        }


        Debug.Log(Clock.hour);
        Debug.Log(Clock.minute);
    }
}
