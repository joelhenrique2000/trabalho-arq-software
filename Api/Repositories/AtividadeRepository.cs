using Api.Models;
using Api.Repositories.Interfaces;
using RepositoryHelpers.DataBase;
using RepositoryHelpers.DataBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories {
    public class AtividadeRepository : IRepository<Atividade> {

        private readonly CustomRepository<Atividade> Repository;

        public AtividadeRepository() {
            var connection = new Connection() {
                Database = RepositoryHelpers.Utils.DataBaseType.PostgreSQL,
                ConnectionString = "Host=localhost; Database=ifpe; Username=postgres; Password=1234;"
            };

            Repository = new CustomRepository<Atividade>(connection);
        }
        public IEnumerable<Atividade> GetAll() {
            var query = "SELECT * FROM Atividade";

            return Repository.Get(query).ToList();
        }

        public Atividade GetById(Guid id) {
            return Repository.GetById(id);
        }

        public Atividade Criar(Atividade atividade) {
            Repository.Insert(atividade, false);

            return atividade;
        }

        public void Remover(Guid id) {
            Repository.Delete(id);
        }

        public void Atualizar(Atividade atividade) {
            Repository.Update(atividade);
        }
    }
}
