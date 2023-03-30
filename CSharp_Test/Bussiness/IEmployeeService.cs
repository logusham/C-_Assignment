using CSharp_Test.Models.Dtos;
using CSharp_Test.Models.PieChart;

namespace CSharp_Test.Bussiness
{
    public interface IEmployeeService
    {
       public Task<List<EmployeDto>> GetEmployeeOrderBy();
        public Task<PieChartVM> GetPieChartData();
    }
}
