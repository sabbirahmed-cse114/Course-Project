﻿
namespace iTransition.Forms.Domain.Entities
{
    public interface IEntity<T> where T : IComparable
    {
        public T Id { get; set; }
    }
}
