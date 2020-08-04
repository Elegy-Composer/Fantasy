using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapObject.Enemy
{
    public abstract class EnemyMovement : MonoBehaviour
    {
        #region Move Variable
        [SerializeField]
        protected Rigidbody2D rb;
        [SerializeField]
        protected float moveSpeed;
        [SerializeField]
        protected Vector2 movement;
        [SerializeField]
        protected bool isFaceingRight;
        #endregion

        #region Animation Variable
        [SerializeField]
        protected Animator anim;
        #endregion
    }
}