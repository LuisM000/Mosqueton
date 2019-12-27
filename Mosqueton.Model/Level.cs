using System;
using System.Collections.Generic;
using Mosqueton.Infrastructure;

namespace Mosqueton.Model
{
    public class Level : BaseEntity
    {
        public Graphic Graphic { get; set; }
        public IList<GameObject> GameObjects { get; set; }

        public void Update(TimeSpan gameTime)
        {
            Graphic.Update(gameTime);

            foreach (var gameObject in GameObjects)
            {
                gameObject.Update(gameTime);
            }
        }
    }
}
