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
    public partial class Doc_View : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=KZORRE-ADMIN\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;Pooling=False");

        public Doc_View()
        {
            InitializeComponent();
        }

        private void Doc_View_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Doc_Info";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message + " review code");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input1 = textBox1.Text;
            string input2 = textBox2.Text;

            #region If else Test
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Doc_Info where title like ('%" + textBox1.Text + "%')";
                
                //if else injection
                if(input1.Equals(cmd.CommandText = "select * from Doc_Info where title like ('%" + textBox1.Text + "%')"))
                {
                    cmd.ExecuteNonQuery();
                }

                else if (input2.Equals(cmd.CommandText = "select * from Doc_Info where author like ('%" + textBox2.Text + "%')"))
                {
                    cmd.ExecuteNonQuery();
                }
               

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " review code");
            }

#endregion





            //Working code
            /* try
             {
                 con.Open();
                 SqlCommand cmd = con.CreateCommand();
                 cmd.CommandType = CommandType.Text;
                 cmd.CommandText = "select * from Doc_Info where title like ('%"+textBox1.Text +"%')";
                 //cmd.CommandText = "select title, author, publication, creation_date, count from Doc_Info where title like ('%" + textBox1.Text + "%')";
                 cmd.ExecuteNonQuery();

                 DataTable dt = new DataTable();
                 SqlDataAdapter da = new SqlDataAdapter(cmd);
                 da.Fill(dt);
                 dataGridView1.DataSource = dt;

                 con.Close();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message + " review code");
             }*/
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
         


            //Working code
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Doc_Info where title like ('%" + textBox1.Text + "%')";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " review code");
            }
        }

        //KeyUp event for textbox 2 input for live search
        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Doc_Info where author like ('%" + textBox2.Text + "%')";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " review code");
            }
        }
    }
}
