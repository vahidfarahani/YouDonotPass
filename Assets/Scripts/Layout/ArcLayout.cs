using UnityEngine;
namespace Layout
{
    public class ArcLayout : ILayout
    {
        private readonly int Count;
        private readonly float Angle;
        private readonly float Radius;
        public ArcLayout(int count, float angle, float radius)
        {
            Count = count;
            Angle = angle;
            Radius = radius;
        }
        public Vector2[] GetInitPos(float axis)
        {
            Vector2[] positions = new Vector2[Count];
            float rAngle = Mathf.Deg2Rad * Angle;
            float rAxis = Mathf.Deg2Rad * axis;
            for (int i = 0; i < Count; i++)
            {
                float thetha = -rAngle + i * (2 * rAngle) / (Count - 1) - rAxis;
                positions[i] = Radius * new Vector2(Mathf.Sin(thetha), Mathf.Cos(thetha));
            }
            return positions;
        }
    }
}
