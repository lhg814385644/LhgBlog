using System;
using System.Collections.Generic;
using System.Text;
using Blog.Core.interfaces;

namespace Blog.Core.Entities
{
    public abstract class Entity:IEntity
    {
        public int Id { get; set; }
    }
}
