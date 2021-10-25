using Shoot;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Weapon
{
    public class WeaponManager : MonoBehaviour
    {
        private Dictionary<WeaponType, PlayerWeapon> Weapons;
        public Sprite[] GunBody;
        private float speed = 600;
        public Transform Dummy;
        public Bullet Bullet;
        LayerMask mask;
        public WeaponType selectedWeapon;
        private float _startingPosition;


#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        private Touch touch;
        private Vector2 touchPosition;
        private Quaternion rotateZ;
        private float rotationSpeed = 0.5f;
#endif

        public void ChangeWeapon(WeaponType newWeapon)
        {
            selectedWeapon = newWeapon;
            GetComponent<Image>().sprite = Weapons[selectedWeapon].GetGunBody();
        }
        // Start is called before the first frame update
        void Start()
        {
            Weapons = new Dictionary<WeaponType, PlayerWeapon>()
            {
                {WeaponType.Single, new PlayerWeapon(new QueueWeaponFactory(1, 0, 0.5f, 0, 1, 12), GunBody[0]) },
                {WeaponType.Queue, new PlayerWeapon(new QueueWeaponFactory(4, 0.07f, 0.8f, 5, 1, 14),GunBody[1]) },
                {WeaponType.ShotGun, new PlayerWeapon(new ShotGunWeaponFactory(6, 10, 1, 0, 1, 20, 1, 16),GunBody[2]) },
            };
            mask = LayerMask.GetMask("Enemy");
        }
        void Update()
        {

#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                transform.Rotate(-Vector3.forward, speed * Input.GetAxis("Mouse X") * Time.deltaTime);
            }

#elif UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                rotateZ = Quaternion.Euler(0, 0, -touch.deltaPosition.x * rotationSpeed);
                transform.rotation = rotateZ * transform.rotation;
            }
        }
#endif
        }
        private void FixedUpdate()
        {
            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Dummy.position - transform.position, 500, mask);
            //Debug.DrawRay(transform.position, Dummy.position - transform.position, Color.green);
            if (hit2D.collider != null)
            {
                StartCoroutine(CreateBullet());
            }
        }
        public List<WeaponType> SetActive(int score)
        {
            List<WeaponType> activeWeapons = new List<WeaponType>();
            foreach (var weapon in Weapons)
            {
                if (weapon.Value.CanActive(score))
                    activeWeapons.Add(weapon.Key);
            }
            return activeWeapons;
        }
        IEnumerator CreateBullet()
        {
            if (Weapons[selectedWeapon].IsReady())
            {
                foreach (var positions in Weapons[selectedWeapon].Fire(transform.localRotation.eulerAngles.z))
                {
                    Bullet bullet = Instantiate(Bullet, Vector3.zero, transform.rotation, transform.parent);
                    bullet.transform.position = Dummy.position;
                    bullet.transform.localPosition += (Vector3)positions;
                    bullet.SetShootInfo(positions, Weapons[selectedWeapon].GetSpeed(), Weapons[selectedWeapon].GetDamage());
                    bullet.enabled = true;
                    float waitTime = Weapons[selectedWeapon].GetShootTime();
                    if (waitTime > 0)
                        yield return new WaitForSeconds(waitTime);
                }
            }
            yield return null;
        }
    }
}
