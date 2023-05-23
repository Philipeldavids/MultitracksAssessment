using System.Data;
using System.Threading.Tasks;
using System;
using Multitracks.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using Multitracks.Interface;

namespace Multitracks.Repository
{
  
    public class ArtistRepository : IArtistRepository
    {
        private readonly IConfiguration _configuration;
        
        public ArtistRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Artist> GetArtistByName(string name)
        {
          
            var connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            Artist artist = new Artist();
            await using (SqlConnection sqlConnectionm = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Artist WHERE title LIKE  @name";
                sqlConnectionm.Open();
                SqlCommand command = new SqlCommand(sql, sqlConnectionm);
                command.Parameters.AddWithValue("@name", "%" + name + "%");
                //testConnectiontext.Text = "Connection Open Successfully";
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                sqlConnectionm.Close();


                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    DataRow dr = dt.Rows[i];

                    artist.ArtistID = int.Parse(dr["artistID"].ToString());
                    artist.Title = dr["title"].ToString();
                    artist.DateCreation = Convert.ToDateTime(dr["dateCreation"].ToString());
                    artist.Biography = dr["biography"].ToString();
                    artist.ImageUrl = dr["imageURL"].ToString();
                    artist.HeroUrl = dr["heroURL"].ToString();

                }

            }
            return artist;
        }

        
        public async Task<bool> AddArtist(Artist artist)
        {
            var connectionString = _configuration["ConnectionStrings:DefaultConnection"];

           
            using (SqlConnection sqlConnectionm = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Artist (dateCreation, title, biography,imageURL,heroURL) VALUES ('" + artist.DateCreation + "','" + artist.Title + "','" + artist.Biography + "','" + artist.ImageUrl + "','" + artist.HeroUrl + "')";
                sqlConnectionm.Open();

                SqlCommand cmd = new SqlCommand(sql, sqlConnectionm);

                //cmd.Parameters.Add("artistID", SqlDbType.Int).Value = lastno;
                cmd.Parameters.Add("dateCreation", SqlDbType.SmallDateTime).Value = artist.DateCreation;
                cmd.Parameters.Add("title", SqlDbType.NVarChar).Value = artist.Title;
                cmd.Parameters.Add("biography", SqlDbType.NVarChar).Value = artist.Biography;
                cmd.Parameters.Add("imageURL", SqlDbType.NVarChar).Value = artist.ImageUrl;
                cmd.Parameters.Add("heroURL", SqlDbType.NVarChar).Value = artist.HeroUrl;

                await cmd.ExecuteNonQueryAsync();
                sqlConnectionm.Close();
                return true;
            }
        }
    }
}
