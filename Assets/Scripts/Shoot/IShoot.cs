using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Shoot
{
    public interface IShoot
    {
        bool IsReady();
        int GetDamage();
        float GetSpeed();
        float GetShotTime();
        void Reloaded();
        bool CanActive(int score);
    }
}
