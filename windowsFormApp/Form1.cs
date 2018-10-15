using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace windowsFormApp
{
    public partial class Form1 : Form
    {
        AngularEntities angularEntities = new AngularEntities();
       
        public Form1()
        {
            InitializeComponent();

            textBox1.Text = string.IsNullOrEmpty(Form2.SetValueForText1) ?"": Form2.SetValueForText1;
            textBox2.Text = string.IsNullOrEmpty(Form2.SetValueForText2) ? "" : Form2.SetValueForText2;
            comboBox1.Text = string.IsNullOrEmpty(Form2.SetValueForText3) ? "" : Form2.SetValueForText3;
            textBox4.Text = string.IsNullOrEmpty(Form2.SetValueForText4) ? "" : Form2.SetValueForText4;
            textBox5.Text = string.IsNullOrEmpty(Form2.SetValueForText5) ? "" : Form2.SetValueForText5;
            comboBox2.Text = string.IsNullOrEmpty(Form2.SetValueForText6) ? "" : Form2.SetValueForText6;
        }

        private void button2_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show("hi editpage");
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Child children = new Child()
            {
                FirstName = textBox1.Text,
                LastName=textBox2.Text,
                Gender=comboBox1.Text,
                Address=textBox4.Text,
                BirthDate=Convert.ToDateTime(textBox5.Text),
                ChildType=comboBox2.Text,
            };
            angularEntities.Children.Add(children);
            angularEntities.SaveChanges();
            clearText();
        }

        public void clearText()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var childId = Convert.ToInt32(Form2.SetValueID);
            if(!string.IsNullOrEmpty(Form2.SetValueID))
            {
               var editableChild= angularEntities.Children.Where(x => x.ID == childId).FirstOrDefault();
                editableChild.FirstName = textBox1.Text;
                editableChild.LastName = textBox2.Text;
                editableChild.Gender = comboBox1.Text;
                editableChild.Address = textBox4.Text;
                editableChild.BirthDate = Convert.ToDateTime(textBox5.Text);
                editableChild.ChildType = comboBox2.Text;

                angularEntities.SaveChanges();
                clearText();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var childId = Convert.ToInt32(Form2.SetValueID);
            if (!string.IsNullOrEmpty(Form2.SetValueID))
            {
                var editableChild = angularEntities.Children.Where(x => x.ID == childId).FirstOrDefault();
                angularEntities.Children.Remove(editableChild);

                angularEntities.SaveChanges();
                clearText();
            }
        }
    }
}
