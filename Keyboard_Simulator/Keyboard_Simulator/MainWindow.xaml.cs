using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Keyboard_Simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int sliderLength;
        int fails;
        int total;
        int time;
        int speed;
        int lineLength;
        DispatcherTimer timer;

        bool change;

        string level1;
        string level2;
        string level3;
        string level4;
        string level5;
        string level6;
        string level7;
        string level8;
        string level9;
        string level10;
        string level11;
        string level12;
        public MainWindow()
        {
            InitializeComponent();

            change = false;

            btn_Stop.IsEnabled = false;
            txtEnteringText.IsReadOnly = true;
            txtGeneratedText.IsReadOnly = true;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += new EventHandler(InputRate);

            lineLength = 60;//длина геренируемой строки
        }

        private void TextDifficultyLevel()
        {
            level1 = " abcde";
            level2 = " abcdefghij";
            level3 = " abcdefghijklmno";
            level4 = " abcdefghijklmnopqrst";
            level5 = " abcdefghijklmnopqrstuvwxyz";
            level6 = " abcdefghijklmnopqrstuvwxyz0123456789";
            level7 = " abcdefghijklmnopqrstuvwxyz0123456789~`!";
            level8 = " abcdefghijklmnopqrstuvwxyz0123456789~`!@#$";
            level9 = " abcdefghijklmnopqrstuvwxyz0123456789~`!@#$%^&";
            level10 = " abcdefghijklmnopqrstuvwxyz0123456789~`!@#$%^&*()_";
            level11 = " abcdefghijklmnopqrstuvwxyz0123456789~`!@#$%^&*()_+=-";
            level12 = " abcdefghijklmnopqrstuvwxyz0123456789~`!@#$%^&*()_+=-:;'\"/[]";
        }
        private void TextDifficultyLevelWithRegistrSymbols()
        {
            level1 = " abcdeABCDE";
            level2 = " abcdefghijABCDEFGHIJ";
            level3 = " abcdefghijklmnoABCDEFGHIJKLMNO";
            level4 = " abcdefghijklmnopqrstABCDEFGHIJKLMNOPQRST";
            level5 = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            level6 = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            level7 = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789~`!";
            level8 = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789~`!@#$";
            level9 = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789~`!@#$%^&";
            level10 = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789~`!@#$%^&*()_";
            level11 = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789~`!@#$%^&*()_+=-";
            level12 = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789~`!@#$%^&*()_+=-:;'\"/[]";
        }

        private void btn_Start_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            total = 0;
            time = 0;
            speed = 0;
            txtSpeed.Text = speed.ToString();
            fails = 0;
            txtFails.Text = fails.ToString();

            txtGeneratedText.Text = "";
            txtEnteringText.Text = "";

            CheckRegisterSymbols();

            DifficultuSetting();

            btn_Start.IsEnabled = false;
            btn_Stop.IsEnabled = true;
            txtEnteringText.IsReadOnly = false;
        }

        private void btn_Stop_Click(object sender, RoutedEventArgs e)
        {
            btn_Stop.IsEnabled = false;
            btn_Start.IsEnabled = true;
            timer.Stop();
        }

        private void GeneratingSymbols(string str)//генерация символов для строки
        {
            int position = 0;
            Random r = new Random();

            for (int i = 0; i < lineLength; i++)
            {
                position = r.Next(0, str.Length - 1);

                txtGeneratedText.Text += str[position];

                if (i == 3 || i == 6 || i == 14 || i == 18 || i == 22 || i == 26 || i == 29 ||
                    i == 35 || i == 40 || i == 43 || i == 47 || i == 51 || i == 54 || i == 60)//разбиваем строку пробелами
                {
                    txtGeneratedText.Text += " ";
                }
            }
        }

        private void CheckRegisterSymbols()//проверка регистра символов
        {
            if (caseSensitive.IsChecked == true)
            {
                TextDifficultyLevelWithRegistrSymbols();
                lineLength = 53;//уменьшаем длину генерируемой строки,что бы все символы вмещались в строку
            }
            else
            {
                TextDifficultyLevel();
            }
        }

        private void DifficultuSetting()
        {
            switch (sliderLength)
            {
                case 1:
                    GeneratingSymbols(level1);
                    break;
                case 2:
                    GeneratingSymbols(level2);
                    break;
                case 3:
                    GeneratingSymbols(level3);
                    break;
                case 4:
                    GeneratingSymbols(level4);
                    break;
                case 5:
                    GeneratingSymbols(level5);
                    break;
                case 6:
                    GeneratingSymbols(level6);
                    break;
                case 7:
                    GeneratingSymbols(level7);
                    break;
                case 8:
                    GeneratingSymbols(level8);
                    break;
                case 9:
                    GeneratingSymbols(level9);
                    break;
                case 10:
                    GeneratingSymbols(level10);
                    break;
                case 11:
                    GeneratingSymbols(level11);
                    break;
                case 12:
                    GeneratingSymbols(level12);
                    break;
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
            sliderLength = (int)slider.Value;
            txtDifficulty.Text = sliderLength.ToString();
        }

        private void txtEnteringText_TextChanged(object sender, TextChangedEventArgs e)
        {
            total++;//кол-во всех введенных символов

            if (txtEnteringText.Text.Length == 1)
            {
                if (txtEnteringText.Text[0] != txtGeneratedText.Text[0])
                    txtEnteringText.Text = txtEnteringText.Text.Remove(txtEnteringText.Text.Length - 1);
                fails++;
                txtFails.Text = fails.ToString();
            }

            if (txtEnteringText.Text.Length == txtGeneratedText.Text.Length)
            {
                btn_Start.IsEnabled = true;
                btn_Stop_Click(sender, e);
                txtEnteringText.IsReadOnly = true;
            }
            else
            {
                if (txtEnteringText.Text.Length > 1)
                {
                    if (txtGeneratedText.Text[txtEnteringText.Text.Length - 1] != txtEnteringText.Text[txtEnteringText.Text.Length - 1])
                    {
                        txtEnteringText.Text = txtEnteringText.Text.Remove(txtEnteringText.Text.Length - 1);
                        fails++;
                        txtFails.Text = fails.ToString();
                    }
                }

            }

            txtEnteringText.Focus();
            txtEnteringText.SelectionStart = txtEnteringText.Text.Length;
        }
        private void InputRate(object sender,EventArgs e)
        {
            time += 2;
            speed = (total * 60) / time;
            txtSpeed.Text = speed.ToString();
        }

        private void Key_Down_Event(object sender, KeyEventArgs e)
        {
            //меняем отображаемые символы
            if ((e.KeyboardDevice.Modifiers == ModifierKeys.Shift) && (e.Key == Key.CapsLock) && change == false)
            {
                btnTilde.Content = "`";
                btn_1.Content = "!";
                btn_2.Content = "@";
                btn_3.Content = "#";
                btn_4.Content = "$";
                btn_5.Content = "%";
                btn_6.Content = "^";
                btn_7.Content = "&";
                btn_8.Content = "*";
                btn_9.Content = "(";
                btn_0.Content = ")";
                btn_Hyphen.Content = "_";
                btn_Equally.Content = "+";

                btn_q.Content = "Q";
                btn_w.Content = "W";
                btn_e.Content = "E";
                btn_r.Content = "R";
                btn_t.Content = "T";
                btn_y.Content = "Y";
                btn_u.Content = "U";
                btn_i.Content = "I";
                btn_o.Content = "O";
                btn_p.Content = "P";
                btn_Left_Square_Bracket.Content = "{";
                btn_Right_Square_Bracket.Content = "}";
                btn_Back_Slash.Content = "|";

                btn_a.Content = "A";
                btn_s.Content = "S";
                btn_d.Content = "D";
                btn_f.Content = "F";
                btn_g.Content = "G";
                btn_h.Content = "H";
                btn_j.Content = "J";
                btn_k.Content = "K";
                btn_l.Content = "L";
                btn_Semicolon.Content = ":";
                btn_Apostrothe.Content = "\"";

                btn_z.Content = "Z";
                btn_x.Content = "X";
                btn_c.Content = "C";
                btn_v.Content = "V";
                btn_b.Content = "B";
                btn_n.Content = "N";
                btn_m.Content = "M";
                btn_Comma.Content = "<";
                btn_Dot.Content = ">";
                btn_Forward_Slash.Content = "?";

                change = true;
            }
            else if ((e.KeyboardDevice.Modifiers == ModifierKeys.Shift) && (e.Key == Key.CapsLock) && change == true)
            {
                btnTilde.Content = "~";
                btn_1.Content = "1";
                btn_2.Content = "2";
                btn_3.Content = "3";
                btn_4.Content = "4";
                btn_5.Content = "5";
                btn_6.Content = "6";
                btn_7.Content = "7";
                btn_8.Content = "8";
                btn_9.Content = "9";
                btn_0.Content = "0";
                btn_Hyphen.Content = "-";
                btn_Equally.Content = "=";

                btn_q.Content = "q";
                btn_w.Content = "w";
                btn_e.Content = "e";
                btn_r.Content = "r";
                btn_t.Content = "t";
                btn_y.Content = "y";
                btn_u.Content = "u";
                btn_i.Content = "i";
                btn_o.Content = "o";
                btn_p.Content = "p";
                btn_Left_Square_Bracket.Content = "[";
                btn_Right_Square_Bracket.Content = "]";
                btn_Back_Slash.Content = "\'";

                btn_a.Content = "a";
                btn_s.Content = "s";
                btn_d.Content = "d";
                btn_f.Content = "f";
                btn_g.Content = "g";
                btn_h.Content = "h";
                btn_j.Content = "j";
                btn_k.Content = "k";
                btn_l.Content = "l";
                btn_Semicolon.Content = ":";
                btn_Apostrothe.Content = "'";

                btn_z.Content = "z";
                btn_x.Content = "x";
                btn_c.Content = "c";
                btn_v.Content = "v";
                btn_b.Content = "b";
                btn_n.Content = "n";
                btn_m.Content = "m";
                btn_Comma.Content = ",";
                btn_Dot.Content = ".";
                btn_Forward_Slash.Content = "/";

                change = false;
            }

            //подстветка клавиатуры
            switch ((int)e.Key)
            {
                case 146:
                    btnTilde.Background = Brushes.Red;
                    break;
                case 34:
                    btn_0.Background = Brushes.Red;
                    break;
                case 35:
                    btn_1.Background = Brushes.Red;
                    break;
                case 36:
                    btn_2.Background = Brushes.Red;
                    break;
                case 37:
                    btn_3.Background = Brushes.Red;
                    break;
                case 38:
                    btn_4.Background = Brushes.Red;
                    break;
                case 39:
                    btn_5.Background = Brushes.Red;
                    break;
                case 40:
                    btn_6.Background = Brushes.Red;
                    break;
                case 41:
                    btn_7.Background = Brushes.Red;
                    break;
                case 42:
                    btn_8.Background = Brushes.Red;
                    break;
                case 43:
                    btn_9.Background = Brushes.Red;
                    break;
                case 143:
                    btn_Hyphen.Background = Brushes.Red;
                    break;
                case 141:
                    btn_Equally.Background = Brushes.Red;
                    break;
                case 2:
                    btn_Backspace.Background = Brushes.Red;
                    break;
                case 3:
                    btn_Tab.Background = Brushes.Red;
                    break;
                case 60:
                    btn_q.Background = Brushes.Red;
                    break;
                case 66:
                    btn_w.Background = Brushes.Red;
                    break;
                case 48:
                    btn_e.Background = Brushes.Red;
                    break;
                case 61:
                    btn_r.Background = Brushes.Red;
                    break;
                case 63:
                    btn_t.Background = Brushes.Red;
                    break;
                case 68:
                    btn_y.Background = Brushes.Red;
                    break;
                case 64:
                    btn_u.Background = Brushes.Red;
                    break;
                case 52:
                    btn_i.Background = Brushes.Red;
                    break;
                case 58:
                    btn_o.Background = Brushes.Red;
                    break;
                case 59:
                    btn_p.Background = Brushes.Red;
                    break;
                case 149:
                    btn_Left_Square_Bracket.Background = Brushes.Red;
                    break;
                case 151:
                    btn_Right_Square_Bracket.Background = Brushes.Red;
                    break;
                case 150:
                    btn_Back_Slash.Background = Brushes.Red;
                    break;
                case 8:
                    btn_Caps_Lock.Background = Brushes.Red;
                    break;
                case 44:
                    btn_a.Background = Brushes.Red;
                    break;
                case 62:
                    btn_s.Background = Brushes.Red;
                    break;
                case 47:
                    btn_d.Background = Brushes.Red;
                    break;
                case 49:
                    btn_f.Background = Brushes.Red;
                    break;
                case 50:
                    btn_g.Background = Brushes.Red;
                    break;
                case 51:
                    btn_h.Background = Brushes.Red;
                    break;
                case 53:
                    btn_j.Background = Brushes.Red;
                    break;
                case 54:
                    btn_k.Background = Brushes.Red;
                    break;
                case 55:
                    btn_l.Background = Brushes.Red;
                    break;
                case 140:
                    btn_Semicolon.Background = Brushes.Red;
                    break;
                case 152:
                    btn_Apostrothe.Background = Brushes.Red;
                    break;
                case 6:
                    btn_Enter.Background = Brushes.Red;
                    break;
                case 116:
                    btn_Shift.Background = Brushes.Red;
                    break;
                case 69:
                    btn_z.Background = Brushes.Red;
                    break;
                case 67:
                    btn_x.Background = Brushes.Red;
                    break;
                case 46:
                    btn_c.Background = Brushes.Red;
                    break;
                case 65:
                    btn_v.Background = Brushes.Red;
                    break;
                case 45:
                    btn_b.Background = Brushes.Red;
                    break;
                case 57:
                    btn_n.Background = Brushes.Red;
                    break;
                case 56:
                    btn_m.Background = Brushes.Red;
                    break;
                case 142:
                    btn_Comma.Background = Brushes.Red;
                    break;
                case 144:
                    btn_Dot.Background = Brushes.Red;
                    break;
                case 145:
                    btn_Forward_Slash.Background = Brushes.Red;
                    break;
                case 117:
                    btn_Shift1.Background = Brushes.Red;
                    break;
                case 118:
                    btn_Ctrl.Background = Brushes.Red;
                    btn_Ctrl1.Background = Brushes.Red;
                    break;
                case 70:
                    btn_Win.Background = Brushes.Red;
                    btn_Win1.Background = Brushes.Red;
                    break;
                case 156:
                    btn_Alt.Background = Brushes.Red;
                    btn_Alt1.Background = Brushes.Red;
                    break;
                case 18:
                    btn_Space.Background = Brushes.Red;
                    break;
            }
        }

        private void Key_Up_Event(object sender, KeyEventArgs e)//подстветка клавиатуры
        {
            switch ((int)e.Key)
            {
                case 146:
                    btnTilde.Background = Brushes.Pink;
                    break;
                case 34:
                    btn_0.Background = Brushes.Yellow;
                    break;
                case 35:
                    btn_1.Background = Brushes.Pink;
                    break;
                case 36:
                    btn_2.Background = Brushes.Pink;
                    break;
                case 37:
                    btn_3.Background = Brushes.Yellow;
                    break;
                case 38:
                    btn_4.Background = Brushes.LightGreen;
                    break;
                case 39:
                    btn_5.Background = Brushes.LightBlue;
                    break;
                case 40:
                    btn_6.Background = Brushes.LightBlue;
                    break;
                case 41:
                    btn_7.Background = Brushes.MediumPurple;
                    break;
                case 42:
                    btn_8.Background = Brushes.MediumPurple;
                    break;
                case 43:
                    btn_9.Background = Brushes.Pink;
                    break;
                case 143:
                    btn_Hyphen.Background = Brushes.LightGreen;
                    break;
                case 141:
                    btn_Equally.Background = Brushes.LightGreen;
                    break;
                case 2:
                    btn_Backspace.Background = Brushes.LightGray;
                    break;
                case 3:
                    btn_Tab.Background = Brushes.LightGray;
                    break;
                case 60:
                    btn_q.Background = Brushes.Pink;
                    break;
                case 66:
                    btn_w.Background = Brushes.Yellow;
                    break;
                case 48:
                    btn_e.Background = Brushes.LightGreen;
                    break;
                case 61:
                    btn_r.Background = Brushes.LightBlue;
                    break;
                case 63:
                    btn_t.Background = Brushes.LightBlue;
                    break;
                case 68:
                    btn_y.Background = Brushes.MediumPurple;
                    break;
                case 64:
                    btn_u.Background = Brushes.MediumPurple;
                    break;
                case 52:
                    btn_i.Background = Brushes.Pink;
                    break;
                case 58:
                    btn_o.Background = Brushes.Yellow;
                    break;
                case 59:
                    btn_p.Background = Brushes.LightGreen;
                    break;
                case 149:
                    btn_Left_Square_Bracket.Background = Brushes.LightGreen;
                    break;
                case 151:
                    btn_Right_Square_Bracket.Background = Brushes.LightGreen;
                    break;
                case 150:
                    btn_Back_Slash.Background = Brushes.LightGreen;
                    break;
                case 8:
                    btn_Caps_Lock.Background = Brushes.LightGray;
                    break;
                case 44:
                    btn_a.Background = Brushes.Pink;
                    break;
                case 62:
                    btn_s.Background = Brushes.Yellow;
                    break;
                case 47:
                    btn_d.Background = Brushes.LightGreen;
                    break;
                case 49:
                    btn_f.Background = Brushes.LightBlue;
                    break;
                case 50:
                    btn_g.Background = Brushes.LightBlue;
                    break;
                case 51:
                    btn_h.Background = Brushes.MediumPurple;
                    break;
                case 53:
                    btn_j.Background = Brushes.MediumPurple;
                    break;
                case 54:
                    btn_k.Background = Brushes.Pink;
                    break;
                case 55:
                    btn_l.Background = Brushes.Pink;
                    break;
                case 140:
                    btn_Semicolon.Background = Brushes.LightGreen;
                    break;
                case 152:
                    btn_Apostrothe.Background = Brushes.LightGreen;
                    break;
                case 6:
                    btn_Enter.Background = Brushes.LightGray;
                    break;
                case 116:
                    btn_Shift.Background = Brushes.LightGray;
                    break;
                case 69:
                    btn_z.Background = Brushes.Pink;
                    break;
                case 67:
                    btn_x.Background = Brushes.Yellow;
                    break;
                case 46:
                    btn_c.Background = Brushes.LightGreen;
                    break;
                case 65:
                    btn_v.Background = Brushes.LightBlue;
                    break;
                case 45:
                    btn_b.Background = Brushes.LightBlue;
                    break;
                case 57:
                    btn_n.Background = Brushes.MediumPurple;
                    break;
                case 56:
                    btn_m.Background = Brushes.MediumPurple;
                    break;
                case 142:
                    btn_Comma.Background = Brushes.Pink;
                    break;
                case 144:
                    btn_Dot.Background = Brushes.Pink;
                    break;
                case 145:
                    btn_Forward_Slash.Background = Brushes.LightGreen;
                    break;
                case 117:
                    btn_Shift1.Background = Brushes.LightGray;
                    break;
                case 118:
                    btn_Ctrl.Background = Brushes.LightGray;
                    btn_Ctrl1.Background = Brushes.LightGray;
                    break;
                case 70:
                    btn_Win.Background = Brushes.LightGray;
                    btn_Win1.Background = Brushes.LightGray;
                    break;
                case 156:
                    btn_Alt.Background = Brushes.LightGray;
                    btn_Alt1.Background = Brushes.LightGray;
                    break;
                case 18:
                    btn_Space.Background = Brushes.SandyBrown;
                    break;
            }
        }

        private void Key_Down_Entering_Text(object sender, KeyEventArgs e)
        {
            Key_Down_Event(sender,e);
        }
    }
}
