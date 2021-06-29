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

namespace Assignment_4
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-153RETS;Initial Catalog=VPL_Lab;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
            showData();
            deleteCombo();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string query = "insert into Employee_Data values(" + Convert.ToInt32(txtEmployeeId.Text) + ",'" + txtName.Text + "'," + Convert.ToInt32(txtSalary.Text) + ",'" + txtEmail.Text + "'," + Convert.ToInt64(txtContact.Text) + ",'" + txtAddress.Text + "','" + txtPosition.Text + "')";

            cmd = new SqlCommand(query, con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Added successfully");
            showData();





        }

        private void viewData_Click(object sender, EventArgs e)
        {

        }

        public void deleteCombo()
        {
            
            string query1 = "select * from Employee_Data";
            cmd = new SqlCommand(query1, con);



            try
            {
                con.Open();
                dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    int employeeId =Convert.ToInt32(dr["EmployeeId"]);
                    comboBox1.Items.Add(employeeId);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            
            
        }

        public void showData()
        {
            string query = "select * from Employee_Data";

            cmd = new SqlCommand(query, con);

            con.Open();
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            dataGridView1.DataSource = dt;

            con.Close();

        }

        public void selectCombox1()
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            string query = "delete from Employee_Data where EmployeeId=" +comboBox1.Items ;

            cmd = new SqlCommand(query, con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Delete Successfully");
            showData();

        }
    }
}
