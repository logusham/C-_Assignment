using CSharp_Test.Bussiness;
using CSharp_Test.Models.Dtos;
using CSharp_Test.Models.PieChart;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _service;
        public HomeController(IEmployeeService service)
        {

            _service = service;

        }

        public async Task<IActionResult> Index()
        {
            List<EmployeDto> employesDto = await _service.GetEmployeeOrderBy();
            return View(employesDto);
        }

        public async Task<IActionResult> PieChart()
        {
            var masterModel = new HomeIndexVM();
            var pieChartData = await _service.GetPieChartData();
            masterModel.PieChartData = pieChartData;
            return View(masterModel);
        }
      
    }
}