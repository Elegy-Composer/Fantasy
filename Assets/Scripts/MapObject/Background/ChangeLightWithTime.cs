using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using MapObject.Clock;


namespace MapObject.Background
{
    public class ChangeLightWithTime : MonoBehaviour
    {
        #region LightTone
        private Vector4 day = new Vector4(196f / 255f, 220f / 255f, 229f / 255f, 255f / 255f);
        private Vector4 dawn = new Vector4(248f / 255f, 217f / 255f, 189f / 255f, 255f / 255f);
        private Vector4 night = new Vector4(42f / 255f, 42f / 255f, 53f / 255f, 255f / 255f);
        #endregion

        #region Change Variable
        Gradient gradient;
        GradientColorKey[] colorKey;
        GradientAlphaKey[] alphaKey;

        public Light2D globalLight;

        #endregion

        #region Setup

        void Start()
        {
            gradient = new Gradient();

            // Populate the color keys at the relative time 0 and 1 (0 and 100%)
            colorKey = new GradientColorKey[3];
            colorKey[0].color = day;
            colorKey[0].time = 0.166f;
            colorKey[1].color = dawn;
            colorKey[1].time = 0.5f;
            colorKey[2].color = night;
            colorKey[2].time = 0.833f;

            // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
            alphaKey = new GradientAlphaKey[2];
            alphaKey[0].alpha = 0.5f;
            alphaKey[0].time = 0.0f;
            alphaKey[1].alpha =0.5f;
            alphaKey[1].time = 1.0f;

            gradient.SetKeys(colorKey, alphaKey);
        }

        #endregion

        #region ChangeColor Method
        void Update()
        {
            int adjustedTime = Clock.Clock.hour - 5;
            if (adjustedTime < 0)
            {
                adjustedTime += 24;
            }
            float ratio = (adjustedTime * 3600f + Clock.Clock.minute * 60f) / 86400f;
            Color32 light_c=gradient.Evaluate(ratio);
            globalLight.color = light_c;
            Debug.Log(ratio);
        }
        #endregion
    }
}

