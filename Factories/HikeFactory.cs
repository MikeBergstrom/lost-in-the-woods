using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using lost.Models;
 
namespace lost.Factory
{
    public class HikeFactory : IFactory<Hike>
    {
        private string connectionString;
        public HikeFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=lost;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        public void Add(Hike hike){
            using(IDbConnection dbConnection = Connection){
                string query = "INSERT INTO hikes (name, description, length, elevation, longitude, latitude) VALUES (@name, @description, @length, @elevation, @longitude, @latitude)";
                dbConnection.Open();
                dbConnection.Execute(query, hike);
            } 
        }
        public List<Hike> GetHikes(){
            using(IDbConnection dbConnection = Connection){
                string query = "SELECT * FROM hikes";
                dbConnection.Open();
                return dbConnection.Query<Hike>(query).ToList();
            }
        }
        public Hike Show(int id){
            using(IDbConnection dbConnection = Connection){
                string query = $"SELECT * FROM hikes WHERE id={id}";
                dbConnection.Open();
                return dbConnection.Query<Hike>(query).FirstOrDefault();
            }
        }
        public List<Hike> Length(){
            using(IDbConnection dbConnection = Connection){
                string query = $"SELECT * FROM hikes ORDER BY length DESC";
                dbConnection.Open();
                return dbConnection.Query<Hike>(query).ToList();
            }
        }
        public List<Hike> Elevation(){
            using(IDbConnection dbConnection = Connection){
                string query = $"SELECT * FROM hikes ORDER BY elevation DESC";
                dbConnection.Open();
                return dbConnection.Query<Hike>(query).ToList();
            }
        }
    }
}