using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicApp
{
    public partial class Form1 : Form
    {
        BindingSource albumbindingSource=new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //onclicking load button
            AlbumsDAO albumsDAO = new AlbumsDAO();
           
            albumbindingSource.DataSource = albumsDAO.getAllAlbums();
            dataGridView1.DataSource = albumbindingSource;

        }
    }
}
