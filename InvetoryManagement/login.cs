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
    public partial class login : Form
    {
        //Connect to database
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\IvanStoev10\source\repos\InvetoryManagement\InvetoryManagement\inventory.mdf;Integrated Security = True");

        private void login_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        public login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void submit_Click(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = 
                "SELECT * FROM Registration WHERE " +
                "username='"+ textBox1.Text + "' " +
                "AND password='"+ textBox2.Text +"'";

            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dataTable);
            i = Convert.ToInt32(dataTable.Rows.Count.ToString());

            if(i==0)
            {
                MessageBox.Show("Username and password do not exist");
            }else
            {
                //Switch windows if successful 
                this.Hide();
                var mDIParent1 = new MDIParent1();
                mDIParent1.Show();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Send user to reg window if he hasn't got an account
            this.Hide();
            var reg = new register();
            reg.Show();

        }
    }
}
