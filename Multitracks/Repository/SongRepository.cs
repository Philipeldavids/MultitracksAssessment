using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Multitracks.Models;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using Multitracks.Interface;

namespace Multitracks.Repository
{
   
    public class SongRepository: ISongRepository
    {
        private readonly IConfiguration _configuration;

        public SongRepository(IConfiguration configuration) 
        {
            
        _configuration = configuration;
        }
        public List<Song> GetAllSongs()
        {
            var connectionString =  _configuration["ConnectionStrings:DefaultConnection"];

            List<Song> songs = new List<Song>();
            using ( SqlConnection sqlConnectionm = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Song";

                SqlCommand cmd = new SqlCommand(sql, sqlConnectionm);

                sqlConnectionm.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                

                while (reader.Read())
                {
                    var song = new Song();
                    song.SongId = int.Parse(reader["songID"].ToString());
                    song.DateCreation = Convert.ToDateTime(reader["dateCreation"].ToString());
                    song.AlbumID = int.Parse(reader["albumID"].ToString());
                    song.ArtistId = int.Parse(reader["artistID"].ToString());
                    song.Title = reader["title"].ToString();
                    song.Bpm = Convert.ToDecimal(reader["bpm"].ToString());
                    song.TimeSignature = reader["timeSignature"].ToString();
                    song.Multitracks = Convert.ToBoolean(reader["multitracks"].ToString());
                    song.CustomMix = Convert.ToBoolean(reader["customMix"].ToString());
                    song.Chart = Convert.ToBoolean(reader["chart"].ToString());
                    song.RehearsalMix = Convert.ToBoolean(reader["rehearsalMix"].ToString());
                    song.Patches = Convert.ToBoolean(reader["patches"].ToString());
                    song.SongSpecificPatches = Convert.ToBoolean(reader["songSpecificPatches"].ToString());
                    song.ProPresenter = Convert.ToBoolean(reader["proPresenter"].ToString());

                    songs.Add(song);

                }
                reader.Close();
                sqlConnectionm.Close();

            }
            return songs;
        }
    }
   
   
}
