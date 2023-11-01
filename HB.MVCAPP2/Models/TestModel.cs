namespace HB.MVCAPP2.Models
{

    public enum MultiData
    {
        data1=1,
        data2=2,
        data3=3,
        data4=4,
    }
    public class TestModel
    {
        public int Id { get; set; }
        public MultiData MultiData { get; set; }
        public string Name { get; set; }

    }
}
