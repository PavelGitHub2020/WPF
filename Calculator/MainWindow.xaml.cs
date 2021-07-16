using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lesson2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
   
//Необходимо разработать приложение «Калькулятор»
// В верхней части приложения необходимо использовать два поля для ввода текста.
 //Первое используется для отображения предыдущих операций, а второе — для ввода
//текущего числа.Оба поля должны запрещать редактировать свое содержимое посредством клавиатурного ввода.
//Данные поля будут заполняться автоматически при нажатии на соответствующие кнопки, расположенные ниже.
//Кнопки «0» — «9» добавляют соответствующую цифру в конец текущего числа.
 //При этом должны выполняться проверки, не допускающие неправильного ввода. 
 //Например, нельзя вводить числа, начинающиеся с ноля, после которого нет десятичной точки.
//Кнопка «.» добавляет (если это возможно) десятичную точку в текущее число.
//Кнопки «/», «*», «+», «-» выполняют соответствующую операцию над результатом предыдущей операции
//и текущим числом.
//Кнопка «=» вычисляет выражение и выводит результат.
//Кнопка «CE» очищает текущее число.
//Кнопка «C» очищает текущее число и предыдущее
//выражение.
//Кнопка «<» очищает последний введенный символ
//в текущем числе.

    public partial class MainWindow : Window
    {
        private int latestElement;

        private double result;

        public MainWindow()
        {
            InitializeComponent();

            latestElement = textBox.Text.Length;

            if (textBox.Text.ToString() == "")
            {
                Arithmetic_Signs_Lock();
            }

        }

        private void Lock_Arithmetic_Signs(string s)//Блокировка арифметических знаков
        {
            if (textBox.Text[textBox.Text.Length - 1].ToString() == s)
            {
                switch (s)
                {
                    case "/":
                        btn_Divide.IsEnabled = false;
                        break;
                    case "*":
                        btn_Multiply.IsEnabled = false;
                        break;
                    case "+":
                        btn_Addition.IsEnabled = false;
                        break;
                    case "-":
                        btn_Subtraction.IsEnabled = false;
                        break;
                }
            }
        }

        private void Arithmetic_Signs_Lock()//Состояние доступности арифметических знаков
        {
            btn_Addition.IsEnabled = false;
            btn_Divide.IsEnabled = false;
            btn_Multiply.IsEnabled = false;
            btn_Subtraction.IsEnabled = false;
        }
        private void Arithmetic_Signs_UnLock()//Состояние доступности арифметических знаков
        {
            btn_Addition.IsEnabled = true;
            btn_Divide.IsEnabled = true;
            btn_Multiply.IsEnabled = true;
            btn_Subtraction.IsEnabled = true;
        }
        private void Dot_Lock()//Блокировка точки
        {
            if (textBox.Text == "")
            {
                return;
            }

            if (textBox.Text[textBox.Text.Length - 1].ToString() == ",")
            {
                btn_Dot.IsEnabled = false;
            }
            else
            {
                btn_Dot.IsEnabled = true;
            }
        }

        private void Dot_Lock1()//Блокировка точки
        {
            if (textBox.Text.Length > 1)
            {
                switch (textBox.Text[textBox.Text.Length - 2].ToString())
                {
                    case "/":
                        btn_Dot.IsEnabled = true;
                        break;
                    case "*":
                        btn_Dot.IsEnabled = true;
                        break;
                    case "+":
                        btn_Dot.IsEnabled = true;
                        break;
                    case "-":
                        btn_Dot.IsEnabled = true;
                        break;
                }
            }
        }

        private void Dot_Lock2()//Блокировка точки
        {
            switch (textBox.Text[textBox.Text.Length - 1].ToString())
            {
                case "0":
                    Dot_Lock3();
                    break;
                case "1":
                    Dot_Lock3();
                    break;
                case "2":
                    Dot_Lock3();
                    break;
                case "3":
                    Dot_Lock3();
                    break;
                case "4":
                    Dot_Lock3();
                    break;
                case "5":
                    Dot_Lock3();
                    break;
                case "6":
                    Dot_Lock3();
                    break;
                case "7":
                    Dot_Lock3();
                    break;
                case "8":
                    Dot_Lock3();
                    break;
                case "9":
                    Dot_Lock3();
                    break;
            }
        }

        private void Dot_Lock3()//Блокировка точки
        {
            switch (textBox.Text[textBox.Text.Length - 2].ToString())
            {
                case "/":
                    btn_Dot.IsEnabled = true;
                    break;
                case "*":
                    btn_Dot.IsEnabled = true;
                    break;
                case "+":
                    btn_Dot.IsEnabled = true;
                    break;
                case "-":
                    btn_Dot.IsEnabled = true;
                    break;
            }
        }
        private void Lock_State()//Состояние доступности конопок
        {
            btn_1.IsEnabled = false;
            btn_2.IsEnabled = false;
            btn_3.IsEnabled = false;
            btn_4.IsEnabled = false;
            btn_5.IsEnabled = false;
            btn_6.IsEnabled = false;
            btn_7.IsEnabled = false;
            btn_8.IsEnabled = false;
            btn_9.IsEnabled = false;
            btn_Addition.IsEnabled = false;
            btn_Divide.IsEnabled = false;
            btn_Multiply.IsEnabled = false;
            btn_Result.IsEnabled = false;
            btn_Subtraction.IsEnabled = false;
        }

        private void Unlock_State()//Состояние доступности конопок
        {
            btn_1.IsEnabled = true;
            btn_2.IsEnabled = true;
            btn_3.IsEnabled = true;
            btn_4.IsEnabled = true;
            btn_5.IsEnabled = true;
            btn_6.IsEnabled = true;
            btn_7.IsEnabled = true;
            btn_8.IsEnabled = true;
            btn_9.IsEnabled = true;
            btn_Addition.IsEnabled = true;
            btn_Divide.IsEnabled = true;
            btn_Multiply.IsEnabled = true;
            btn_Result.IsEnabled = true;
            btn_Subtraction.IsEnabled = true;
            
        }
        private void Button_Lock()//Блокировка кнопок
        {
            if (textBox.Text == "")
            {
                return;
            }

            if (textBox.Text[0].ToString() == "0")
            {
                Lock_State();
            }
        }

        private void Button_Lock1()//Блокировка кнопок
        {
            //latestElement = textBox.Text.Length;

            if (textBox.Text[textBox.Text.Length - 1].ToString() == "0")
            {
                if (textBox.Text[textBox.Text.Length - 2].ToString() == "/")
                {
                    Lock_State();
                }
                else if (textBox.Text[textBox.Text.Length - 2].ToString() == "*")
                {
                    Lock_State();
                }
                else if (textBox.Text[textBox.Text.Length - 2].ToString() == "+")
                {
                    Lock_State();
                }
                else if (textBox.Text[textBox.Text.Length - 2].ToString() == "-")
                {
                    Lock_State();
                }
            }
            else
                Unlock_State();
        }

        private void Button_Click_CE(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
        }

        private void Button_Click_C(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
            textBox1.Text = "";
        }

        private void Button_Click_Less(object sender, RoutedEventArgs e)//кнопка удаления <
        {
            if (textBox.Text.Length > 0)
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);

            Button_Click_Less_Lock();

            if (textBox.Text.Length > 1)
            {
                Dot_Lock2();
                Button_Lock1();
            }
            else
            {
                Dot_Lock();
                Button_Lock();
            }
        }

        private void Button_Click_Less_Lock()//блокировка кнопки удаления <
        {
            if (textBox.Text.Length == 0)
            {
                btn_Less.IsEnabled = false;
                return;
            }
            else
                btn_Less.IsEnabled = true;
        }
        private void Button_Click_Divide(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == "")//если поле пустое, арифметический знак не вводим
            {

            }
            else
            {
                textBox.Text += "/";
                Lock_Arithmetic_Signs("/");
            }
        }

        private void Button_Click_Multiply(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == "")
            {

            }
            else
            {
                textBox.Text += "*";
                Lock_Arithmetic_Signs("*");
            }
        }

        private void Button_Click_Subtraction(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == "")
            {

            }
            else
            {
                textBox.Text += "-";
                Lock_Arithmetic_Signs("-");
            }
        }

        private void Button_Click_Addition(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == "")
            {

            }
            else
            {
                textBox.Text += "+";
                Lock_Arithmetic_Signs("+");
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            textBox.Text += "7";
            Dot_Lock1();
            Arithmetic_Signs_UnLock();
            Button_Click_Less_Lock();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            textBox.Text += "8";
            Dot_Lock1();
            Arithmetic_Signs_UnLock();
            Button_Click_Less_Lock();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            textBox.Text += "9";
            Dot_Lock1();
            Arithmetic_Signs_UnLock();
            Button_Click_Less_Lock();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            textBox.Text += "4";
            Dot_Lock1();
            Arithmetic_Signs_UnLock();
            Button_Click_Less_Lock();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            textBox.Text += "5";
            Dot_Lock1();
            Arithmetic_Signs_UnLock();
            Button_Click_Less_Lock();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            textBox.Text += "6";
            Dot_Lock1();
            Arithmetic_Signs_UnLock();
            Button_Click_Less_Lock();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            textBox.Text += "1";
            Dot_Lock1();
            Arithmetic_Signs_UnLock();
            Button_Click_Less_Lock();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            textBox.Text += "2";
            Dot_Lock1();
            Arithmetic_Signs_UnLock();
            Button_Click_Less_Lock();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            textBox.Text += "3";
            Dot_Lock1();
            Arithmetic_Signs_UnLock();
            Button_Click_Less_Lock();
        }

        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            textBox.Text += "0";

            if (textBox.Text.Length > 1)
                btn_Dot.IsEnabled = true;

            if (textBox.Text.Length == 1)
                Button_Lock();
            else
                Button_Lock1();

            Arithmetic_Signs_UnLock();
            Button_Click_Less_Lock();
        }

        private void Button_Click_Dot(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == "")
                textBox.Text = "";
            else
            {
                textBox.Text += ".";
                Dot_Lock();
                Unlock_State();
                Arithmetic_Signs_Lock();
            }
        }

        private void Button_Click_Result(object sender, RoutedEventArgs e)
        {
            textBox1.Text = textBox.Text;

            Result();
        }

        private void Result()
        {
            result = 0;

            try
            {
                string rez = textBox.Text.ToString();
                result = Convert.ToDouble(new DataTable().Compute(rez, null));
                textBox.Text = result.ToString();
            }
            catch
            {
                MessageBox.Show("Error!Please,enter a valid expression!");
            }
            
        }
    }
}
