using System;
using System.Drawing;
using Mosqueton.Infrastructure;
using Mosqueton.Model.Helpers;

namespace Mosqueton.Model.Components
{
    public class MovementComponent : BaseEntity
    {
        private double _currentVelocityX;
        private double _currentVelocityY;

        public double Velocity { get; set; }
        public PointF? Destination { get; set; }

        
        public void Update(PhysicComponent physicComponent, TimeSpan gameTime)
        {
            if(!IsInPosition(physicComponent, gameTime))
            {
                var nextPosition = CalculateNextPosition(physicComponent, gameTime);
                physicComponent.CurrentPosition = new PointF(nextPosition.X, nextPosition.Y);
            }
            else
            {
                Destination = null;
            }
        }

        public void MoveTo(PointF position, PhysicComponent physicComponent)
        {
            Destination = position;
            CalculateVelocity(position, physicComponent);
        }

        private void CalculateVelocity(PointF position, PhysicComponent physicComponent)
        {
            var distance = physicComponent.GetDistanceToCurrentPosition(position);
            _currentVelocityX = Math.Sign(distance.X) * Velocity;
            _currentVelocityY = Math.Sign(distance.Y) * Velocity;

            if (Math.Abs(distance.X) > Math.Abs(distance.Y))
            {
                _currentVelocityY *= Math.Abs(distance.Y / distance.X);
            }
            else
            {
                _currentVelocityX *= Math.Abs(distance.X / distance.Y);
            }
        }

        private PointF CalculateNextPosition(PhysicComponent physicComponent, TimeSpan time)
        {
            var x = physicComponent.CurrentPosition.X + (_currentVelocityX * time.TotalSeconds);
            var y = physicComponent.CurrentPosition.Y + (_currentVelocityY * time.TotalSeconds);
            return new PointF((float)x, (float)y);
        }

        private bool IsInPosition(PhysicComponent physicComponent, TimeSpan time)
        {
            if (Destination == null)
                return true;
           
            var nextPosition = CalculateNextPosition(physicComponent, time);

            var currentDistanceToDestination = physicComponent.GetDistanceToCurrentPosition(Destination.Value);
            var nextDistanceToDestination = nextPosition.Subtract(physicComponent.CurrentPosition);

            return Math.Abs(nextDistanceToDestination.X) >= Math.Abs(currentDistanceToDestination.X) && Math.Abs(nextDistanceToDestination.Y) >= Math.Abs(currentDistanceToDestination.Y);
        }
    }
}
