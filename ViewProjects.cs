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
    public partial class ViewProjects : Form
    {
        DataTable dt;
        Controller controllerobj;
        Manager m;
        string username;
        public ViewProjects()
        {
            InitializeComponent();
           
        }
        public ViewProjects(string us,string projectname)
        {
            InitializeComponent();
            username = us;
            m = new Manager(username);
            controllerobj = new Controller();
            dt = new DataTable();
            dt = controllerobj.GetProjectDetails(projectname);
            dataGridView1.DataSource = dt;
        }
        private void ViewProjects_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            m.Show();
            this.Close();
        }
    }
}
