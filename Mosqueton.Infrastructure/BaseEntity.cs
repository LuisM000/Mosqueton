using System;
using Mosqueton.Data.Interfaces;

namespace Mosqueton.Infrastructure
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }
}
