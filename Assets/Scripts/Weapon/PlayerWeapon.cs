using System;
using Layout;
using Shoot;
using UnityEngine;
namespace Weapon
{
    public class PlayerWeapon
    {
        private ILayout Layout;
        private IShoot Shoot;
        private Sprite GunBody;
        public PlayerWeapon(IWeapon weaponFactory, Sprite body)
        {
            Layout = weaponFactory.GetLayout();
            Shoot = weaponFactory.GetShoot();
            GunBody = body;
        }
        public Vector2[] Fire(float axis)
        {
            Shoot.Reloaded();
            return Layout.GetInitPos(axis);
        }
        public float GetSpeed()
        {
            return Shoot.GetSpeed();
        }
        public int GetDamage()
        {
            return Shoot.GetDamage();
        }
        public float GetShootTime()
        {
            return Shoot.GetShotTime();
        }
        public bool IsReady()
        {
            return Shoot.IsReady();
        }
        public bool CanActive(int score)
        {
            return Shoot.CanActive(score);
        }
        public Sprite GetGunBody()
        {
            return GunBody;
        }
    }
}