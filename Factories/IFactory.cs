using lost.Models;
using System.Collections.Generic;
namespace lost.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}