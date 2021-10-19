using Layout;
using Shoot;
namespace Weapon
{
    public interface IWeapon
    {
        ILayout GetLayout();
        IShoot GetShoot();
    }
}
