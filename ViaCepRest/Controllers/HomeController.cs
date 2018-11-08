using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViaCepRest.Models;
using Canducci.Zip;

namespace ViaCepRest.Controllers
{
    public class HomeController : Controller
    {
        //public readonly ZipCodeLoad zip;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cep(string cep, ZipCodeLoad zip)
        {
            ZipCodeResult result = await zip.FindAsync(cep);
            ViewData["cep"] = cep;
            if (result.IsValid)
            {
                Cep cepDados = new Cep();
                cepDados.rua = result.Result.Address;
                cepDados.bairro = result.Result.District;
                cepDados.cidade = result.Result.City;
                cepDados.uf = result.Result.Uf;
                return View(cepDados);
            }
            
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
