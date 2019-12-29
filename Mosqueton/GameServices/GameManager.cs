using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mosqueton.Data.Interfaces;
using Mosqueton.Model;
using Mosqueton.MonoGame.Infrastructure;

namespace Mosqueton.GameServices
{
    public class GameManager: IGameManager
    {
        private readonly IRepository<Model.Game> _gameRepository;
        private readonly ITextureStore _textureStore;

        private Model.Game _game;


        public GameManager(IRepository<Model.Game> gameRepository, ITextureStore textureStore)
        {
            _gameRepository = gameRepository;
            _textureStore = textureStore;
        }

        public void Initialize()
        {
            _game = _gameRepository.GetById(1);
            _game.SetCurrentLevel(_game.StartLevel);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var texture = _textureStore.GetOrCreate(spriteBatch.GraphicsDevice, _game.CurrentLevel.GraphicComponent.SheetTexturePath);
            spriteBatch.Draw(texture, Vector2.Zero, Color.White);
        }
    }
}
