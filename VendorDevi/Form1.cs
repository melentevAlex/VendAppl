using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendorDevi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
            
        private void completteButton_Click(object sender, EventArgs e)
        {
            string conString = @"Data Source=DESKTOP-1RK0ITO\SQLEXPRESS;Initial Catalog=ordersDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            string  q = "UPDATE orderTab SET complete = 'Отправлено' where id = (select max(id) from orderTab);";

            //string q = "UPDATE orderTab SET complete=true WHERE id = (select max(id) from orderTab);";

            //string q = "insert into orderTab(complete) values('" + true + "')";
            SqlCommand cmd2 = new SqlCommand(q, con);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Курьёр повёз пиццу");

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            string conString = @"Data Source=DESKTOP-1RK0ITO\SQLEXPRESS;Initial Catalog=ordersDB;Integrated Security=True";

            SqlConnection Mycon = new SqlConnection(conString);

            Mycon.Open();


            string query = "SELECT * FROM orderTab where id = (select max(id) from orderTab)";

            SqlCommand command = new SqlCommand(query, Mycon);

            SqlDataReader reader = command.ExecuteReader();


            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[3]);

                data[data.Count - 1][0] = reader[1].ToString();
                data[data.Count - 1][1] = reader[2].ToString();
            }
            reader.Close();
            Mycon.Close();
            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private void label7_MouseMove(object sender, MouseEventArgs e)
        {
            label7.BackColor = Color.FromArgb(137, 134, 209);
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.BackColor = Color.FromArgb(137, 209, 174);
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(label7, "Но мы за честный бартер. Я тебе хип - хап, ты мне руки вверх.");
        }
    }
}

