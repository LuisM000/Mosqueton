using System;
using System.Collections.Generic;
using System.Linq;
using Mosqueton.Infrastructure;

namespace Mosqueton.Model.Components
{
    public class GraphicComponent : BaseEntity
    {
        public string SheetTexturePath { get; set; }
        public IList<Frame> Frames { get; set; }

        public Frame CurrentFrame
        {
            get
            {
                return Frames.First();
            }
        }

        public void Update(TimeSpan gameTime)
        {

        }
    }
}
