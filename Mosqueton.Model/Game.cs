using System;
using Mosqueton.Infrastructure;
using Mosqueton.Model.Descriptors;

namespace Mosqueton.Model
{
    public class Game: BaseEntity
    {
        public GameSettings Settings { get; set; }
        public Level StartLevel { get; set; }
    }
}
