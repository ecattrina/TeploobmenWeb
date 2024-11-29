using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebTeploobmenApp.Models;

namespace WebTeploobmenApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}
		
        public IActionResult Calculator(CalcModel model) {
            double ploshadechen, teploempotmaterial, teploempotgas, otnoshteploem, polnayaontositvisota;

			ploshadechen = Math.PI * Math.Pow(model.Diametrapparata, 2) / 4;
			teploempotmaterial = model.Rashodmaterial * model.Teploemmaterial;
			teploempotgas = ploshadechen * model.Skorostgas * model.Sredtemplogas;
			otnoshteploem = teploempotgas / teploempotgas;
			polnayaontositvisota = (model.Visotasloy * model.Kofteplo) / (model.Skorostgas * model.Sredtemplogas * 1000);

			double Y = 

            var result = model.OperationType switch
			{



				1 => ploshadechen,



				_ => throw new Exception()
			};


			var viewModel = new HomeCalcViewModel()
			{
				Result = result,
				Diametrapparata = model.Diametrapparata,
				OperationType = model.OperationType
			};


			//ViewData["result"] = result;
			//ViewData["diametrapparata"] = model.Diametrapparata;
			
			return View(viewModel);
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
