using System;
using Microsoft.Xna.Framework;

namespace Mosqueton.Helpers
{
    public static class PointExtensions
    {
        public static Vector2 ToVector2(this System.Drawing.Point point)
        {
            return new Vector2(point.X, point.Y);
        }
    }
}
