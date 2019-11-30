﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
                lblLastName.Text = languages.LastName;
                btnAdd.Text = languages.Add;
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = txtLastName.Text
            };
            users.Add(u);
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter writer = new StreamWriter(saveFileDialog1.OpenFile());

                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        writer.WriteLine(listBox1.Items[i].ToString());
                    }
                    writer.Close();
                    myStream.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                if (listBox1.Items.Count >= 1)
                {
                    if (listBox1.SelectedValue != null)
                    {
                        var items = (List<User>)listBox1.DataSource;

                        var item = (User)listBox1.SelectedValue;
                        listBox1.DataSource = null;
                        listBox1.Items.Clear();
                        items.Remove(item);
                        listBox1.DataSource = items;
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("No ITEMS Found");
                }
        }
    }
}
