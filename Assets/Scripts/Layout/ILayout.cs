using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Layout
{
    public interface ILayout
    {
        Vector2[] GetInitPos(float axis);
    }
}
