using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mosqueton.GameServices
{
    public interface IGameManager
    {
        void Initialize();
        void Update(GameTime gameTime, Vector2? tapPosition);
        void Draw(SpriteBatch spriteBatch);
    }
}
