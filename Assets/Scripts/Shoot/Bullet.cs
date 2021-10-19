using UnityEngine;

namespace Shoot
{
    public class Bullet : MonoBehaviour
    {
        Vector3 Direction;
        float Speed;
        public int Damage;

        public void SetShootInfo(Vector3 direction, float speed, int damage)
        {
            Direction = direction;
            Speed = speed;
            Damage = damage;
        }

        void Update()
        {
            transform.localPosition += Speed * Direction;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "EndOfWorld")
            {
                Destroy(gameObject);
            }
        }
    }
}