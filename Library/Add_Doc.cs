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
using System.Globalization;

namespace Library
{
    public partial class Add_Doc : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-QH730TPG\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False");
        public Add_Doc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = new DateTime();
            string mydate = date.ToString("dd-MM-yyyy");
            DateTimePicker dp = new DateTimePicker();
            //Connection
            con.Open(); //open database server
                        /*SqlCommand cmd = con.CreateCommand();
                          cmd.CommandType = CommandType.Text;
                          cmd.CommandText = "insert into Document_Info VALUES ('" + textBox1.Text+"', '"+ textBox2.Text + "', '"+ textBox3.Text + "', '"+ dateTimePicker1.Text + "', "+ textBox5.Text + ") ";
                         cmd.ExecuteNonQuery();*/
            SqlCommand sc = new SqlCommand("INSERT INTO Document_Info VALUES(@VAL1, @VAL2, @VAL3,@VAL4, @VAL5)", con);
            sc.Parameters.AddWithValue("@VAL1", textBox1.Text);
            sc.Parameters.AddWithValue("@VAL2", textBox2.Text);
            sc.Parameters.AddWithValue("@VAL3", textBox3.Text);
            //sc.Parameters.AddWithValue("@VAL4", dateTimePicker1.ToString());
           sc.Parameters.AddWithValue("@VAL4", dateTimePicker1.Text);
            sc.Parameters.AddWithValue("@VAL5", textBox5.Text);

            int i = sc.ExecuteNonQuery();
            MessageBox.Show(i+"Document added successfully");
            con.Close();
            


            //Try parse
            /*DateTime dt;
             if (DateTime.TryParseExact(dateTimePicker1.Text.Trim(), "Enter system date", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
             {
                 cmd.ExecuteNonQuery();
             }*/
           // con.Close();//close connected datababse



           // textBox1.Text = "";
           // textBox2.Text = "";
            //textBox3.Text = "";
            //dateTimePicker1.ToString();
            //textBox5.Text = "";

            //Display operation success
           // MessageBox.Show("Document added successfully");
        }
    }
}
