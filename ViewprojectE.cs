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
    public partial class ViewprojectE : Form
    {
        string username;
        DataTable dt;
        Controller ControllerObj = new Controller();
        public ViewprojectE(string usernamec)
        {
            InitializeComponent();
            username = usernamec;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //search for projects
            string status = (DateTime.Today).ToString("MM-dd-yyy");
            if (radioButton1.Checked)
            { 
                dt= ControllerObj.SelectProjectsByUsernameAndtatusNotdone(username,status);
            }
            else if (radioButton2.Checked)
            {
               
                dt =ControllerObj.SelectProjectsByUsernameAndtatusdone(username, status);
            }
            else if(radioButton3.Checked)
            {
                dt = ControllerObj.SelectProjectsByUsernameAndtatusall(username);

            }
            else
            {
                MessageBox.Show("Please select a status");
            }
            dataGridView1.DataSource = dt;
            if (dt == null)
            {
                MessageBox.Show("No projects found");
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //radioButton2.Checked = false;
           // radioButton3.Checked = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //radioButton3.Checked = false;
            //radioButton1.Checked = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //radioButton2.Checked = false;
            //radioButton1.Checked = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            EmployeeHomepage w2 = new EmployeeHomepage(username,username[0]);
            w2.Show();
            this.Hide();
        }
    }
}
