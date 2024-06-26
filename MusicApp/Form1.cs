﻿using System;
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

        private void button2_Click(object sender, EventArgs e)
        {
            //onclicking load button
            AlbumsDAO albumsDAO = new AlbumsDAO();

            albumbindingSource.DataSource = albumsDAO.searchTitle(textBox1.Text);
            dataGridView1.DataSource = albumbindingSource;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //nothing happens
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView=(DataGridView)sender;
            int row = dataGridView.CurrentRow.Index;
            String imageUrl = dataGridView.Rows[row].Cells[4].Value.ToString();
            pictureBox1.Load(imageUrl);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            //nothing
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Album album = new Album
            {
                AlbumName=txt_albumName.Text,
                ArtistName=txt_artist.Text,
                Year=Int32.Parse(txt_year.Text),
                imageURL=txt_imageurl.Text,
                Description=txt_description.Text
            };
            AlbumsDAO albumsDAO = new AlbumsDAO();

            int rows=albumsDAO.addAlbum(album);
            MessageBox.Show(rows+"new row(s) added");
        }
    }
}
