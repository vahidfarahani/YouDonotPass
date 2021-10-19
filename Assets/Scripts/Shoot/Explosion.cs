using UnityEngine;

namespace Shoot
{
    public class Explosion : MonoBehaviour
    {
        public Animator animator;
        void Start()
        {
            Invoke("DestroyExplosion", animator.GetCurrentAnimatorStateInfo(0).length);
        }
        void DestroyExplosion()
        {
            Destroy(gameObject);
        }
    }
}
