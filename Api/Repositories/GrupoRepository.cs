using Api.Models;
using Api.Repositories.Interfaces;
using RepositoryHelpers.DataBase;
using RepositoryHelpers.DataBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories {
    public class GrupoRepository : IRepository<Grupo> {

        private readonly CustomRepository<Grupo> Repository;

        public GrupoRepository() {
            var connection = new Connection() {
                Database = RepositoryHelpers.Utils.DataBaseType.PostgreSQL,
                ConnectionString = "Host=localhost; Database=ifpe; Username=postgres; Password=1234;"
            };

            Repository = new CustomRepository<Grupo>(connection);
        }
        public IEnumerable<Grupo> GetAll() {
            var query = "SELECT * FROM Grupo";

            return Repository.Get(query).ToList();
        }

        public Grupo GetById(Guid id) {
            return Repository.GetById(id);
        }

        public Grupo Criar(Grupo grupo) {
            Repository.Insert(grupo, false);
            return grupo;
        }

        public void Remover(Guid id) {
            Repository.Delete(id);
        }

        public void Atualizar(Grupo grupo) {
            Repository.Update(grupo);
        }
    }
}
