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

namespace InvetoryManagement
{
    public partial class register : Form
    {
        //Conect to database 
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\IvanStoev10\source\repos\InvetoryManagement\InvetoryManagement\inventory.mdf;Integrated Security = True");

        private void register_Load(object sender, EventArgs e)
        {
            if(con.State == ConnectionState.Open)
                con.Close();
            else
                con.Open(); 
        }

        public register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Setting values for new user
            var firstName = textBox7.Text;
            var lastName = textBox8.Text;
            var username = textBox9.Text;
            var password = textBox10.Text;
            var email = textBox11.Text;
            var phone = textBox12.Text;

            //Setting query
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                "INSERT INTO Registration (firstname, lastname, username, password, email, phone)" +
                "VALUES ('" + firstName + "', '" + lastName + "', '" + username + "', '" + password + "', '" + email + "', '" + phone +"')";
        
            //Executing query
            cmd.ExecuteNonQuery();
            var dataTable = new DataTable();
            this.Hide();
            var login = new login();
            login.Show();
            MessageBox.Show("Registration was successful");

        }
    }
}
