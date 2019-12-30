using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mosqueton.MonoGame.Infrastructure
{
    public class TextureStore : ITextureStore
    {
        private readonly Dictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();
        
        public Texture2D GetOrCreate(GraphicsDevice graphicsDevice, string assetPath)
        {
            Texture2D texture;
            if(!_textures.TryGetValue(assetPath, out texture))
            {
                using (var stream = TitleContainer.OpenStream(assetPath))
                {
                    texture = Texture2D.FromStream(graphicsDevice, stream);
                }
                _textures.Add(assetPath, texture);
            }
            return texture;
        }
    }
}
