using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library
{
    public partial class Login : Form
    {
        //Add_Doc instance
        Add_Doc ad = new Add_Doc();

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-QH730TPG\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False");

        int count = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            } con.Open();

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Libra_Person where Username ='"+textBox1.Text+"' and password ='"+textBox2.Text+"' ";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());

            //Login Logic
            if (count == 0)
            {
                MessageBox.Show("Username or Password does not match");
            }

            else
            {
                this.Hide();
                mdi_user mu = new mdi_user();
                mu.Show();
               
            }
        }
    }
}
