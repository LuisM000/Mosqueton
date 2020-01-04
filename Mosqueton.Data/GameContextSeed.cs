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
                Settings = new GameSettings() { Width = 1920, Height = 1080 },
                StartLevel = new Level()
                {
                    GraphicComponent = new GraphicComponent()
                    {
                        SheetTexturePath = "GameContent/Background.jpg",
                        FrameComponent = new FrameComponent()
                        {
                            Frames = new List<Frame>() { new Frame() { SourceRectangle = new Rectangle(0, 0, 2500, 2160) } }
                        }
                    },
                    GameObjects = new List<GameObject>()
                    {
                        new GameObject()
                        {
                            GraphicComponent = new GraphicComponent(){ SheetTexturePath = "GameContent/Tree.png",
                            FrameComponent = new FrameComponent()
                            {
                                Frames = new List<Frame>(){ new Frame() { SourceRectangle=new Rectangle(0,0, 127,192) } } }
                            },
                            PhysicComponent = new PhysicComponent()
                            {
                                InitialPosition = new Point(300,300),
                                BasePosition = new Point(63,192)
                            }
                        },
                        new GameObject()
                        {
                            Id = 200,
                            GraphicComponent = new GraphicComponent()
                            {
                                SheetTexturePath = "GameContent/Character.png",
                                FrameComponent = new FrameComponent()
                                {
                                    Frames = new List<Frame>()
                                    {
                                        new Frame() { SourceRectangle= new Rectangle(0,0, 64,64), Duration = TimeSpan.FromSeconds (.25) },
                                        new Frame() { SourceRectangle= new Rectangle(64, 0, 64, 64), Duration = TimeSpan.FromSeconds (.25) },
                                        new Frame() { SourceRectangle= new Rectangle(0, 0, 64, 64), Duration = TimeSpan.FromSeconds (.25) },
                                        new Frame() { SourceRectangle= new Rectangle(128, 0, 64, 64), Duration = TimeSpan.FromSeconds (.25) },
                                    }
                                }
                            },
                            PhysicComponent = new PhysicComponent()
                            {
                                InitialPosition = new Point(450,900),
                                BasePosition = new Point(32,64),
                                MovementComponent = new MovementComponent(){ Velocity = 300}
                            }
                        }
                    }
                },
            });
            gameContext.SaveChanges();
        }
    }
}
