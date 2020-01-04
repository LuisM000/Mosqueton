using System;
using Microsoft.Xna.Framework;

namespace Mosqueton.Helpers
{
    public static class VectorExtensions
    {
        public static System.Drawing.PointF ToPointF(this Vector2 vector2)
        {
            return new System.Drawing.PointF(vector2.X, vector2.Y);
        }
    }
}
