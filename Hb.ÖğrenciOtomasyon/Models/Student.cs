namespace Hb.ÖğrenciOtomasyon.Models
{

    public enum Gender
    {
        Kadın=1,
        Erkek=2
    }
    public enum ClassLevel
    {
        Sınıf9 =9, 
        Sınıf10 =10, 
        Sınıf11 =11, 
        Sınıf12 =12, 
    }
    public class Student
    {
        public Student()
        {
                Id=  new Random().Next(213,923131231);    
        }
        public int Id { get; set; }

        public string Name { get; set; }
        public string SurName { get; set; }
        public Gender Gender { get; set;}
        public ClassLevel ClassLevel { get; set;}

        public List<Examp> Examps { get; set; } = new();

    }

    public enum Ders
    {
        Türkçe=1,
        Matematik=2,

    }
    public enum SınavTür
    {
        BirinciSınav=1,
        İkinciSınav=2,


    }
    public class  Examp
    {
        public int Not { get; set; }

        public Ders Ders { get; set; }
        public SınavTür SınavTür { get; set; }


    }
}
