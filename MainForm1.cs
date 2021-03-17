using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class MainForm1 : Form
    {
        void get_Info(ListView List)
        {
            string query = "select article.author, article.name, article.tag, article.stat from article;";
            MySqlConnection conn = DB.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            MySqlDataReader rd;
            try
            {
                conn.Open();
                rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        string[] row = { rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetString(3) };
                        var listViewItem = new ListViewItem(row);
                        list.Items.Add(listViewItem);
                    }
                }
                conn.Close();
                list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }
            public MainForm1()
        {
            InitializeComponent();
            get_Info(list);
            this.FormClosing += Items_FormClosing;
        }

        private void Items_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void closebutton_MouseEnter(object sender, EventArgs e)
        {
            closebutton.ForeColor = Color.White;
        }

        private void closebutton_MouseLeave(object sender, EventArgs e)
        {
            closebutton.ForeColor = Color.Gold;
        }

        Point lastPoint;
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void addstat_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddStat addStat = new AddStat();
            addStat.Show();
        }

        private void refreshList_Click(object sender, EventArgs e)
        {
            list.Items.Clear();
            get_Info(list);
        }

    }
}
