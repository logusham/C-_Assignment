namespace CSharp_Assignment.Models.PieChart
{
    public class PieChartChildVM
    {
        public PieChartChildVM()
        {
            lable = new List<string>() { "#2ecc71", "#000000", "#95a5a6", "#9b59b6", "#008000", "#9BD0F5", "#36A2EB", "#D2B48C", "#FFB1C1", "#FF6384" };
            data = new List<Double>();
            borderWidth = 1;
        }
        public List<string> lable { get; set; }
        public List<Double> data { get; set; }
        public int borderWidth { get; set; }
    }
}
