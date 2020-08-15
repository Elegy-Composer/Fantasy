using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapObject.Clock
{
    public class AutoTimer : MonoBehaviour
    {
        void FixedUpdate()
        {
            int adjustedTime = (int)(Time.fixedDeltaTime * 180);
            Clock.minute += adjustedTime;
            if (Clock.minute >= 60)
            {
                if (Clock.hour == 24)
                {
                    Clock.hour = 0;
                }
                Clock.minute = 0;
                Clock.hour += 1;
            }
        }
    }
}