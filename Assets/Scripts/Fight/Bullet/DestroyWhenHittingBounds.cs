using UnityEngine;

namespace Fight.Bullet
{
    public class DestroyWhenHittingBounds : MonoBehaviour
    {

        private Vector2 _downRight = new Vector2(Mathf.Infinity, Mathf.Infinity);
        private Vector2 _upLeft = new Vector2(0, 0);
        private Vector2 _spriteSize = new Vector2(0, 0);

        private void Start()
        {
            // ReSharper disable once PossibleNullReferenceException
            var zPosition = Camera.main.transform.position.z;
            _upLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, zPosition));
            _downRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, zPosition));
            _spriteSize = transform.GetComponent<SpriteRenderer>().size / 2;
        }
        
        private void Update()
        {
            if (!IsPositionInBounds()) Destroy(gameObject);
        }

        private bool IsPositionInBounds()
        {
            var position = transform.position;
            float x = position.x, y = position.y;
            return x > _upLeft.x + _spriteSize.x && x < _downRight.x - _spriteSize.x && y > _upLeft.y + _spriteSize.y && y < _downRight.y - _spriteSize.y;
        }
    }
}