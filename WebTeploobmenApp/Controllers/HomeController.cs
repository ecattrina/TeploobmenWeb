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
			otnoshteploem = teploempotmaterial / teploempotgas;
			polnayaontositvisota = (model.Visotasloy * model.Kofteplo) / (model.Skorostgas * model.Sredtemplogas * 1000);

			 double Y(double Ycoordinate, double Visotasloy, double Skorostgas, double Sredtemplogas)
			{
				double result = (Visotasloy * Ycoordinate) / (Skorostgas * Sredtemplogas * 1000);
				return(result);
				
			}
			double y = Y(model.Ycoordinate, model.Visotasloy, model.Skorostgas, model.Sredtemplogas);
			
				
			double Exp1(double otnoshteploem, double y)
				{
				double result = 1 - Math.Exp(((otnoshteploem-1) * y) / otnoshteploem);
				
				return(result); }

			double exp1 = Exp1(otnoshteploem, y);

			double Mexp1(double otnoshteploem, double Y)
            {
                double result = (1 - otnoshteploem*Math.Exp((otnoshteploem-1) * Y) / otnoshteploem);

                return (result);
            }
            double mexp1 = Mexp1(otnoshteploem, y);
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
