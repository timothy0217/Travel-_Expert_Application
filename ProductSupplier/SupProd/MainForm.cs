using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using supProduct;
using supSupplier;
namespace SupProd
{  /**Purpose:Finish creating new ,or update or deleate relationship between product and supplier
    *Author: timothy,Tsai
    *Date:JAn23,2018
    **/
    public partial class MainForm : Form
    {
        //create a form within the panel
        public frmPrductSupplier myForm = new frmPrductSupplier();
        public supProduct.Form2 myForm1 = new Form2();
        public supSupplier.Form3 myForm3 = new Form3();
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
            panel5.Visible = false;
            //color effect on click
            btn1.BackColor = Color.FromArgb(78, 79, 84);
            btn2.BackColor = Color.FromArgb(83, 94, 100);
            button1.BackColor = Color.FromArgb(83, 94, 100);
            btn3.BackColor = Color.FromArgb(83, 94, 100);
            btnHome.BackColor = Color.FromArgb(83, 94, 100);
            pictureBox4.BackColor = Color.FromArgb(83, 94, 100);
            pictureBox2.BackColor = Color.FromArgb(83, 94, 100);
            pictureBox3.BackColor = Color.FromArgb(83, 94, 100);
            




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
            panel5.Visible = false;

            //color effect on click
            btn2.BackColor = Color.FromArgb(78, 79, 84);
            btn1.BackColor = Color.FromArgb(83, 94, 100);
            btn3.BackColor = Color.FromArgb(83, 94, 100);
            btnHome.BackColor = Color.FromArgb(83, 94, 100);
            button1.BackColor = Color.FromArgb(83, 94, 100);
            pictureBox2.BackColor = Color.FromArgb(78, 79, 84);
            pictureBox3.BackColor = Color.FromArgb(83, 94, 100);
            pictureBox4.BackColor = Color.FromArgb(83, 94, 100);







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
            panel5.Visible = false;
            btnHome.BackColor = Color.FromArgb(78, 79, 84);
       
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
            panel5.Visible = false;

            //color effect on click
            btn3.BackColor = Color.FromArgb(78, 79, 84);
            btn2.BackColor = Color.FromArgb(83, 94, 100);
            btn1.BackColor = Color.FromArgb(83, 94, 100);
            btnHome.BackColor = Color.FromArgb(83, 94, 100);
            button1.BackColor = Color.FromArgb(83, 94, 100);
            pictureBox2.BackColor = Color.FromArgb(83, 94, 100);
            pictureBox3.BackColor = Color.FromArgb(78, 79, 84);
            pictureBox4.BackColor = Color.FromArgb(83, 94, 100);



        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            //color effect on click
            btn3.BackColor = Color.FromArgb(83, 94, 100);
            btn2.BackColor = Color.FromArgb(83, 94, 100);
            btn1.BackColor = Color.FromArgb(83, 94, 100);
            btnHome.BackColor = Color.FromArgb(78, 79, 84);
            button1.BackColor = Color.FromArgb(83, 94, 100);
            pictureBox2.BackColor = Color.FromArgb(83, 94, 100);
            pictureBox3.BackColor = Color.FromArgb(83, 94, 100);
            pictureBox4.BackColor = Color.FromArgb(83, 94, 100);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //switch from panels 
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            panel1.Controls.Add(myForm);
            myForm.Show();
            panel5.BringToFront();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
            //color effect on click
            btn1.BackColor = Color.FromArgb(83, 94, 100);
            btn2.BackColor = Color.FromArgb(83, 94, 100);
            button1.BackColor = Color.FromArgb(78, 79, 84);
            btn3.BackColor = Color.FromArgb(83, 94, 100);
            btnHome.BackColor = Color.FromArgb(83, 94, 100);
            pictureBox2.BackColor = Color.FromArgb(83, 94, 100);
            pictureBox3.BackColor = Color.FromArgb(83, 94, 100);
            pictureBox4.BackColor = Color.FromArgb(78, 79, 84);

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
