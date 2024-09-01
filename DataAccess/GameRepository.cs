using Dapper;
using GameCatalog.Models;
using Microsoft.Data.SqlClient;

namespace GameCatalog.DataAccess;

public class GameRepository
{
    private string connectionString;

    public GameRepository()
    { 
        connectionString = "Server=localhost;Database=GameCatalogDb;User Id=SA;Password=Admin@123;TrustServerCertificate=True;";
    }

    public List<Game> GetAll()
    {
        using (var connection = new SqlConnection(connectionString))
        {
            string sql = "SELECT * FROM games";

            var gamesFromDb = connection.Query<Game>(sql).ToList();
            return gamesFromDb;
        }
        
    }
    
    public Game GetById(int id)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            string sql = "SELECT * FROM games WHERE id = " + id;

            var gameFromDb = (Game) connection.QuerySingleOrDefault<Game>(sql, new {ID = id});
            return gameFromDb;
        }
    }
    
    public int Create(Game obj)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            string sql = "INSERT INTO games (Title, Publisher, ReleaseDate, ImageIconUrl, CriticScore, PersonalScore, PersonalNotes) VALUES (@Title, @Publisher, @ReleaseDate, @ImageIconUrl, @CriticScore, @PersonalScore, @PersonalNotes); SELECT CAST(SCOPE_IDENTITY() as int)";

            var gameId = connection.Query<int>(sql, obj).Single();
            return gameId;
        }
    }

    public void UpdateGame(Game obj)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            string sql = "UPDATE games SET Title = @Title, Publisher = @Publisher, ReleaseDate = @ReleaseDate, ImageIconUrl = @ImageIconUrl, CriticScore = @CriticScore, PersonalScore = @PersonalScore, PersonalNotes = @PersonalNotes WHERE ID = @ID";

            connection.Execute(sql, obj);
        }
        
    }

    public void DeleteGame(int id)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            string sql = "DELETE FROM games WHERE ID = @ID";
            
            connection.Execute(sql, new {ID = id});
        }
        
    }
    
    
    
    
}