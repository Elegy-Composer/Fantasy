using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapObject.Movement
{
    [Serializable]
    public class MovementData 
    {
        #region Move Variable

        [SerializeField]
        private Rigidbody2D _rb;
        public Rigidbody2D rb
        {
            get { return _rb; }
        }

        [SerializeField]
        private float _moveSpeed;
        public float moveSpeed
        {
            get { return _moveSpeed; }
        }

        public Vector2 movement;
        public bool isFacingRight;

        #endregion

        #region Animation Variable

        [SerializeField]
        private Animator _anim;
        public Animator anim
        {
            get { return _anim; }
        }

        #endregion
    }
}