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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;
using System.Security.Cryptography;
using System.Xml.Linq;
namespace project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lodhi\source\repos\project\project\Database1.mdf;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtid.Text != string.Empty && txtname.Text != string.Empty && txtemail.Text != string.Empty)
                {
                    conn.Open();
                    string str = "insert into employeemst values(@eid, @name, @address, @email)";
                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.Parameters.AddWithValue("@eid", txtid.Text);
                    cmd.Parameters.AddWithValue("@name", txtname.Text);
                    cmd.Parameters.AddWithValue("@address", txtadd.Text);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record inserted successfully", "Record Inserted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    //bindgrid();

                }
                else
                {
                    MessageBox.Show("Please enter value in all fields", "Invalid data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // clearall();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
 private void clearall()
        {
            txtid.Clear();
            txtname.Clear();
            txtadd.Clear();
            txtemail.Clear();
            txtid.ReadOnly = false;
            txtid.Focus();
        }
        private void bindgrid()
        {
            try
            {
                string str = "select *from employeemst";
                SqlDataAdapter adpt = new SqlDataAdapter(str, conn);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                gdview.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bindgrid();
        }
        private void Gdview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = gdview.Rows[e.RowIndex];
                    txtid.Text = row.Cells[0].Value.ToString();
                    txtname.Text = row.Cells[1].Value.ToString();
                    txtadd.Text = row.Cells[2].Value.ToString();
                    txtemail.Text = row.Cells[3].Value.ToString();
                    txtid.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtid.Text != string.Empty && txtname.Text != string.Empty &&
               txtemail.Text != string.Empty)
                {
                    conn.Open();
                    string str = "update employeemst set name = @name,address = @address,email = @email where eid = @eid";
                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.Parameters.AddWithValue("@eid", txtid.Text);
                    cmd.Parameters.AddWithValue("@name", txtname.Text);
                    cmd.Parameters.AddWithValue("@address", txtadd.Text);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record updated successfully", "Record Updated",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    bindgrid();
                }
                else
                {
                    MessageBox.Show("Please enter value in all fields", "Invalid    data",


                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            clearall();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtid.Text != string.Empty)
                {
                    conn.Open();
                    string str = "delete from employeemst where eid=@eid";
                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.Parameters.AddWithValue("@eid", txtid.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record deleted successfully", "Record Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    bindgrid();
                }
                else
                {
                    MessageBox.Show("Please enter value in all fields", "Invalid data",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            clearall();

        }

    }
}