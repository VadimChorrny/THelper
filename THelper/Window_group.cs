using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace THelper
{
    public partial class Window_group : Form
    {

        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=THelper.mdb";
        private OleDbConnection connection;
        int l_num = 0;
        string day_name = "";
        int panel = 0;
        public Window_group(int first, string second)
        {
            InitializeComponent();
            timer1.Start();
            connection = new OleDbConnection(connectString);
            connection.Open();
            l_num = first;
            panel = first;
            day_name = second;
            set_first(l_num, day_name);
            for (int i = 1; i <= 16; i++)
            {
                comboBox1.Items.Add(i + " " + "группа");
            }
            set_text(l_num);
        }

                                                                                ////|           |////
                                                                                ////|  ФУНКЦИИ  |////
                                                                                ////|           |////

        public void set_first(int l_num, string day_name)
        {
            string query = String.Format("SELECT g_num FROM g_day WHERE " + day_name + " = " + l_num + " ");
            OleDbCommand command = new OleDbCommand(query, connection);
            string group = "";

            try
            {
                group = command.ExecuteScalar().ToString();
                comboBox1.Text = group + " группа";
            }
            catch
            {
                comboBox1.Text = "Выбрать";
            }

            if (group != "")
            {
                visible(Convert.ToInt16(group), 0);
            }
        }
        public void visible(int group, int verif)
        {
            TextBox[] txt = { txt_1, txt_2, txt_3, txt_4, txt_5, txt_6, txt_7, txt_8, txt_9, txt_10, txt_11, txt_12, txt_13, txt_14, txt_15, txt_16, txt_17, txt_18, txt_19, txt_20, txt_21, txt_22, txt_23, txt_24, txt_25, txt_26, txt_27, txt_28, txt_29, txt_30, txt_31, txt_32 };
            Panel[] pan = { p_1, p_2, p_3, p_4, p_5, p_6, p_7, p_8, p_9, p_10, p_11, p_12, p_13, p_14, p_15, p_16, p_17, p_18, p_19, p_20, p_21, p_22, p_23, p_24, p_25, p_26, p_27, p_28, p_29, p_30, p_31, p_32 };
            Label[] label = { l_1, l_2, l_3, l_4, l_5, l_6, l_7, l_8, l_9, l_10, l_11, l_12, l_13, l_14, l_15, l_16, l_17, l_18, l_19, l_20, l_21, l_22, l_23, l_24, l_25, l_26, l_27, l_28, l_29, l_30, l_31, l_32 };

            int number_of_panels = 0;
            string query = "SELECT s_num FROM " + "g_" + group + " WHERE visible = 1";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader num = command.ExecuteReader();
            while (num.Read())
            {
                number_of_panels = Convert.ToInt16(num[0]);
            }

            if (verif == 1)
            {
                pan[number_of_panels].Visible = txt[number_of_panels].Visible = label[number_of_panels].Visible = false;
            }

            if(verif == 2)
            {
                for (int i = 0; i < 32; i++)
                {
                    pan[i].Visible = txt[i].Visible = label[i].Visible = false;
                }
            }

            for (int i = 0; i < number_of_panels; i++)
            {
                pan[i].Visible = txt[i].Visible = label[i].Visible = true;
            }
        }

        public void add(int group)
        {
            int number_of_panels = 0;
            string query = "SELECT s_num FROM " + "g_" + group + " WHERE visible = 1";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader num = command.ExecuteReader();
            while (num.Read())
            {
                number_of_panels = Convert.ToInt16(num[0]);
            }
            number_of_panels += 1;
            if (number_of_panels <= 32)
            {
                query = "UPDATE g_" + group + " SET visible = 1 WHERE s_num = " + number_of_panels + " ";
                command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }

            visible(Convert.ToInt16(group), 0);
        }

        public void remove(int group)
        {
            int number_of_panels = 0;
            string query = "SELECT s_num FROM " + "g_" + group + " WHERE visible = 1";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader num = command.ExecuteReader();
            while (num.Read())
            {
                number_of_panels = Convert.ToInt16(num[0]);
            }
            if (number_of_panels <= 32)
            {
                query = "UPDATE g_" + group + " SET visible = 0 WHERE s_num = " + number_of_panels + " ";
                command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }

            visible(Convert.ToInt16(group), 1);
        }

        public void set_text(int group)
        {
            TextBox[] txt = { txt_1, txt_2, txt_3, txt_4, txt_5, txt_6, txt_7, txt_8, txt_9, txt_10, txt_11, txt_12, txt_13, txt_14, txt_15, txt_16, txt_17, txt_18, txt_19, txt_20, txt_21, txt_22, txt_23, txt_24, txt_25, txt_26, txt_27, txt_28, txt_29, txt_30, txt_31, txt_32 };
            
            string query = "SELECT s_name FROM g_"+ group +" WHERE visible = 1";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader text = command.ExecuteReader();
            int counter = 0;
            while (text.Read())
            {
                txt[counter].Text = Convert.ToString(text[0]);
                counter += 1;
            }

        }

        public void save_text(int group)
        {
            TextBox[] txt = { txt_1, txt_2, txt_3, txt_4, txt_5, txt_6, txt_7, txt_8, txt_9, txt_10, txt_11, txt_12, txt_13, txt_14, txt_15, txt_16, txt_17, txt_18, txt_19, txt_20, txt_21, txt_22, txt_23, txt_24, txt_25, txt_26, txt_27, txt_28, txt_29, txt_30, txt_31, txt_32 };

            string query = "SELECT s_num FROM g_"+ group +" WHERE visible = 1";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader id = command.ExecuteReader();
            int num_of_text_boxes = 0;
            while (id.Read())
            {
                num_of_text_boxes = Convert.ToInt16(id[0]);
            }
            id.Close();
            for (int i = 0; i <= num_of_text_boxes - 1; i++)
            {
                int counter = i + 1;
                string query_date = String.Format("UPDATE g_"+ group +" SET s_name = '{0}' WHERE s_num = " + counter + "", txt[i].Text);
                command = new OleDbCommand(query_date, connection);
                command.ExecuteNonQuery();
            }
        }

        public void fix(int l_num)
        {
            string query = "UPDATE g_day SET " + day_name + " = 0 WHERE " + day_name + " = " + panel + " ";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.ExecuteNonQuery();

            query = "UPDATE g_day SET " + day_name + " = " + panel + " WHERE g_num = " + l_num + " ";
            command = new OleDbCommand(query, connection);
            command.ExecuteNonQuery();
        }


                                                                            ////|                     |////
                                                                            ////|  ЭЛЕМЕНТЫ И ТАЙМЕРЫ |////
                                                                            ////|                     |////

        private void button2_Click(object sender, EventArgs e)     //закрытие окна
        {

            timer2.Start();
        }

        private void Dock_panel_MouseDown(object sender, MouseEventArgs e)
        {
            dock_panel.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            string txt = "";
            try
            {
                txt = comboBox1.SelectedItem.ToString();
            }
            catch
            {
                txt = comboBox1.Text;
            }
            txt = txt.Replace(" группа", "");
            if (txt != "Выбрать")
            {
                l_num = Convert.ToInt16(txt);
                add(l_num);
                set_text(l_num);
            }
        }

        private void Delet_Click(object sender, EventArgs e)
        {
            string txt = "";
            try
            {
                txt = comboBox1.SelectedItem.ToString();
            }
            catch
            {
                txt = comboBox1.Text;
            }
            txt = txt.Replace(" группа", "");
            if (txt != "Выбрать")
            {
                l_num = Convert.ToInt16(txt);
                remove(l_num);
            }
        }

        private void ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string txt = comboBox1.SelectedItem.ToString();
            txt = txt.Replace(" группа", "");
            l_num = Convert.ToInt16(txt);
            visible(l_num, 2);
            set_text(l_num);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.1;

            if(this.Opacity == 1)
            {
                timer1.Enabled = false;
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;

            if(this.Opacity == 0)
            {
                this.Close();
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string txt = "";
            try
            {
                txt = comboBox1.SelectedItem.ToString();
            }
            catch
            {
                txt = comboBox1.Text;
            }
            txt = txt.Replace(" группа", "");
            if (txt != "Выбрать")
            {
                l_num = Convert.ToInt16(txt);
                save_text(l_num);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string txt = "";
            try
            {
                txt = comboBox1.SelectedItem.ToString();
            }
            catch
            {
                txt = comboBox1.Text;
            }
            txt = txt.Replace(" группа", "");
            if (txt != "Выбрать")
            {
                l_num = Convert.ToInt16(txt);
                fix(l_num);
            }

        }
    }
}
