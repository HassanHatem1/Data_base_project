﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Project
{
    public partial class EditProduct : Form
    {
        string username;
        DataTable dt;
        DataTable dt1;
        Controller ControllerObj = new Controller();
        public EditProduct(string usernamec)
        {
            InitializeComponent();
            username = usernamec;
            dt = ControllerObj.SelectAllProdcuts();
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;
            dataGridView1.Refresh();
            Product_List.DataSource = dt;
            Product_List.DisplayMember = "Name";
            Product_List.ValueMember = "Product ID";
            Product_List.Refresh();
            dt1 = ControllerObj.SelectAllProdcuts();
            
        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void PhonenumberTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void Product_List_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //call delete function
            string id = Product_List.SelectedValue.ToString();
            int r = ControllerObj.DeleteProduct(id);
            if (r > 0)
            {
                MessageBox.Show("Product Deleted");
                dt = ControllerObj.SelectAllProdcuts();
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                Product_List.DataSource = dt;
                Product_List.DisplayMember = "Name";
                Product_List.ValueMember = "Product ID";
                Product_List.Refresh();
                dt1 = ControllerObj.SelectAllProdcuts();
            }
            else
                MessageBox.Show("Product Not Deleted");
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            AddProduct button = new AddProduct(username);
            button.Show();
            this.Hide();
        }

        private void Viewdatabutton_Click(object sender, EventArgs e)
        {
            Discriptiontextbox.Text = dt1.Rows[Product_List.SelectedIndex]["Description"].ToString();
            PricetextBox.Text = dt1.Rows[Product_List.SelectedIndex]["Price"].ToString();
            AmountinstocktextBox.Text = dt1.Rows[Product_List.SelectedIndex]["Amount in stock"].ToString();
            ProductionCosttextBox.Text = dt1.Rows[Product_List.SelectedIndex]["Production Cost"].ToString();

        }

        private void updatedata_Click(object sender, EventArgs e)
        {
            //call Add function
            int idistance;
            float fdistance;
            if (Discriptiontextbox.Text == "")
            {
                MessageBox.Show("Please Enter Product Description");
                return;
            }
            else if (PricetextBox.Text == "")
            {
                MessageBox.Show("Please Enter Product Price");
                return;
            }
            else if (AmountinstocktextBox.Text == "")
            {
                MessageBox.Show("Please Enter Product Amount in stock");
                return;
            }
            else if (ProductionCosttextBox.Text == "")
            {
                MessageBox.Show("Please Enter Product Production Cost");
                return;
            }
            else if (!(float.TryParse(PricetextBox.Text, out fdistance)))
            {
                MessageBox.Show("Product Price must be a number");
                return;
            }
            else if (!(int.TryParse(AmountinstocktextBox.Text, out idistance)))
            {
                MessageBox.Show("Amount in stock must be an integer");
                return;
            }
            else if (!(int.TryParse(ProductionCosttextBox.Text, out idistance)))
            {
                MessageBox.Show("Product Production Cost must be a number");
                return;
            }
            else
            {
                string name = Product_List.Text;
                string id = Product_List.SelectedValue.ToString();
                float price = float.Parse(PricetextBox.Text);
                int Amountinstock = Convert.ToInt32(AmountinstocktextBox.Text);
                int Productioncost = Convert.ToInt32(ProductionCosttextBox.Text);
                string Discription = Discriptiontextbox.Text;
                int r = ControllerObj.UpdateProduct(id, name, Discription, price, Amountinstock, Productioncost);

                if (r > 0)
                {
                    MessageBox.Show("Product Updated");
                    dt = ControllerObj.SelectAllProdcuts();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                    Product_List.DataSource = dt;
                    Product_List.DisplayMember = "Name";
                    Product_List.ValueMember = "Product ID";
                    Product_List.Refresh();
                    dt1 = ControllerObj.SelectAllProdcuts();
                }
                else
                    MessageBox.Show("Product Not Updated");
            }
            }

        private void Reffreshdata_Click(object sender, EventArgs e)
        {
            dt = ControllerObj.SelectAllProdcuts();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            Product_List.DataSource = dt;
            Product_List.DisplayMember = "Name";
            Product_List.ValueMember = "Product ID";
            Product_List.Refresh();
            dt1 = ControllerObj.SelectAllProdcuts();
        }

        private void PricetextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EmployeeHomepage h1 = new EmployeeHomepage(username,'p');
            h1.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            welcome newform = new welcome();
            newform.Show();
            this.Hide();
        }
    }
}
