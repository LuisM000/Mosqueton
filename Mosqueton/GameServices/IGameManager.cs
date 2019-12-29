using System;
using Microsoft.Xna.Framework.Graphics;

namespace Mosqueton.GameServices
{
    public interface IGameManager
    {
        void Initialize();
        void Draw(SpriteBatch spriteBatch);
    }
}
