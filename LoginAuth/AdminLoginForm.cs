using MetroFramework.Forms;
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

namespace LoginAuth
{
    public partial class AdminLoginForm : MetroForm
    {
        string databaseLocation = "C:\\Users\\Shuvro\\Documents\\Visual Studio 2013\\Projects\\LoginAuth\\LoginAuth\\AdminLoginDb.mdf";
        public AdminLoginForm()
        {
            InitializeComponent();
        }
        private void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                
                string constr = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" + databaseLocation + ";Integrated Security=True";
                SqlConnection con = new SqlConnection(@constr);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from adminLogin Where Username= '" + textBox_username.Text + "' and Password = '" + textBox_Password.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    Informations info = new Informations();
                    info.Show();
                }
                else
                {
                    MessageBox.Show("Wrong Password");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
