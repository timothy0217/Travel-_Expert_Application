using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupProd
{
    public partial class MainForm : Form
    {
       public  frmPrductSupplier myForm = new frmPrductSupplier();
       public  Form1 myForm1 = new Form1();
        public Form3 myForm3 = new Form3();
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {

            
            //switch from panels 
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            panel1.Controls.Add(myForm);
            myForm.Show();
            panel1.BringToFront();
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            //color effect on click
            btn1.BackColor = Color.FromArgb(78, 79, 84);
            btn2.BackColor = Color.FromArgb(83, 94, 100);
            btn3.BackColor = Color.FromArgb(83, 94, 100);




        }

        private void btn2_Click(object sender, EventArgs e)
        {
            
            myForm1.FormBorderStyle = FormBorderStyle.None;
            myForm1.TopLevel = false;
            myForm1.AutoScroll = true;
            panel2.Controls.Add(myForm1);
            myForm1.Show();
            panel2.BringToFront();
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;

            //color effect on click
            btn2.BackColor = Color.FromArgb(78, 79, 84);
            btn1.BackColor = Color.FromArgb(83, 94, 100);
            btn3.BackColor = Color.FromArgb(83, 94, 100);






        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximizeBox = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
           
            myForm3.FormBorderStyle = FormBorderStyle.None;
            myForm3.TopLevel = false;
            myForm3.AutoScroll = true;
            panel3.Controls.Add(myForm3);
            myForm3.Show();
            panel3.BringToFront();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;

            //color effect on click
            btn3.BackColor = Color.FromArgb(78, 79, 84);
            btn2.BackColor = Color.FromArgb(83, 94, 100);
            btn1.BackColor = Color.FromArgb(83, 94, 100);


        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

  
    }
}
