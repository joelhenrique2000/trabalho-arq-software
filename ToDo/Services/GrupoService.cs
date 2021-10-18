using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Api.Models;

namespace ToDo.Services {
    public class GrupoService {

        public async Task<IEnumerable<Grupo>> Get() {

            using (var cliente = new HttpClient()) {
                cliente.BaseAddress = new Uri("https://localhost:44386/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await cliente.GetAsync("grupo");
                if (response.IsSuccessStatusCode) {
                    List<Grupo> grupo = await response.Content.ReadAsAsync<List<Grupo>>();

                    return grupo.AsEnumerable();
                }

                return null;
            }
        }

        public async Task<Grupo> GetById(Guid id) {

            using (var cliente = new HttpClient()) {
                cliente.BaseAddress = new Uri("https://localhost:44386/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await cliente.GetAsync($"grupo/{id}");
                if (response.IsSuccessStatusCode) {
                    Grupo grupo = await response.Content.ReadAsAsync<Grupo>();

                    return grupo;
                }

                return null;
            }
        }

        public async Task<Boolean> Create(Grupo grupo) {

            using (var cliente = new HttpClient()) {
                cliente.BaseAddress = new Uri("https://localhost:44386/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await cliente.PostAsync("grupo", grupo);
                if (response.IsSuccessStatusCode) {
                    return true;
                }

                return false;
            }
        }
        public async Task<Boolean> Delete(Guid codGrupo) {

            using (var cliente = new HttpClient()) {
                cliente.BaseAddress = new Uri("https://localhost:44386/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await cliente.DeleteAsync($"grupo/{codGrupo}");
                if (response.IsSuccessStatusCode) {
                    return true;
                }

                return false;
            }
        }
        public async Task<Boolean> Update(Grupo grupo) {

            using (var cliente = new HttpClient()) {
                cliente.BaseAddress = new Uri("https://localhost:44386/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await cliente.PutAsync("grupo", grupo);
                if (response.IsSuccessStatusCode) {
                    return true;
                }

                return false;
            }
        }
    }
}
