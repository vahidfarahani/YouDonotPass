using Layout;
using UnityEngine;
namespace Layout
{
    public class LinearLayout : ILayout
    {
        private readonly int Count;
        public LinearLayout(int count)
        {
            Count = count;
        }
        public Vector2[] GetInitPos(float axis)
        {
            float rAxis = Mathf.Deg2Rad * axis;
            Vector2[] positions = new Vector2[Count];
            for (int i = 0; i < Count; i++)
            {
                positions[i] = new Vector2(-Mathf.Sin(rAxis), Mathf.Cos(rAxis));
            }
            return positions;
        }
    }
}
