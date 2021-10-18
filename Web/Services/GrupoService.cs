using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web.Services {
    public class GrupoService {

        private static readonly HttpClient Client = new HttpClient();

        public async Task<object> Get() {
            return await Client.GetAsync("https://localhost:44386/atividade");
        }
    }
}
