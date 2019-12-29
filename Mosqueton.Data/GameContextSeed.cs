using System;
using Mosqueton.Model;
using Mosqueton.Model.Components;
using Mosqueton.Model.Descriptors;

namespace Mosqueton.Data
{
    public static class GameContextSeed
    {
        public static void Seed(this GameContext gameContext)
        {
            gameContext.Add<Game>(
            new Game
            {
                Id = 1,
                Settings = new GameSettings() { Id = 1, Width = 1920, Height = 1080 },
                StartLevel = new Level() { Id = 1, GraphicComponent = new GraphicComponent() { Id = 1, SheetTexturePath = "GameContent/Background.jpg" } }
            });
            gameContext.SaveChanges();
        }
    }
}
