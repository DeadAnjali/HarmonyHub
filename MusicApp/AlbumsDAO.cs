using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp
{
    internal class AlbumsDAO
    {
        string connectionstring = "datasource=localhost;port=3306;username=root;password=root;database=music";
        public List<Album> getAllAlbums(){
            List<Album> returnThese = new List<Album>();
            MySqlConnection connection=new MySqlConnection(connectionstring);
            connection.Open();

            //sequel statements
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM ALBUM",connection);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Album a = new Album
                    {
                        ID = reader.GetInt32(0),
                        AlbumName = reader.GetString(1),
                        ArtistName = reader.GetString(2),
                        Year = reader.GetInt32(3),
                        imageURL = reader.GetString(4),
                        Description = reader.GetString(5)
                    };
                    returnThese.Add(a);
                }
            }
            connection.Close();
            return returnThese;
        }
        public List<Album> searchTitle(String text)
        {
            List<Album> returnThese = new List<Album>();
            MySqlConnection connection = new MySqlConnection(connectionstring);
            connection.Open();
            string phrase="%"+text+"%";
            //sequel statements
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM ALBUM WHERE ALBUM_TITLE LIKE @search";
            cmd.Parameters.AddWithValue("@search", phrase);
            cmd.Connection = connection;
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Album a = new Album
                    {
                        ID = reader.GetInt32(0),
                        AlbumName = reader.GetString(1),
                        ArtistName = reader.GetString(2),
                        Year = reader.GetInt32(3),
                        imageURL = reader.GetString(4),
                        Description = reader.GetString(5)
                    };
                    returnThese.Add(a);
                }
            }
            connection.Close();
            return returnThese;
        }
        public int addAlbum(Album album)
        {
            MySqlConnection connection = new MySqlConnection(connectionstring);
            connection.Open();

            //sequel statements
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO `album`(`ALBUM_TITLE`, `ARTIST`, `YEAR`, `IMAGE_NAME`, `DESCRIPTION`) VALUES (@albumname,@artist,@year,@imgurl,@desc)";
            cmd.Parameters.AddWithValue("@albumname", album.AlbumName);
            cmd.Parameters.AddWithValue("@artist", album.ArtistName);
            cmd.Parameters.AddWithValue("@year", album.Year);
            cmd.Parameters.AddWithValue("@imgurl", album.imageURL);
            cmd.Parameters.AddWithValue("@desc", album.Description);

            cmd.Connection = connection;
            int n = cmd.ExecuteNonQuery();
            //(@albumname,@artist,@year,@imgurl,@desc
            connection.Close();
            return n;
        }
    }
}
