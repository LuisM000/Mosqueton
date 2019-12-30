using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mosqueton.Data.Interfaces;
using Mosqueton.Helpers;
using Mosqueton.Model;
using Mosqueton.Model.Components;
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

        public void Update(GameTime gameTime)
        {
            _game.Update(gameTime.ElapsedGameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, _game.CurrentLevel.GraphicComponent);

            foreach (var gameObject in _game.CurrentLevel.GameObjects)
            {
                Draw(spriteBatch, gameObject.GraphicComponent);
            }
        }

        private void Draw(SpriteBatch spriteBatch, GraphicComponent graphicsComponent)
        {
            var texture = _textureStore.GetOrCreate(spriteBatch.GraphicsDevice, graphicsComponent.SheetTexturePath);
            var currentFrame = graphicsComponent.CurrentFrame;
            spriteBatch.Draw(texture, Vector2.Zero, currentFrame.SourceRectangle.ToXnaRectangle(), Color.White);
        }
    }
}
