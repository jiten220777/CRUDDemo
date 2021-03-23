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
namespace CRUDDemo
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5KJ3FQM\EXPRESS;Initial Catalog=CRUDDemo_DB;Integrated Security=true");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Clear();
            dataGridView1.GridColor = Color.Gray;
        }

        void Clear()
        {
            BindGrid();
            txtID.Text = GetIntegerMaxID().ToString();
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            btnSave.Text = "Save";
            txtName.Focus();
        }

       //To show data in grid 
       void BindGrid()
        {
            con.Open();
            string Query = "select * from tbl_Contact";
            da = new SqlDataAdapter(Query, con);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int pos = dataGridView1.RowCount;
                dataGridView1.RowCount = pos + 1;
                dataGridView1.Rows[pos].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                dataGridView1.Rows[pos].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                dataGridView1.Rows[pos].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                dataGridView1.Rows[pos].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
            }
            con.Close();
        }
        //To get max id in table
        public int GetIntegerMaxID()
        {
            object obj = new object();
            int id = 1;
            string qr = "select max(ID) from tbl_Contact";
            con.Open();
            cmd = new SqlCommand(qr, con);
            obj = cmd.ExecuteScalar();
            if (obj.ToString() != "")
            {
                id = Convert.ToInt32(obj) + 1;
            }
            con.Close();
            return id;
        }
        //To Save or Update records
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtName.Text!="" && txtAddress.Text!="")
            {
                if(btnSave.Text=="Save")
                {
                    con.Open();
                    string query = "insert into tbl_Contact values('" + txtID.Text + "','" + txtName.Text + "','" + txtAddress.Text + "','" + txtContact.Text + "')";
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Saved Successfully !", "JS Technologies Message", MessageBoxButtons.OK);
                    Clear();
                }
                else
                {
                    con.Open();
                    string query = "update tbl_Contact set Name='" + txtName.Text + "',Address='" + txtAddress.Text + "',ContactNo='" + txtContact.Text + "' where ID='" + txtID.Text + "'";
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Updated Successfully !", "JS Technologies Message", MessageBoxButtons.OK);
                    Clear();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
        //To get data for update
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                txtID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtAddress.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtContact.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                btnSave.Text = "Update";
            }
        }
        //To delete the record
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are You Sure to Delete ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr.ToString() == "Yes")
            {
                con.Open();
                string query = "delete from tbl_Contact where ID='" + dataGridView1.SelectedRows[0].Cells[0].Value + "'";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
            }
        }
        //To search record by name
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text!="")
            {
                con.Open();
                da = new SqlDataAdapter("select * from tbl_Contact where Name like '" + txtSearch.Text.Trim() + "%'", con);
                ds = new DataSet();
                da.Fill(ds);
                dataGridView1.Rows.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int pos = dataGridView1.RowCount;
                    dataGridView1.RowCount = pos + 1;
                    dataGridView1.Rows[pos].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    dataGridView1.Rows[pos].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    dataGridView1.Rows[pos].Cells[2].Value = ds.Tables[0].Rows[i][2].ToString();
                    dataGridView1.Rows[pos].Cells[3].Value = ds.Tables[0].Rows[i][3].ToString();
                }
                con.Close();
            }
            else
            {
                BindGrid();
            }
        }
    }
}
