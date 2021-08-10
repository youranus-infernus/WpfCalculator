using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        string leftOperand = "";
        string operation = "";
        string rightOperand = "";

        public MainWindow()
        {
            InitializeComponent();
            
            foreach (UIElement c in LayoutRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string s = (string)((Button)e.OriginalSource).Content;
           
            textBlock.Text += s;
            int num;
            
            bool result = Int32.TryParse(s, out num);
           
            if (result == true)
            {
                if (operation == "")
                {
                    leftOperand += s;
                }
                else
                {
                    rightOperand += s;
                }
            }
            else
            {
                if (s == "=")
                {
                    Update_RightOp();
                    textBlock.Text += rightOperand;
                    operation = "";
                }
                else if (s == "CLEAR")
                {
                    leftOperand = "";
                    rightOperand = "";
                    operation = "";
                    textBlock.Text = "";
                }
                else
                {
                    if (rightOperand != "")
                    {
                        Update_RightOp();
                        leftOperand = rightOperand;
                        rightOperand = "";
                    }
                    operation = s;
                }
            }
        }
        private void Update_RightOp()
        {
            int num1 = Int32.Parse(leftOperand);
            int num2 = Int32.Parse(rightOperand);
            switch (operation)
            {
                case "+":
                    rightOperand = (num1 + num2).ToString();
                    break;
                case "-":
                    rightOperand = (num1 - num2).ToString();
                    break;
                case "*":
                    rightOperand = (num1 * num2).ToString();
                    break;
                case "/":
                    rightOperand = (num1 / num2).ToString();
                    break;
            }
        }
    }
}
