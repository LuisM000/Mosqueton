using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Mosqueton.Data;

namespace Mosqueton
{
    public class Game : Microsoft.Xna.Framework.Game
	{
		private readonly GraphicsDeviceManager _graphics;

		public Game(GameContext context)
		{
			_graphics = new GraphicsDeviceManager(this);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			base.Draw(gameTime);
		}
	}
}