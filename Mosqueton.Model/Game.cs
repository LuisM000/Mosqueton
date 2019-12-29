using System;
using Mosqueton.Infrastructure;
using Mosqueton.Model.Descriptors;

namespace Mosqueton.Model
{
    public class Game: BaseEntity
    {

        public GameSettings Settings { get; set; }
        public Level StartLevel { get; set; }

        private Level _currentLevel;
        public Level CurrentLevel
        {
            get
            {
                return _currentLevel;
            }
        }

        public void SetCurrentLevel(Level level)
        {
            _currentLevel = level;
        }
    }
}
