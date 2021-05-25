using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
namespace GUI
{    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();         
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Definition definition = new Definition();
            definition.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Maximized;
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();//מיותר לכאורה
            Definition definition = new Definition();
            definition.Show();
        }
    }
}
