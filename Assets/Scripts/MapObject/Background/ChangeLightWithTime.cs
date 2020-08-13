using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using MapObject.Clock;


namespace MapObject.Background
{
    public class ChangeLightWithTime : MonoBehaviour
    {
        public Light2D globalLight;

        #region LightTone
        public Color dayColor;
        public Color dawnColor;
        public Color nightColor;
        #endregion

        #region ChangeColor Method

        void Update()//9:00~17:00, 17:00~1:00, 1:00~9:00
        {
            int hour = Clock.Clock.hour;
            int minute = Clock.Clock.minute;
            float ratio;
            Vector4 lightColor;

            if (hour >= 9 && hour < 17)//daytime
            {
                Debug.Log("in daytime");
                int adjustedTime = hour - 9;
                ratio = (adjustedTime * 3600 + minute * 60) / 28800f;
                lightColor = Vector4.Lerp(dayColor, dawnColor, ratio);
            }

            else if (hour >= 17 || hour < 1)//dawn
            {
                Debug.Log("in dawn");
                int adjustedTime = hour - 17;
                ratio = (adjustedTime * 3600 + minute * 60) / 28800f;
                lightColor = Vector4.Lerp(dawnColor, nightColor, ratio);
            }

            else//nighttime
            {
                Debug.Log("in nighttime");
                int adjustedTime = hour - 1;
                ratio = (adjustedTime * 3600 + minute * 60) / 28800f;
                lightColor = Vector4.Lerp(nightColor, dayColor, ratio);
            }

            globalLight.color = lightColor;
        }
        #endregion
    }
}

