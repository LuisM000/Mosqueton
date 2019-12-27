using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
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
            _graphics = new GraphicsDeviceManager(this)
            {
                SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight
            };
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            using (var stream = TitleContainer.OpenStream("GameContent/Background.jpg"))
            {
                _scenario = Texture2D.FromStream(_graphics.GraphicsDevice, stream);
            }
            base.LoadContent();
        }

        
        protected override void Update(GameTime gameTime)
        {
            _levelManager.Update(gameTime.ElapsedGameTime);

            TouchCollection touchCollection = TouchPanel.GetState();

            if (touchCollection.Count > 0)
            {
                var touch = touchCollection[0].Position;
                var matrix = Matrix.Invert(Matrix.CreateScale((float)_graphics.GraphicsDevice.Viewport.Width / 1920,
                           (float)_graphics.GraphicsDevice.Viewport.Height / 1080,
                           1f));
                
                var touchTransformed = Vector2.Transform(touch, matrix);
                System.Diagnostics.Debug.WriteLine(touchTransformed);

            }

            base.Update(gameTime);            
        }

        protected override void Draw(GameTime gameTime)
		{
            var matrix = Matrix.CreateScale((float)_graphics.GraphicsDevice.Viewport.Width / 1920,
                           (float)_graphics.GraphicsDevice.Viewport.Height / 1080,
                           1f);
            _spriteBatch.Begin(transformMatrix: matrix);
            _spriteBatch.Draw(_scenario, Vector2.Zero, Color.White);
            _spriteBatch.End();


            base.Draw(gameTime);

        }
    }
}