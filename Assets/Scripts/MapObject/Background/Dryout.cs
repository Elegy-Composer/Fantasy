using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapObject.Background
{
    public class Dryout : MonoBehaviour
    {
        public SpriteRenderer spRenderer;
        public float rate;


        private void Update()
        {
            if (spRenderer.color.a <= 0.01f)
            {
                Destroy(gameObject);
            }
            Vector4 color = spRenderer.color;
            color.w -= rate * Time.deltaTime;
            spRenderer.color = color;
        }
    }
}