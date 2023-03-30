using CSharp_Assignment.Models.PieChart;
using CSharp_Test.Data;
using CSharp_Test.Models;
using CSharp_Test.Models.Dtos;
using CSharp_Test.Models.PieChart;

namespace CSharp_Test.Bussiness
{
    public class EmployeeService:IEmployeeService
    {
        private readonly EmployeeStore _store;

        public EmployeeService()
        {
            _store = new EmployeeStore();
        }

        public async Task<List<EmployeDto>> GetEmployeeOrderBy()
        {
            List<Employee> employees = await _store.GetEmployees();
            var employeTotalHour = employees.Select(x => new { Name = x.EmployeeName, Total = (int)((x.EndTimeUtc).Subtract(x.StarTimeUtc)).TotalHours });
            var employeOrderby = employeTotalHour.GroupBy(x => x.Name).Select(g => new { EmployeName = g.Key, TotalTime = g.Sum(n => n.Total) }).OrderBy(a => a.TotalTime);
            List<EmployeDto> employeDtos = new List<EmployeDto>();
            foreach (var temp in employeOrderby)
            {
                if (temp.EmployeName != null)
                {
                    EmployeDto employeDto = new EmployeDto()
                    {
                        EmployeeName = temp.EmployeName,
                        TotalWorkingHour = temp.TotalTime
                    };
                    employeDtos.Add(employeDto);
                }
               
            }
            return employeDtos;
        }

        public async Task<PieChartVM> GetPieChartData()
        {
            var model = new PieChartVM();
            var labels = new List<string>();
            var data = new List<Double>();
            List<EmployeDto> employees = await GetEmployeeOrderBy();
            double totalHour = employees.Sum(x => x.TotalWorkingHour);
            foreach (var emp in employees)
            {
                
                double emp_WorkigTime = emp.TotalWorkingHour;
                double Employee_percentages = (emp_WorkigTime/ totalHour) * 100;
                data.Add(Math.Round(Employee_percentages,2));
                labels.Add(emp.EmployeeName+" ("+(Math.Round(Employee_percentages, 2)).ToString()+"%)");
            }
            var lable = new List<string>();
            var datasets = new List<PieChartChildVM>();
            var childModel = new PieChartChildVM();
            childModel.data = data;
            datasets.Add(childModel);
            model.labels = labels;
            model.datasets = datasets;
            return model;
        }
    }
}
