using Microsoft.Xna.Framework.Graphics;

namespace Mosqueton.MonoGame.Infrastructure
{
    public interface ITextureStore
    {
		Texture2D GetOrCreate(GraphicsDevice graphicsDevice, string assetPath);		
    }
}
