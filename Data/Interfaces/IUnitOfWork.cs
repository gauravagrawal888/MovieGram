using System;

namespace MovieGram.Data.Interfaces
{
     public interface IUnitOfWork: IDisposable
    {
        IMovieRepository Movies { get; set; }
        int Complete();
    }
}