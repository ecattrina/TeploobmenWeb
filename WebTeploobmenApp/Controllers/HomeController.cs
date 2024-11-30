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
            double ploshadechen = model.Ploshadechen();
            double teploemMaterial = model.TeploemMaterial();
            double teploemGas = model.TeploemGas();
            double otnoshTeploem = model.OtnoshTeploem();
            double polnayaOtnositVisota = model.PolnayaOtnositVisota();
			double exp1 = model.Exp1();
			double mexp1 = model.Mexp1();
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
