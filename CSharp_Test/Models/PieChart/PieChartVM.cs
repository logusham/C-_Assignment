using CSharp_Assignment.Models.PieChart;

namespace CSharp_Test.Models.PieChart
{
    public class PieChartVM
    {
        public PieChartVM()
        {
            labels = new List<string>();
            datasets = new List<PieChartChildVM>();
        }
        public List<string> labels { get; set; }
        public List<PieChartChildVM> datasets { get; set; }
    }
}
