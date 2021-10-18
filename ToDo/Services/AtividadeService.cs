using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Api.Models;

namespace ToDo.Services {
    public class AtividadeService {

        public async Task<IEnumerable<Atividade>> Get() {

            using (var cliente = new HttpClient()) {
                cliente.BaseAddress = new Uri("https://localhost:44386/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await cliente.GetAsync("atividade");
                if (response.IsSuccessStatusCode) {
                    List<Atividade> atividade = await response.Content.ReadAsAsync<List<Atividade>>();

                    return atividade.AsEnumerable();
                }

                return null;
            }
        }

        public async Task<Atividade> GetById(Guid id) {

            using (var cliente = new HttpClient()) {
                cliente.BaseAddress = new Uri("https://localhost:44386/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await cliente.GetAsync($"atividade/{id}");
                if (response.IsSuccessStatusCode) {
                    Atividade atividade = await response.Content.ReadAsAsync<Atividade>();

                    return atividade;
                }

                return null;
            }
        }

        public async Task<Boolean> Create(Atividade atividade) {

            using (var cliente = new HttpClient()) {
                cliente.BaseAddress = new Uri("https://localhost:44386/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await cliente.PostAsync("atividade", atividade);
                if (response.IsSuccessStatusCode) {
                    return true;
                }

                return false;
            }
        }
        public async Task<Boolean> Delete(Guid codAtividade) {

            using (var cliente = new HttpClient()) {
                cliente.BaseAddress = new Uri("https://localhost:44386/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await cliente.DeleteAsync($"atividade/{codAtividade}");
                if (response.IsSuccessStatusCode) {
                    return true;
                }

                return false;
            }
        }
        public async Task<Boolean> Update(Atividade atividade) {

            using (var cliente = new HttpClient()) {
                cliente.BaseAddress = new Uri("https://localhost:44386/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await cliente.PutAsync("atividade", atividade);
                if (response.IsSuccessStatusCode) {
                    return true;
                }

                return false;
            }
        }
    }
}
