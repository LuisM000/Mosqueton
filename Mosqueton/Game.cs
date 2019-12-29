using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using Mosqueton.GameServices;
using Mosqueton.MonoGame.Infrastructure;

namespace Mosqueton
{
    public class Game : Microsoft.Xna.Framework.Game
	{
        private const int Width = 1920;
        private const int Height = 1080;
         
        private readonly IGameManager _gameManager;
        private readonly ITextureStore _textureStore;

        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _scenario;
        private OrthographicCamera _camera;

        public Game(IGameManager gameManager)
        {
            _gameManager = gameManager; 
            _graphics = new GraphicsDeviceManager(this)
            {
                SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight
            };
        }

        protected override void Initialize()
        {
            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, Width, Height);
            _camera = new OrthographicCamera(viewportAdapter);
            _gameManager.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
           
            base.LoadContent();
        }

        
        protected override void Update(GameTime gameTime)
        {
            TouchCollection touchCollection = TouchPanel.GetState();

            if (touchCollection.Count > 0)
            {
                var touch = touchCollection[0].Position;
                _ = _camera.ScreenToWorld(touch);
            }

            base.Update(gameTime);            
        }

        protected override void Draw(GameTime gameTime)
		{
            var matrix = _camera.GetViewMatrix();
            
            _spriteBatch.Begin(transformMatrix: matrix);

            _gameManager.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
