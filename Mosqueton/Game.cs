using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Mosqueton.Data;
using Mosqueton.IServices;

namespace Mosqueton
{
    public class Game : Microsoft.Xna.Framework.Game
	{
        private readonly ILevelManager _levelManager;
		private readonly GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;
        private Texture2D _scenario;

        public Game(ILevelManager levelManager)
        {
            _levelManager = levelManager;

            Content.RootDirectory = "GameContent";
            _graphics = new GraphicsDeviceManager(this);
            _graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
        }

        protected override void Initialize()
        {
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
           
            base.LoadContent();
        }

        
        protected override void Update(GameTime gameTime)
        {
            _levelManager.Update(gameTime.ElapsedGameTime);

            base.Update(gameTime);            
        }

        protected override void Draw(GameTime gameTime)
		{
            _spriteBatch.Begin();
            _spriteBatch.Draw(_scenario, Vector2.Zero, Color.White);
            _spriteBatch.End();


            base.Draw(gameTime);

        }
    }
}