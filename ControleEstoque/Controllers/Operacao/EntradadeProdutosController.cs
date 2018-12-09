using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Controllers
{
    public class EntradadeProdutosController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}