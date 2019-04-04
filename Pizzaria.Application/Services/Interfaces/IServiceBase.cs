using System;
using System.Collections.Generic;

namespace Pizzaria.Application.Services.Interfaces
{
    public interface IServiceBase<TEntityViewModel> : IDisposable where TEntityViewModel : class
    {
        void Add(TEntityViewModel entityViewModel);
        void Update(TEntityViewModel entityViewModel);
        void Delete(int id);
        void Delete(TEntityViewModel entityViewModel);
        TEntityViewModel GetById(int id);
        IEnumerable<TEntityViewModel> GetAll();
    }
}