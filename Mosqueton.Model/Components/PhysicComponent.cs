using System;
using System.Drawing;
using Mosqueton.Infrastructure;

namespace Mosqueton.Model.Components
{
    public class PhysicComponent : BaseEntity
    {
        public Point BasePosition { get; set; }

        public Point InitialPosition { get; set; }

        public Point CurrentPosition
        {
            get
            {
                return Point.Subtract(InitialPosition, new Size(BasePosition));
            }
        }

         

        public void Update(TimeSpan gameTime)
        {

        }
    }
}
