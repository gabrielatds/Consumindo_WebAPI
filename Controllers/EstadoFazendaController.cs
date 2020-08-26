using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Consumindo_WebAPI.Models;
using System.Net.Http;

namespace Consumindo_WebAPI.Controllers
{
    public class EstadoFazendaController : Controller
    {
        //GET: EstadoFazenda
        public IActionResult Index()
        {
            IEnumerable<EstadoFazenda> estadoFazenda = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tst.sportibrasil.com.br/Services/CategoriaOficialService.svc/ObterPorEstadoFazenda/2 ");
                var responseTask = client.GetAsync("estadoFazenda");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var read = result.Content.ReadAsAsync< IList < EstadoFazenda >>();
                    read.Wait();
                    estadoFazenda = read.Result;
                }
                else
                {
                    estadoFazenda = Enumerable.Empty<EstadoFazenda>();
                    ModelState.AddModelError(string.Empty, "Server error ocurred");
                }
            }

            return View(estadoFazenda);
        }
    }
}
