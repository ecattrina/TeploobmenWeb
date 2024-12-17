
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WebTeploobmenApp.Data;
using WebTeploobmenApp.Models;

namespace WebTeploobmenApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TeploobmenContext _context;

        public HomeController(ILogger<HomeController> logger, TeploobmenContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var variant = _context.DataInput.FirstOrDefault(x => x.Id == id && (x.UserId == GetUserId() || x.UserId == null));
            if(variant != null)
            {
                _context.DataInput.Remove(variant);
                _context.SaveChanges();

            }


            return RedirectToAction("Index");


        }
        public IActionResult Index()
        {
            var datainput = _context.DataInput.Where(u => u.UserId == null || u.UserId == GetUserId()).ToList();
            return View(datainput);
        }

        [HttpGet]
        public IActionResult Calculator(int id)
        {
            var variant = _context.DataInput.FirstOrDefault(x => x.Id == id);
            var viewModel = new HomeCalcViewModel();
            if (variant != null)
            {
                viewModel.Visotasloy = variant.Visotasloy;
                viewModel.Nachtempgas = variant.Nachtempgas;
                viewModel.Nachtempmaterial = variant.Nachtempmaterial;
                viewModel.Skorostgas = variant.Skorostgas;
                viewModel.Sredtemplogas = variant.Sredtemplogas;
                viewModel.Rashodmaterial = variant.Rashodmaterial;
                viewModel.Teploemmaterial = variant.Teploemmaterial;
                viewModel.Kofteplo = variant.Kofteplo;
                viewModel.Diametrapparata = variant.Diametrapparata;
            }
            return View(viewModel);
        }

       

        [HttpPost]
        public IActionResult Calculator(CalcModel model, string action)
        {
            // ���������� ����������
            var results = model.CalculateResults();

            // ���������� ViewModel
            var viewModel = new HomeCalcViewModel
            {
                Results = results,
                Visotasloy = model.Visotasloy,
                Nachtempgas = model.Nachtempgas,
                Nachtempmaterial = model.Nachtempmaterial,
                Skorostgas = model.Skorostgas,
                Sredtemplogas = model.Sredtemplogas,
                Rashodmaterial = model.Rashodmaterial,
                Teploemmaterial = model.Teploemmaterial,
                Kofteplo = model.Kofteplo,
                Diametrapparata = model.Diametrapparata
            };

            // �������� �������� (����� ������ ���� ������)
            if (action == "add")
            {
                
                // ��������� ������ � ���� ������
                _context.DataInput.Add(new InputData

                {
                    UserId = GetUserId(),
                    Visotasloy = model.Visotasloy,
                    Nachtempgas = model.Nachtempgas,
                    Nachtempmaterial = model.Nachtempmaterial,
                    Skorostgas = model.Skorostgas,
                    Sredtemplogas = model.Sredtemplogas,
                    Rashodmaterial = model.Rashodmaterial,
                    Teploemmaterial = model.Teploemmaterial,
                    Kofteplo = model.Kofteplo,
                    Diametrapparata = model.Diametrapparata
                });

                _context.SaveChanges(); // ��������� ������ ��� ������� "��������"
            }

            // ������� �� �� ViewModel ��� ����������� �������
            return View(viewModel);
        }


        private int? GetUserId()
        {
            var userIdstr = User.FindFirst("UserId")?.Value;
            int? userId = userIdstr == null ? null : int.Parse(userIdstr);
            return userId;

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
