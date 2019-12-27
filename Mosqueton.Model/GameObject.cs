using System;
using Mosqueton.Data.Interfaces;
using Mosqueton.Infrastructure;

namespace Mosqueton.Model
{
    public class GameObject : BaseEntity
    {
        public Graphic Graphic { get; set; }

        public void Update(TimeSpan gameTime)
        {
            Graphic.Update(gameTime);
        }
    }
}
