using Layout;
using Shoot;
using System;

namespace Weapon
{
    [Serializable]
    public class QueueWeaponFactory : IWeapon
    {
        private readonly float ReloadTime;
        private readonly int Count;
        private readonly float ShootTime;
        private readonly int MinimumScore;
        private readonly int Damage;
        private readonly float ShootSpeed;

        /// <summary>
        /// Prepare a structure for Linear layout weapon
        /// </summary>
        /// <param name="count">The number of bullets that must be fired per shot</param>
        /// <param name="shootTime">Delay between bullets per shot</param>
        /// <param name="reloadTime">Delay between shots</param>
        /// <param name="minimumScore">Minimum score for weapon activation</param>
        /// <param name="damage">Damage rate per bulle</param>
        /// <param name="shootSpeed">The speed of each bullet</param>
        public QueueWeaponFactory(int count, float shootTime, float reloadTime, int minimumScore ,int damage, float shootSpeed)
        {
            Count = count;
            ShootTime = shootTime;
            ReloadTime = reloadTime;
            MinimumScore = minimumScore;
            ShootSpeed = shootSpeed;
            Damage = damage;
        }
        public ILayout GetLayout()
        {
            return new LinearLayout(Count);
        }

        public IShoot GetShoot()
        {
            return new WeaponShoot(ReloadTime, ShootTime, MinimumScore, ShootSpeed, Damage);
        }
    }
}
