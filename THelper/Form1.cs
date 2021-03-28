using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THelper
{
    public partial class Form1 : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=THelper.mdb";
        private OleDbConnection connection;
        public Form1()
        {
            InitializeComponent();
            timer2.Start();
            connection = new OleDbConnection(connectString);
            connection.Open();
            get_lessons();
            set_chart();
        }

                                                                            ////|           |////
                                                                            ////|  ФУНКЦИИ  |////
                                                                            ////|           |////

        public string day_name = "Monday";
        public int x_location_f = 0;
        public int x_location_n = 0;
        public void visible(int id)
        {
            Panel[] pans = { pan_1, pan_2, pan_3, pan_4, pan_5, pan_6, pan_7, pan_8, pan_9, pan_10, pan_11, pan_12, pan_13, pan_14, pan_15, pan_16 };
            Label[] times = { time_1, time_2, time_3, time_4, time_5, time_6, time_7, time_8, time_9, time_10, time_11, time_12, time_13, time_14, time_15, time_16 };
            Label[] subs = { sub_1, sub_2, sub_3, sub_4, sub_5, sub_6, sub_7, sub_8, sub_9, sub_10, sub_11, sub_12, sub_13, sub_14, sub_15, sub_16 };
            TextBox[] text_boxes = { txt_1, txt_2, txt_3, txt_4, txt_5, txt_6, txt_7, txt_8, txt_9, txt_10, txt_11, txt_12, txt_13, txt_14, txt_15, txt_16 };
            TextBox[] text_boxes2 = { txt_1_1, txt_2_2, txt_3_3, txt_4_4, txt_5_5, txt_6_6, txt_7_7, txt_8_8, txt_9_9, txt_10_10, txt_11_11, txt_12_12, txt_13_13, txt_14_14, txt_15_15, txt_16_16 };
            Label[] group = { g_1, g_2, g_3, g_4, g_5, g_6, g_7, g_8, g_9, g_10, g_11, g_12, g_13, g_14, g_15, g_16 };
            for (int i = 0; i <= id; i++)
            {
                try
                {
                    pans[i].Visible = times[i].Visible = subs[i].Visible = text_boxes[i].Visible = text_boxes2[i].Visible = group[i].Visible = true;
                }
                catch
                {

                }
            }
        }
        public void unvisible(int id)
        {
            Panel[] pans = { pan_1, pan_2, pan_3, pan_4, pan_5, pan_6, pan_7, pan_8, pan_9, pan_10, pan_11, pan_12, pan_13, pan_14, pan_15, pan_16 };
            Label[] times = { time_1, time_2, time_3, time_4, time_5, time_6, time_7, time_8, time_9, time_10, time_11, time_12, time_13, time_14, time_15, time_16 };
            Label[] subs = { sub_1, sub_2, sub_3, sub_4, sub_5, sub_6, sub_7, sub_8, sub_9, sub_10, sub_11, sub_12, sub_13, sub_14, sub_15, sub_16 };
            TextBox[] text_boxes = { txt_1, txt_2, txt_3, txt_4, txt_5, txt_6, txt_7, txt_8, txt_9, txt_10, txt_11, txt_12, txt_13, txt_14, txt_15, txt_16 };
            TextBox[] text_boxes2 = { txt_1_1, txt_2_2, txt_3_3, txt_4_4, txt_5_5, txt_6_6, txt_7_7, txt_8_8, txt_9_9, txt_10_10, txt_11_11, txt_12_12, txt_13_13, txt_14_14, txt_15_15, txt_16_16 };
            Label[] group = { g_1, g_2, g_3, g_4, g_5, g_6, g_7, g_8, g_9, g_10, g_11, g_12, g_13, g_14, g_15, g_16 };
            for (int i = 15; i >= id; i--)
            {
                try
                {
                    pans[i].Visible = times[i].Visible = subs[i].Visible = text_boxes[i].Visible = text_boxes2[i].Visible = group[i].Visible = false;
                    text_boxes[i].Clear();
                    text_boxes2[i].Clear();
                }
                catch
                {

                }
            }
        }

        public void save_text()
        {
            int number_of_panels = 0;
            string query = "SELECT id FROM " + day_name + " WHERE visable = 1";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader id = command.ExecuteReader();
            while (id.Read())
            {
                number_of_panels = Convert.ToInt16(id[0]);
            }
            id.Close();
            TextBox[] text_boxes = { txt_1, txt_2, txt_3, txt_4, txt_5, txt_6, txt_7, txt_8, txt_9, txt_10, txt_11, txt_12, txt_13, txt_14, txt_15, txt_16 };
            TextBox[] text_boxes2 = { txt_1_1, txt_2_2, txt_3_3, txt_4_4, txt_5_5, txt_6_6, txt_7_7, txt_8_8, txt_9_9, txt_10_10, txt_11_11, txt_12_12, txt_13_13, txt_14_14, txt_15_15, txt_16_16 };
            for (int i = 0; i <= number_of_panels - 1; i++)
            {
                int counter = i + 1;
                string query_date = String.Format("UPDATE " + day_name + " SET time_sub = '{0}' WHERE id = " + counter + " ", text_boxes[i].Text);
                string query_sub = String.Format("UPDATE " + day_name + " SET sub = '{0}' WHERE id = " + counter + " ", text_boxes2[i].Text);
                command = new OleDbCommand(query_date, connection);
                command.ExecuteNonQuery();
                command = new OleDbCommand(query_sub, connection);
                command.ExecuteNonQuery();
            }
        }

        public void set_text(int id)
        {
            TextBox[] text_boxes = { txt_1, txt_2, txt_3, txt_4, txt_5, txt_6, txt_7, txt_8, txt_9, txt_10, txt_11, txt_12, txt_13, txt_14, txt_15, txt_16 };
            TextBox[] text_boxes2 = { txt_1_1, txt_2_2, txt_3_3, txt_4_4, txt_5_5, txt_6_6, txt_7_7, txt_8_8, txt_9_9, txt_10_10, txt_11_11, txt_12_12, txt_13_13, txt_14_14, txt_15_15, txt_16_16 };
            string query = "SELECT time_sub FROM " + day_name + " WHERE visable = 1";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader text = command.ExecuteReader();
            int counter = 0;
            while (text.Read())
            {
                text_boxes[counter].Text = Convert.ToString(text[0]);
                counter += 1;
            }
            text.Close();
            query = "SELECT sub FROM " + day_name + " WHERE visable = 1";
            command = new OleDbCommand(query, connection);
            text = command.ExecuteReader();
            counter = 0;
            while (text.Read())
            {
                text_boxes2[counter].Text = Convert.ToString(text[0]);
                counter += 1;
            }
        }

        public void lesson_main()
        {
            string query = "SELECT id FROM " + day_name + " WHERE visable = 1";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader id = command.ExecuteReader();
            int number_of_panels = 0;
            while (id.Read())
            {
                visible(Convert.ToInt16(id[0]) - 1);
                number_of_panels = Convert.ToInt16(id[0]);
            }
            unvisible(number_of_panels);
            set_text(number_of_panels);
            set_group();
            
        }

        public void save_big_text()
        {
            string query = String.Format("UPDATE text_note SET Note_text = '{0}' WHERE id = 12 ", richTextBox1.Text);
            OleDbCommand command = new OleDbCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public void set_big_text()
        {
            string query = "SELECT Note_text FROM text_note WHERE id = 12";
            OleDbCommand command = new OleDbCommand(query, connection);
            richTextBox1.Text = command.ExecuteScalar().ToString();

        }

        public void get_lessons()
        {
            DateTime date = DateTime.Now;
            string dayOfWeek = Convert.ToString(date.DayOfWeek);
            DATA.Text = "Дата: " + DateTime.Now.ToShortDateString();
            if (dayOfWeek != "Sunday")
            {
                string query = "SELECT id FROM " + dayOfWeek + " WHERE visable = 1";
                OleDbCommand command = new OleDbCommand(query, connection);
                OleDbDataReader id = command.ExecuteReader();
                int counter = 0;
                while (id.Read())
                {
                    counter += 1;
                }
                lessons.Text = "Сегодня уроков: " + counter;
            }
            else
            {
                lessons.Text = "Сегодня нет уроков";
            }
        }
        
        public void set_chart()
        {
            String[] day_names_for_chart_EN = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            String[] day_names_for_chart_RU = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота" };
            int[] number_of_lessons_in_all_days = { 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i <= 5; i++)
            {
                string query = "SELECT id FROM " + day_names_for_chart_EN[i] + " WHERE visable = 1";
                OleDbCommand command = new OleDbCommand(query, connection);
                OleDbDataReader id = command.ExecuteReader();
                while (id.Read())
                {
                    number_of_lessons_in_all_days[i] += 1;
                }
            }
            chart1.Series["Уроки"].Points.Clear();
            chart1.Series["Уроки"].Points.AddXY(day_names_for_chart_RU[0], number_of_lessons_in_all_days[0]);
            chart1.Series["Уроки"].Points.AddXY(day_names_for_chart_RU[1], number_of_lessons_in_all_days[1]);
            chart1.Series["Уроки"].Points.AddXY(day_names_for_chart_RU[2], number_of_lessons_in_all_days[2]);
            chart1.Series["Уроки"].Points.AddXY(day_names_for_chart_RU[3], number_of_lessons_in_all_days[3]);
            chart1.Series["Уроки"].Points.AddXY(day_names_for_chart_RU[4], number_of_lessons_in_all_days[4]);
            chart1.Series["Уроки"].Points.AddXY(day_names_for_chart_RU[5], number_of_lessons_in_all_days[5]);
        }

        public void set_group()
        {
            Label[] group = { g_1, g_2, g_3, g_4, g_5, g_6, g_7, g_8, g_9, g_10, g_11, g_12, g_13, g_14, g_15, g_16 };
            string query = "SELECT " + day_name + " FROM g_day";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader text = command.ExecuteReader();
            int counter = 0;
            for(int i = 0; i <= 15; i++)
            {
                group[i].Text = "";
            }
            while (text.Read())
            {
                if (Convert.ToString(text[0]) != "" && Convert.ToString(text[0]) != "0")
                {
                    group[Convert.ToInt16(Convert.ToString(text[0]))-1].Text = counter + 1 + " Группа";
                }
                counter += 1;
            }
        }


                                                                                        ////|                     |////
                                                                                        ////|  ЭЛЕМЕНТЫ И ТАЙМЕРЫ |////
                                                                                        ////|                     |////

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void Button2_Click(object sender, EventArgs e)                     //кнопка уроки
        {
            chart1.Visible = lessons.Visible = DATA.Visible = false;
            save_2.Visible = false;
            cursor.Visible = true;
            richTextBox1.Visible = false;
            mon.Visible = tue.Visible = wedn.Visible = thus.Visible = fri.Visible = sat.Visible = plus.Visible = minus.Visible = save.Visible = true;
            lesson_main();
        }
        private void Button10_Click(object sender, EventArgs e)                     //кнопка +
        {
            int number_of_panels = 0;
            string query = "SELECT id FROM " + day_name + " WHERE visable = 1";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader id = command.ExecuteReader();
            while (id.Read())
            {
                number_of_panels = Convert.ToInt16(id[0]);
            }
            number_of_panels += 1;
            id.Close();
            if (number_of_panels <= 16)
            {
                query = "UPDATE "+ day_name +" SET visable = 1 WHERE id = " + number_of_panels + " ";
                OleDbCommand command_Update = new OleDbCommand(query, connection);
                command_Update.ExecuteNonQuery();
                visible(number_of_panels-1);
            }
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            int number_of_panels = 0;
            string query = "SELECT id FROM " + day_name + " WHERE visable = 1";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader id = command.ExecuteReader();
            while (id.Read())
            {
                number_of_panels = Convert.ToInt16(id[0]);
            }
            if (number_of_panels <= 16)
            {
                query = "UPDATE " + day_name + " SET visable = 0 WHERE id = ? ";
                OleDbCommand command_Update = new OleDbCommand(query, connection);
                command_Update.Parameters.AddWithValue("id", number_of_panels);
                command_Update.ExecuteNonQuery();
                unvisible(number_of_panels-1);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            save_text();
        }

        private void Mon_Click(object sender, EventArgs e)
        {
            day_name = "Monday";
            x_location_f = 584;
            x_location_n = cursor.Location.X;
            timer1.Enabled = true;
            lesson_main();
        }

        private void Tue_Click(object sender, EventArgs e)
        {
            day_name = "Tuesday";
            x_location_f = 624;
            x_location_n = cursor.Location.X;
            timer1.Enabled = true;
            lesson_main();
        }

        private void Wedn_Click(object sender, EventArgs e)
        {
            day_name = "Wednesday";
            x_location_f = 664;
            x_location_n = cursor.Location.X;
            timer1.Enabled = true;
            lesson_main();
        }

        private void Thus_Click(object sender, EventArgs e)
        {
            day_name = "Thursday";
            x_location_f = 704;
            x_location_n = cursor.Location.X;
            timer1.Enabled = true;
            lesson_main();
        }

        private void Fri_Click(object sender, EventArgs e)
        {
            day_name = "Friday";
            x_location_f = 744;
            x_location_n = cursor.Location.X;
            timer1.Enabled = true;
            lesson_main();
        }

        private void Sat_Click(object sender, EventArgs e)
        {
            day_name = "Saturday";
            x_location_f = 784;
            x_location_n = cursor.Location.X;
            timer1.Enabled = true;
            lesson_main();
        }

        private void Button4_Click(object sender, EventArgs e)      // Кнопка для свертывания окна
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)        //анимация для курсора который показывает выбранный день недели
        {
            if (x_location_f - x_location_n > 0)
            {
                cursor.Left += (x_location_f-x_location_n)/8;
            }
            else
            {
                cursor.Left -= (x_location_n-x_location_f)/8;
            }
            if (x_location_f == cursor.Location.X)
            {
                timer1.Enabled = false;
            }
        }

        private void group_Click(object sender, EventArgs e)        //кнопка заметки 
        {
            chart1.Visible = lessons.Visible = DATA.Visible = false;
            mon.Visible = tue.Visible = wedn.Visible = thus.Visible = fri.Visible = sat.Visible = plus.Visible = minus.Visible = save.Visible = false;
            cursor.Visible = false;
            save_2.Visible = true;
            unvisible(0);
            richTextBox1.Visible = true;
            set_big_text();
        }

        private void Save_2_Click(object sender, EventArgs e)
        {
            save_big_text();
        }

        private void main_Click(object sender, EventArgs e)
        {
            mon.Visible = tue.Visible = wedn.Visible = thus.Visible = fri.Visible = sat.Visible = plus.Visible = minus.Visible = save.Visible = cursor.Visible = save_2.Visible = richTextBox1.Visible = false;
            unvisible(0);
            chart1.Visible = true;
            lessons.Visible = true;
            DATA.Visible = true;
            get_lessons();
            set_chart();
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)          //перетаскивание за верхнию панель
        {
            panel1.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void timer2_Tick(object sender, EventArgs e)                    //анимция появления формы
        {
            this.Opacity += 0.1d;
            if(this.Opacity == 1)
            {
                timer2.Enabled = false;
            }
        }

        private void pan_1_Click(object sender, EventArgs e)
        {
            Window_group window = new Window_group(1,day_name);
            window.Show();
        }

        private void Pan_2_Click(object sender, EventArgs e)
        {
            Window_group window = new Window_group(2, day_name);
            window.Show();
        }

        private void Pan_3_Click(object sender, EventArgs e)
        {
            Window_group window = new Window_group(3, day_name);
            window.Show();
        }

        private void Pan_4_Click(object sender, EventArgs e)
        {
            Window_group window = new Window_group(4, day_name);
            window.Show();
        }

        private void Pan_5_Click(object sender, EventArgs e)
        {
            Window_group window = new Window_group(5, day_name);
            window.Show();
        }

        private void Pan_6_Click(object sender, EventArgs e)
        {
            Window_group window = new Window_group(6, day_name);
            window.Show();
        }

        private void Pan_7_Click(object sender, EventArgs e)
        {
            Window_group window = new Window_group(7, day_name);
            window.Show();
        }

        private void Pan_8_Click(object sender, EventArgs e)
        {
            Window_group window = new Window_group(8, day_name);
            window.Show();
        }

        private void Pan_9_Click(object sender, EventArgs e)
        {
            Window_group window = new Window_group(9, day_name);
            window.Show();
        }

        private void Pan_10_Click(object sender, EventArgs e)
        {
            Window_group window = new Window_group(10, day_name);
            window.Show();
        }

        private void Pan_11_Click(object sender, EventArgs e)
        {
            Window_group window = new Window_group(11, day_name);
            window.Show();
        }

        private void Pan_12_Click(object sender, EventArgs e)
        {
            Window_group window = new Window_group(12, day_name);
            window.Show();
        }

        private void Pan_13_Click(object sender, EventArgs e)
        {
            Window_group window = new Window_group(13, day_name);
            window.Show();
        }

        private void Pan_14_Click(object sender, EventArgs e)
        {
            Window_group window = new Window_group(14, day_name);
            window.Show();
        }

        private void Pan_15_Click(object sender, EventArgs e)
        {
            Window_group window = new Window_group(15, day_name);
            window.Show();
        }

        private void Pan_16_Click(object sender, EventArgs e)
        {
            Window_group window = new Window_group(16, day_name);
            window.Show();
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;

            if (this.Opacity == 0)
            {
                Application.Exit();
            }
        }
    }
}
