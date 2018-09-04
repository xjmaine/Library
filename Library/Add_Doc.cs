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
        SqlConnection con = new SqlConnection(@"Data Source=KZORRE-ADMIN\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;Pooling=False");
        public Add_Doc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newdate = dateTimePicker1.Text; //parse date picker to string value
            DateTime dt = Convert.ToDateTime(newdate); //insert into method for conversion to system date
            
            //Connection
            con.Open();
            //open database server

            SqlCommand sc = con.CreateCommand();
             sc.CommandType = CommandType.Text;
             sc.CommandText = "INSERT INTO Doc_Info  values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '"+ dt.ToShortDateString()+ "' , '"+ textBox5.Text + "')";
             sc.ExecuteNonQuery();
             // int i = sc.ExecuteNonQuery();

             textBox1.Text = "";
             textBox2.Text = "";
             textBox3.Text = "";
             textBox5.Text = "";


             MessageBox.Show(" Document added successfully");

             con.Close();




           /* DateTime dateTime = new DateTime();

            


            SqlCommand sc = new SqlCommand ("INSERT INTO Doc_Info VALUES(@VAL1, @VAL2, @VAL3,CONVERT(datetime, @VAL4), @VAL5)", con);
            sc.Parameters.AddWithValue("@VAL1", textBox1.Text);
            sc.Parameters.AddWithValue("@VAL2", textBox2.Text);
            sc.Parameters.AddWithValue("@VAL3", textBox3.Text);
            sc.Parameters.AddWithValue("@VAL4",dateTimePicker1.Text );
            sc.Parameters.AddWithValue("@VAL5", textBox5.Text);
            sc.ExecuteNonQuery();
            MessageBox.Show(" Document added successfully"); // Convert(dateTime, '"+dateTimePicker1.text+"', 0)

            //Close connection
            con.Dispose();*/
            




        }
    }
}
