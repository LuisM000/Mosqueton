using System;
namespace Mosqueton.Helpers
{
    public static class RectangleExtensions
    {
        public static Microsoft.Xna.Framework.Rectangle ToXnaRectangle(this System.Drawing.Rectangle rectangle)
        {
            return new Microsoft.Xna.Framework.Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }
    }
}
