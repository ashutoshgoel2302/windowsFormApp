using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace windowsFormApp
{
    public partial class Form2 : Form
    {
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        public static string SetValueForText3 = "";
        public static string SetValueForText4 = "";
        public static string SetValueForText5 = "";
        public static string SetValueForText6 = "";
        public static string SetValueID = "";

        AngularEntities angularEntities = new AngularEntities();
        public Form2()
        {
            InitializeComponent();
           
            //dataGridView1.DataSource = (from data in angularEntities.Children
            //                            select data).ToList();

            dataGridView1.DataSource = angularEntities.Children.ToList();
        }
       

     
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(textBox1.Text))
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = angularEntities.Children.Where(x => x.FirstName == textBox1.Text).ToList();
            }
            if (!String.IsNullOrEmpty(textBox2.Text))
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = angularEntities.Children.Where(x => x.LastName == textBox2.Text).ToList();
            }
            if ((!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text)))
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = angularEntities.Children.Where(x => x.FirstName == textBox1.Text && x.LastName == textBox2.Text).ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            dataGridView1.DataSource = angularEntities.Children.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows) // foreach datagridview selected rows values  
                {
                    SetValueID = row.Cells[0].Value.ToString();
                    SetValueForText1 = row.Cells[1].Value.ToString();
                    SetValueForText2 = row.Cells[2].Value.ToString();
                    SetValueForText3 = row.Cells[3].Value.ToString();
                    SetValueForText4 = row.Cells[4].Value.ToString();
                    SetValueForText5 = row.Cells[5].Value.ToString();
                    SetValueForText6 = row.Cells[6].Value.ToString();
                }
                Form1 form1 = new Form1();
                form1.Show();
            }
        }
    }
}
