using Shoot;
using System;
using System.Diagnostics;
namespace Shoot
{
    [Serializable]
    public class WeaponShoot : IShoot
    {
        private readonly int MinimumScore;
        private readonly float ShootTime;
        private readonly float ReloadTime;
        private readonly int Damage;
        private readonly float ShootSpeed;
        private Stopwatch LastShootWatch;

        public WeaponShoot(float reloadTime, float shootTime, int minimumScore, float shootSpeed, int damage)
        {
            LastShootWatch = new Stopwatch();
            LastShootWatch.Start();
            ShootTime = shootTime;
            ReloadTime = reloadTime;
            MinimumScore = minimumScore;
            ShootSpeed = shootSpeed;
            Damage = damage;
        }
        public int GetDamage()
        {
            return Damage;
        }

        public float GetShotTime()
        {
            return ShootTime;
        }

        public float GetSpeed()
        {
            return ShootSpeed;
        }

        public bool IsReady()
        {
            return LastShootWatch.Elapsed.TotalMilliseconds > ReloadTime * 1000;
        }

        public void Reloaded()
        {
            LastShootWatch.Restart();
        }
        public bool CanActive(int score)
        {
            return score >= MinimumScore;
        }
    }
}