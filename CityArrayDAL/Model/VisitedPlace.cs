namespace CityArrayDAL.Model
{
    public class VisitedPlace
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public virtual Review Review { get; set; }
    }
}
