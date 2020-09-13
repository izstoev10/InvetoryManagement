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

namespace InvetoryManagement
{
    public partial class unit : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\IvanStoev10\source\repos\InvetoryManagement\InvetoryManagement\inventory.mdf;Integrated Security = True");

        private void unit_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            else
                con.Open();
            display();
        }


        public unit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //set value for unit
            var units = textBox1.Text;

            //set query
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                "INSERT INTO Units VALUES ('" + units + "')";

            //check if unit exists
            int i = 0;
            SqlCommand check = con.CreateCommand();
            check.CommandText = "SELECT * FROM Units WHERE unit='" + units + "'";
            check.ExecuteNonQuery();
            var dt = new DataTable();
            var da = new SqlDataAdapter(check);
            da.Fill(dt);
            // if i = 0, doesn't exist
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            //execute if unit doesn't exist
            if (i == 0)
                cmd.ExecuteNonQuery();
            else
                MessageBox.Show("unit already exists");

            display();
        }
        
        public void display()
        {
            //set value for unit
            var units = textBox1.Text;

            //set query
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Units";
            var dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }
       
    }
}
