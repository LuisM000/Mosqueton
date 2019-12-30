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
                        FrameComponent = new FrameComponent()
                        {
                            Id = 1,
                            Frames = new List<Frame>() { new Frame() { Id = 1, SourceRectangle = new Rectangle(0, 0, 2500, 2160) } }
                        }
                    },
                    GameObjects = new List<GameObject>()
                    {
                        new GameObject()
                        {
                            Id = 1,
                            GraphicComponent = new GraphicComponent(){Id = 2, SheetTexturePath = "GameContent/Tree.png",
                            FrameComponent = new FrameComponent()
                            {
                                Id = 2,
                                Frames = new List<Frame>(){ new Frame() { Id = 2, SourceRectangle=new Rectangle(0,0, 127,192) } } }
                            },
                            PhysicComponent = new PhysicComponent()
                            {
                                Id = 1,
                                InitialPosition = new Point(300,300),
                                BasePosition = new Point(63,192)
                            }
                        },
                        new GameObject()
                        {
                            Id = 2,
                            GraphicComponent = new GraphicComponent()
                            {
                                Id = 3, SheetTexturePath = "GameContent/Character.png",
                                FrameComponent = new FrameComponent()
                                {
                                    Id = 3,
                                    Frames = new List<Frame>()
                                    {
                                        new Frame() { Id = 3, SourceRectangle= new Rectangle(0,0, 64,64), Duration = TimeSpan.FromSeconds (.25) },
                                        new Frame() { Id = 4, SourceRectangle= new Rectangle(64, 0, 64, 64), Duration = TimeSpan.FromSeconds (.25) },
                                        new Frame() { Id = 5, SourceRectangle= new Rectangle(0, 0, 64, 64), Duration = TimeSpan.FromSeconds (.25) },
                                        new Frame() { Id = 6, SourceRectangle= new Rectangle(128, 0, 64, 64), Duration = TimeSpan.FromSeconds (.25) },
                                    }
                                }
                            },
                            PhysicComponent = new PhysicComponent()
                            {
                                Id = 2,
                                InitialPosition = new Point(450,900),
                                BasePosition = new Point(32,64)
                            }
                        }
                    }
                },
            });
            gameContext.SaveChanges();
        }
    }
}
