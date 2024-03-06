namespace MovieRateApp.DTO
{
    public class MovieDTO
    {
        public int ID { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }
        
    }
}
