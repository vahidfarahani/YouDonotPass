using System;
using Layout;
using Shoot;

namespace Weapon
{
    [Serializable]
    public class ShotGunWeaponFactory : IWeapon
    {
        private readonly float Angle;
        private readonly int Count;
        private readonly float Radius;
        private readonly float ShootTime;
        private readonly float ReloadTime;
        private readonly int MinimumScore;
        private readonly int Damage;
        private readonly float ShootSpeed;

        /// <summary>
        /// Prepare a structure for Arc layout weapon. We can place the bullets on an arc with a certain radius
        /// </summary>
        /// <param name="count">The number of bullets that must be fired per shot</param>
        /// <param name="angle">Arc size based on degree</param>
        /// <param name="radius">Radius of arc</param>
        /// <param name="shootTime">Delay between bullets per shot</param>
        /// <param name="reloadTime">Delay between shots</param>
        /// <param name="minimumScore">Minimum score for weapon activation</param>
        /// <param name="damage">Damage rate per bullet</param>
        /// <param name="shootSpeed">The speed of each bullet</param>
        public ShotGunWeaponFactory(int count, float angle, float radius, float shootTime, float reloadTime, int minimumScore, int damage, float shootSpeed)
        {
            Count = count;
            Angle = angle;
            Radius = radius;
            ShootTime = shootTime;
            ReloadTime = reloadTime;
            MinimumScore = minimumScore;
            ShootSpeed = shootSpeed;
            Damage = damage;
        }
        public ILayout GetLayout()
        {
            return new ArcLayout(Count, Angle, Radius);
        }

        public IShoot GetShoot()
        {
            return new WeaponShoot(ReloadTime, ShootTime, MinimumScore, ShootSpeed, Damage);
        }
    }
}
