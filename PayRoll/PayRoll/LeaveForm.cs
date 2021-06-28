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

namespace PayRoll
{
    public partial class LeaveForm : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-L7N98AO\\MARIMGK;Initial Catalog=PayRoll;Integrated Security=True");
        dbconnection dbcon = new dbconnection();
        public LeaveForm()
        {
            InitializeComponent();
        }

        private void LeaveForm_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Emp_Id from Payment ", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            // dataGridView1.DataSource = dt;
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "Emp_Id";

        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {


            // DateTimePicker dt = new DateTimePicker();
            DateTime date1 = dateTimePicker1.Value.Date;
            DateTime date2 = dateTimePicker2.Value.Date;

            if (richTextBox1 == null)
            {
                richTextBox1.Text = " - ";
            }
            if (CheckEmpty())
            {
                if (dateCheck())
                {
                    DialogResult dg = MessageBox.Show("Do you Want to Save Record ?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dg == DialogResult.Yes)
                    {
                        int No_Of_Days = date2.Day - date1.Day + 1;
                        String query = " Insert into Leave Values('" + comboBox1.Text + "','" + textBox1.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + No_Of_Days + "', '" + 200 + "','" + richTextBox1.Text + "' )";
                        dbcon.Executing(query);
                        MessageBox.Show("Record Updated");
                    }
                    else
                    {
                        MessageBox.Show("Cenceled.....");
                    }

                   
                }
                else
                {
                    MessageBox.Show("Invalid Date");
                }
            }
            else
            {
                MessageBox.Show("Some fields are empty");
            }














           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            String q = "select Emp_Name from Leave where Emp_Id ='" + comboBox1.SelectedValue.ToString() + "' ";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader reader1 = cmd.ExecuteReader();
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    textBox1.Text = reader1[0].ToString();
                }
            }
            reader1.Close();
        }

       
        
        public bool CheckEmpty()
        {

            if (textBox1.Text == "" && comboBox1.Text == "")
            {
                comboBox1.Focus();
                return false;

            }
            else if (textBox1.Text == "")
            {
            
                textBox1.Focus();
                
                return false;
            }
            else if (comboBox1.Text == "")
            {
               
                comboBox1.Focus();
                return false;
            }
            
                return true;

        }
        public bool dateCheck()
        {
            DateTime date1 = dateTimePicker1.Value.Date;
            DateTime date2 = dateTimePicker2.Value.Date;
            if (date1.CompareTo(date2) < 0)
            {
                return true;
            }         
            else if (date1.CompareTo(date2) == 0)
            {
                return true;
            }
            return false;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '\n' || e.KeyChar == '\t')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '\n' || e.KeyChar == '\t')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            String q = "select Emp_Name from Leave where Emp_Id ='" + comboBox1.Text+ "' ";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader reader1 = cmd.ExecuteReader();
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    textBox1.Text = reader1[0].ToString();
                }
            }
            else
            {
                MessageBox.Show("No record found");
            }
            reader1.Close();
        }
    }
}
