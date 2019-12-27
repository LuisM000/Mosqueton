using System;
using Mosqueton.IServices;
using Mosqueton.Model;

namespace Mosqueton.Services
{
    public class LevelManager : ILevelManager
    {
        Level _currentLevel;

        public Level CurrentLevel => _currentLevel;

        public void Load(Level level)
        {
            _currentLevel = level;
        }

        public void Update(TimeSpan gameTime)
        {
           // _currentLevel.Update(gameTime);
        }
    }
}
