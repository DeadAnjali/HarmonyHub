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

            return returnThese;
        }
    }
}
