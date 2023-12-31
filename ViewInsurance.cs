﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class ViewInsurance : Form
    {
        string username = null;
        Controller controllerobj = new Controller();
        public ViewInsurance(string user)
        {
            InitializeComponent();
            dataGridView1.Hide();
            username = user;
        }

        public ViewInsurance()
        {
            InitializeComponent();
            dataGridView1.Hide();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            if (radioButton1.Checked == true)
            {
                controllerobj = new Controller();
                dt = controllerobj.viewinsurance("H", username);
                if (dt == null)
                {
                    dataGridView1.Hide();
                    MessageBox.Show("No data is found");
                }
                else
                {
                    dataGridView1.Show();
                    dataGridView1.DataSource = dt;
                }
            }
            else if (radioButton2.Checked == true)
            {
                controllerobj = new Controller();
                dt = controllerobj.viewinsurance("L", username);
                if (dt == null)
                {
                    dataGridView1.Hide();
                    MessageBox.Show("No data is found");
                }
                else
                {
                    dataGridView1.Show();
                    dataGridView1.DataSource = dt;
                }
            }
            else if (radioButton3.Checked == true)
            {

                controllerobj = new Controller();
                dt = controllerobj.viewinsurance("P", username);
                if (dt == null)
                {
                    dataGridView1.Hide();
                    MessageBox.Show("No data is found");
                }
                else
                {
                    dataGridView1.Show();
                    dataGridView1.DataSource = dt;
                }
            }
            else
            {
                MessageBox.Show("Please Choose a type of requests to show its data");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ViewInsurance_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            welcome w2 = new welcome();
            w2.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = username.Substring(0, 1);
            if (str == "m" || str == "M")
            {
                Manager m1 = new Manager(username);
                m1.Show();
                this.Hide();
            }
            else if (str == "i" || str == "I")
            {
                Home h1 = new Home(username);
                h1.Show();
                this.Hide();
            }
            else if (str == "e" || str == "E")
            {
                EmployeeHomepage h2 = new EmployeeHomepage(username, 'g');
                h2.Show();
                this.Hide();
            }
            else if (str == "g" || str == "G")
            {
                EmployeeHomepage h2 = new EmployeeHomepage(username, 'g');
                h2.Show();
                this.Hide();
            }
            else if (str == "f" || str == "F") //finance
            {
                EmployeeHomepage h2 = new EmployeeHomepage(username, 'f');
                h2.Show();
                this.Hide();
            }
            else if (str == "p" || str == "P") //production
            {
                EmployeeHomepage h2 = new EmployeeHomepage(username, 'p');
                h2.Show();
                this.Hide();
            }

        }
    }
}
