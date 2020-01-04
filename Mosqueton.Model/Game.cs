using System;
using Mosqueton.Infrastructure;
using Mosqueton.Model.Descriptors;

namespace Mosqueton.Model
{
    public class Game: BaseEntity
    {
        public GameSettings Settings { get; set; }
        public Level StartLevel { get; set; }

        [NotMapped]
        public Level CurrentLevel { get; private set; }

        public void SetCurrentLevel(Level level)
        {
            CurrentLevel = level;
        }

        public void Update(TimeSpan gameTime)
        {
            CurrentLevel.Update(gameTime);
        }
    }
}
