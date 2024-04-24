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
    }
}
