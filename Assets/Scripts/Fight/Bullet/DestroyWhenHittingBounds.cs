using UnityEngine;

namespace Fight.Bullet
{
    public class DestroyWhenHittingBounds : MonoBehaviour
    {

        private Vector2 _bounds = new Vector2(Mathf.Infinity, Mathf.Infinity);
        private Vector2 _spriteSize = new Vector2(0, 0);

        private void Start()
        {
            // ReSharper disable once PossibleNullReferenceException
            _bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            _spriteSize = transform.GetComponent<SpriteRenderer>().size / 2;
        }

        // Update is called once per frame
        private void Update()
        {
            if (!IsPositionInBounds()) Destroy(gameObject);
        }

        private bool IsPositionInBounds()
        {
            var position = transform.position;
            float x = position.x, y = position.y;
            return x > -_bounds.x + _spriteSize.x && x < _bounds.x - _spriteSize.x && y > -_bounds.y + _spriteSize.y && y < _bounds.y - _spriteSize.y;
        }
    }
}