using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Movie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //---------------------------------------
        void cleartextbox()
        {
            txt_title.Clear();
            txt_release_date.Clear();
            txt_genre.Clear();
            txt_price.Clear();
        }
        //---------------------------------------------
        /// <summary>
        /// global variable for use every function
        /// </summary>
        string connectionstring;
        MySqlConnection conn;
        MySqlCommand command;
        //--------------------------------------------
        void selectfunction()
        {
            connectionstring = string.Format("server=localhost;uid=root;pwd=;database=db_flim");

            conn = new MySqlConnection(connectionstring);

            conn.Open();
            string query = "select * from movies";
            command = new MySqlCommand(query, conn);
            
            MySqlDataReader reader = command.ExecuteReader();
            string output = "";
            while (reader.Read())
            {
                output = output + reader.GetValue(0) + " , " + reader.GetValue(1) + " , " + reader.GetValue(2) + " , " + reader.GetValue(3)+"\n";
            }
            MessageBox.Show(output);
            reader.Close();
            command.Dispose();
            


        }

        //---------------------------------------------
        void insertfunction()
        {
            string title, releasedate, genre;
            int price;
            title = txt_title.Text;
            releasedate = txt_release_date.Text;
            genre = txt_genre.Text;
            price = int.Parse(txt_price.Text);

            connectionstring = string.Format("server=localhost;uid=root;pwd=;database=db_flim");

            conn = new MySqlConnection(connectionstring);

            conn.Open();
            string query = "insert into movies values('" + title + "','" + releasedate + "','" + genre + "','" + price + "')";
            command = new MySqlCommand(query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            adapter.InsertCommand = new MySqlCommand(query, conn);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            MessageBox.Show("data success");
            cleartextbox();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            insertfunction();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectfunction();
        }
    }
}
