namespace GameCatalog.Models;

public class Game
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Publisher { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string ImageIconUrl { get; set; }
    public double CriticScore { get; set; }
    public double PersonalScore { get; set; }
    public string PersonalNotes { get; set; }
    
}