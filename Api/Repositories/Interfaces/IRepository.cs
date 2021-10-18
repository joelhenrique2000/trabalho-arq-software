using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories.Interfaces {
    public interface IRepository<T> {
        public IEnumerable<T> GetAll();
        public T Criar(T item);
        public T GetById(Guid id);
        public void Remover(Guid id);
        public void Atualizar(T item);
    }
}
