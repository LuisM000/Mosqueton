using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using Mosqueton.Data;
using Mosqueton.IServices;

namespace Mosqueton
{
    public class Game : Microsoft.Xna.Framework.Game
	{
        private const int Width = 1920;
        private const int Height = 1080;

        private readonly ILevelManager _levelManager;
		private readonly GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;
        private Texture2D _scenario;
        private OrthographicCamera _camera;

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
            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, Width, Height);
            _camera = new OrthographicCamera(viewportAdapter);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            using (var stream = TitleContainer.OpenStream("GameContent/FullBackgroud.png"))
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


                var touchTransformed = _camera.ScreenToWorld(touch);
                System.Diagnostics.Debug.WriteLine(touchTransformed);

            }

            base.Update(gameTime);            
        }

        protected override void Draw(GameTime gameTime)
		{
            var matrix = _camera.GetViewMatrix();
            
            _spriteBatch.Begin(transformMatrix: matrix);
            _spriteBatch.Draw(_scenario, Vector2.Zero, Color.White);
            _spriteBatch.End();


            base.Draw(gameTime);

        }
    }
}