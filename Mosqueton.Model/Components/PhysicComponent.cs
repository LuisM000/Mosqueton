using System;
using System.Drawing;
using Mosqueton.Infrastructure;

namespace Mosqueton.Model.Components
{
    public class PhysicComponent : BaseEntity
    {
        private bool _hasBeenInitialized;

        public PointF BasePosition { get; set; }
        public PointF InitialPosition { get; set; }
        public MovementComponent MovementComponent { get; set; }

        public PointF CurrentPosition { get; set; }

 
        public void Update(TimeSpan gameTime)
        {
            EnsureInitialization();
            MovementComponent?.Update(this, gameTime);
        }

        public PointF GetDistanceToCurrentPosition(PointF position)
        {
            var transformedPosition = PointF.Subtract(position, new SizeF(BasePosition));
            return new PointF(transformedPosition.X - CurrentPosition.X, transformedPosition.Y - CurrentPosition.Y);
        }


        private void EnsureInitialization()
        {
            if(!_hasBeenInitialized)
            {
                _hasBeenInitialized = true;
                CurrentPosition = PointF.Subtract(InitialPosition, new SizeF(BasePosition));
            }
        }

    }
}
