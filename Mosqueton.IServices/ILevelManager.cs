using System;
using Mosqueton.Model;

namespace Mosqueton.IServices
{
    public interface ILevelManager
    {
        Level CurrentLevel { get;}

        void Load(Level level);
        void Update(TimeSpan gameTime);
    }
}
