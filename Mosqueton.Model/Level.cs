using System;
using System.Collections.Generic;
using Mosqueton.Infrastructure;
using Mosqueton.Model.Components;

namespace Mosqueton.Model
{
    public class Level : BaseEntity
    {
        public GraphicComponent GraphicComponent { get; set; }
        public IList<GameObject> GameObjects { get; set; }

        public void Update(TimeSpan gameTime)
        {
            GraphicComponent.Update(gameTime);

            foreach (var gameObject in GameObjects)
            {
                gameObject.Update(gameTime);
            }
        }
    }
}
