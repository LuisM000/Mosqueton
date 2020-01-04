using System;
using System.Drawing;

namespace Mosqueton.Model.Helpers
{
    public static class PointExtensions
    {
        public static PointF Subtract(this PointF point1, PointF point2)
        {
            return new PointF(point1.X - point2.X, point1.Y - point2.Y);
        }
    }
}
