using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapObject.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        #region Move Variable
        protected Rigidbody2D rb;
        [SerializeField]
        protected float moveSpeed;
        protected Vector2 movement;

        protected bool isFaceingRight;
        #endregion

        #region Animation Variable
        protected Animator anim;
        #endregion
    }
}