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
    public partial class AddStat : Form
    {
        public AddStat()
        {
            InitializeComponent();

            author.Text = "Введите автора";
            author.ForeColor = Color.Gray;

            name.Text = "Введите название";
            name.ForeColor = Color.Gray;

            tag.Text = "Введите тэги";
            tag.ForeColor = Color.Gray;

            stat.Text = "Напишите статью";
            stat.ForeColor = Color.Gray;
        }

        private void author_Enter(object sender, EventArgs e)
        {
            if (author.Text == "Введите автора")
            {
                author.Text = "";
                author.ForeColor = Color.Black;
            }
        }

        private void author_Leave(object sender, EventArgs e)
        {
            if (author.Text == "")
            {
                author.Text = "Введите автора";
                author.ForeColor = Color.Gray;
            }
        }

        private void name_Enter(object sender, EventArgs e)
        {
            if (name.Text == "Введите название")
            {
                name.Text = "";
                name.ForeColor = Color.Black;
            }
        }

        private void name_Leave(object sender, EventArgs e)
        {
            if (name.Text == "")
            {
                name.Text = "Введите название";
                name.ForeColor = Color.Gray;
            }
        }

        private void tag_Enter(object sender, EventArgs e)
        {
            if (tag.Text == "Введите тэги")
            {
                tag.Text = "";
                tag.ForeColor = Color.Black;
            }
        }

        private void tag_Leave(object sender, EventArgs e)
        {
            if (tag.Text == "")
            {
                tag.Text = "Введите тэги";
                tag.ForeColor = Color.Gray;
            }
        }

        private void stat_Enter(object sender, EventArgs e)
        {
            if (stat.Text == "Напишите статью")
            {
                stat.Text = "";
                stat.ForeColor = Color.Black;
            }
        }

        private void stat_Leave(object sender, EventArgs e)
        {
            if (stat.Text == "")
            {
                stat.Text = "Напишите статью";
                stat.ForeColor = Color.Gray;
            }
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

        private void backmain_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm1 mainForm1 = new MainForm1();
            mainForm1.Show();
        }

        private void buttonaddstat_Click(object sender, EventArgs e)
        {
            if (author.Text == "Введите автора")
            {
                MessageBox.Show("Введите автора");
                return;
            }

            if (name.Text == "Введите название")
            {
                MessageBox.Show("Введите название");
                return;
            }

            if (tag.Text == "Введите тэги")
            {
                MessageBox.Show("Введите тэги");
                return;
            }

            if (stat.Text == "Напишите статью")
            {
                MessageBox.Show("Напишите статью");
                return;
            }

            string query = "insert into article(author, name, tag, stat) values('" + author.Text + "', '" + name.Text + "', '" + tag.Text + "', '" + stat.Text + "');";
            MySqlConnection conn = DB.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                conn.Close();
                MessageBox.Show("Статья была создана.");
                this.Hide();
                MainForm1 mainForm1 = new MainForm1();
                mainForm1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Статья была не создана.");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
