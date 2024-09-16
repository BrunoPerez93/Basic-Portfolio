namespace Portfolio.Models
{
    public class CombinedViewModel
    {
        public HomeIndexViewModel? HomeModel { get; set; }
        public PersonViewModel? Person { get; set; }
        public EjemploGUIDViewModel GuidViewModel { get; internal set; }
        public EjemploGUIDViewModel GuidViewModel2 { get; internal set; }
    }
}
