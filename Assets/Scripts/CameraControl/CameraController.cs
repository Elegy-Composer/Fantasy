using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace CameraControl
{
    public class CameraController : MonoBehaviour
    {
        public Camera cam1;
        public Camera cam2;

        public CinemachineVirtualCamera vcam;

        private void Update()
        {
            if (GameObject.FindGameObjectWithTag("Player").transform.position.x > -15f)
            {
                cam2.enabled = true;
                cam1.enabled = false;
            }
        }
        private void LateUpdate()
        {
            
        }
    }
}