using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MapObject.Background
{
    public class Rag : MonoBehaviour
    {
        [SerializeField]
        private Transform player;
        public Vector3 offset;
        [SerializeField]
        private Vector3 last_Pos;

        public Transform contactPoint;
        [SerializeField]
        private GameObject WetFloor;

        public float theshold;//don't create wetfloor when player is not moving.

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            transform.position = player.transform.position+offset;
            last_Pos = transform.position;
        }

        private void FixedUpdate()
        {
            transform.position = player.transform.position + offset;
            Vector3 current_Pos = transform.position;
            if ((current_Pos - last_Pos).magnitude >= theshold)
            {
                if (WetFloor != null)
                {
                    Instantiate(WetFloor, contactPoint.position, Quaternion.identity);
                }
            }
            last_Pos = current_Pos;
        }
    }
}