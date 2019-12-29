using System;
using Mosqueton.Infrastructure;

namespace Mosqueton.Model.Descriptors
{
    public class GameSettings : BaseEntity
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
