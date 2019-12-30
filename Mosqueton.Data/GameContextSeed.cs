using System;
using System.Collections.Generic;
using System.Drawing;
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
                StartLevel = new Level()
                {
                    Id = 1,
                    GraphicComponent = new GraphicComponent()
                    {
                        Id = 1,
                        SheetTexturePath = "GameContent/Background.jpg",
                        Frames = new List<Frame>() { new Frame() { Id = 1, SourceRectangle = new Rectangle(0, 0, 2500, 2160) } }
                    },
                    GameObjects = new List<GameObject>()
                    {
                        new GameObject()
                        {
                            Id = 1,
                            GraphicComponent = new GraphicComponent(){Id = 2, SheetTexturePath = "GameContent/Tree.png",
                            Frames = new List<Frame>(){ new Frame() { Id = 2, SourceRectangle=new Rectangle(0,0, 127,192) } } }
                        }
                    }
                },
            }); ;
            gameContext.SaveChanges();
        }
    }
}
