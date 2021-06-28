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
    public partial class Calculation : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-L7N98AO\\MARIMGK;Initial Catalog=PayRoll;Integrated Security=True");
        String salary = "";
        public Calculation()
        {
            InitializeComponent();
        }

        private void Calculation_Load(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Calculation", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            // dataGridView1.DataSource = dt;
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "Emp_Id";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Do you Want to Save Record ?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                MessageBox.Show("Record Updated");
            }
            else
            {
                MessageBox.Show("Cenceled...");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String q = "select * from Calculation where Emp_Id ='" + comboBox1.SelectedValue.ToString() + "' ";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader reader1 = cmd.ExecuteReader();
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    textBox1.Text = reader1[2].ToString();
                    textBox2.Text = reader1[3].ToString();
                    textBox3.Text = reader1[6].ToString();
                    textBox4.Text = reader1[4].ToString();
                    textBox5.Text = reader1[5].ToString();
                    textBox6.Text = reader1[7].ToString();
                    textBox7.Text = reader1[8].ToString();
                    salary = reader1[9].ToString();
                }
            }
            else
            {
                MessageBox.Show(" You try enter new values");
            }
            reader1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox9.Text = salary.ToString();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            String q = "select * from Calculation where Emp_Id ='" + comboBox1.Text + "' ";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader reader2 = cmd.ExecuteReader();
            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    textBox1.Text = reader2[2].ToString();
                    textBox2.Text = reader2[3].ToString();
                    textBox3.Text = reader2[6].ToString();
                    textBox4.Text = reader2[4].ToString();
                    textBox5.Text = reader2[5].ToString();
                    textBox6.Text = reader2[7].ToString();
                    textBox7.Text = reader2[8].ToString();
                    salary = reader2[9].ToString();
                }
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";

            }
            reader2.Close();
        }

        private void comboBox1_Validated(object sender, EventArgs e)
        {

          
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            String q = "select * from Calculation where Emp_Id ='" + comboBox1.Text + "' ";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader reader2 = cmd.ExecuteReader();
            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    textBox1.Text = reader2[2].ToString();
                    textBox2.Text = reader2[3].ToString();
                    textBox3.Text = reader2[6].ToString();
                    textBox4.Text = reader2[4].ToString();
                    textBox5.Text = reader2[5].ToString();
                    textBox6.Text = reader2[7].ToString();

                    textBox7.Text = reader2[8].ToString();
                    salary = reader2[9].ToString();
                }
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                MessageBox.Show("Invalid ID.....If you Want to enter new record,you will continue,Otherwise Enter correct ID..");

            }
            reader2.Close();
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
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '\n' || e.KeyChar == '\t')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
