using System;
using System.Collections.Generic;
using System.Linq;
using Mosqueton.Infrastructure;

namespace Mosqueton.Model.Components
{
    public class GraphicComponent : BaseEntity
    {
        public string SheetTexturePath { get; set; }

        public FrameComponent FrameComponent { get; set; }

        public Frame CurrentFrame
        {
            get
            {
                return FrameComponent.CurrentFrame;
            }
        }

        public void Update(TimeSpan gameTime)
        {
            FrameComponent.Update(gameTime);
        }
    }
}
