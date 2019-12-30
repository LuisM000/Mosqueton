using System;
using Mosqueton.Data.Interfaces;
using Mosqueton.Infrastructure;
using Mosqueton.Model.Components;

namespace Mosqueton.Model
{
    public class GameObject : BaseEntity
    {
        public GraphicComponent GraphicComponent { get; set; }
        public PhysicComponent PhysicComponent { get; set; }

        public void Update(TimeSpan gameTime)
        {
            GraphicComponent.Update(gameTime);
            PhysicComponent.Update(gameTime);
        }
    }
}
