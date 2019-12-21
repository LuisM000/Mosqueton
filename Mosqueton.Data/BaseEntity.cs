using System;
using Mosqueton.Data.Interfaces;

namespace Mosqueton.Data
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }
}
