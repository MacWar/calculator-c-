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

namespace kalkulator
{
    enum Operacja
    {
        brak=0,
        dodawanie,odejmowanie,mnozenie,dzielenie,wynik
    }

    public partial class MainWindow : Window
    {
        void wlDzialania()
        {
            buttonDodac.IsEnabled = true;
            buttonDzielic.IsEnabled = true;
            buttonKropka.IsEnabled = true;
            //buttonLodwrotna.IsEnabled = true;
            buttonMnozyc.IsEnabled = true;
            buttonOdjac.IsEnabled = true;
            //buttonWynik.IsEnabled = true;
            //buttonCzyscic.IsEnabled = true;
        }
        void wylDzialania()
        {
            buttonDodac.IsEnabled = false;
            buttonDzielic.IsEnabled = false;
            buttonKropka.IsEnabled = false;
            //buttonLodwrotna.IsEnabled = false;
            buttonMnozyc.IsEnabled = false;
            buttonOdjac.IsEnabled = false;
            //buttonWynik.IsEnabled = false;
           // buttonCzyscic.IsEnabled = false;
        }
            private bool CzyKropka(string doSprawdzenia)
        {
            bool temp = false;
            for (int i = 0; i < doSprawdzenia.Length; i++)
            {
                if (doSprawdzenia[i] == ',')
                {
                    temp = true;
                }
            }
            return temp;
        }
        private Operacja ostatnia = Operacja.brak;
        public MainWindow()
        {
            InitializeComponent();
            wylDzialania();
        }

        private void buttonClickNumer(object sender, RoutedEventArgs e)
        {
            buttonWynik.IsEnabled = true;
            if(textbox2.Text=="")
            wlDzialania();
            button0.IsEnabled = true;
            Button temp = (Button)sender;
         
            if (textBox1.Text != "")
                buttonKropka.IsEnabled = true;
           
            if (CzyKropka(textBox1.Text))
            {
                buttonKropka.IsEnabled = false;
            }
            if (!CzyKropka(textBox1.Text))
                buttonKropka.IsEnabled = true;
            if (Operacja.wynik == ostatnia)
            {
                ostatnia = Operacja.brak;
                textBox1.Text = "";
            }
            textBox1.Text += temp.Content.ToString();
        }

        private void buttonClickKropka(object sender, RoutedEventArgs e)
        {
            
            buttonKropka.IsEnabled = false;
            if (Operacja.wynik == ostatnia)
            {
                textBox1.Text = "";
                ostatnia = Operacja.brak;
            }
            textBox1.Text += ",";
        }

        private void buttonClickCzysc(object sender, RoutedEventArgs e)
        {
            //if(textBox1.Text!="")
            //    wlDzialania();
            wylDzialania();
            textBox1.Text = "";
            textbox2.Text = "";
            textboxOper.Text = "";
            ostatnia = Operacja.brak;
            buttonKropka.IsEnabled = false;
        }

        private void buttonClickDzialanie(object sender, RoutedEventArgs e)
        {
            wylDzialania();
          
            buttonWynik.IsEnabled = false;

            if ((ostatnia != Operacja.brak) || (ostatnia != Operacja.wynik))
            {
                Button temp = (Button)sender;
                if (temp.Content.ToString() == "+")
                {
                    ostatnia = Operacja.dodawanie;
                }
                if (temp.Content.ToString() == "-")
                {
                    ostatnia = Operacja.odejmowanie;
                }
                if (temp.Content.ToString() == "*")
                {
                    ostatnia = Operacja.mnozenie;
                }
                if (temp.Content.ToString() == "/")
                {
                    button0.IsEnabled = false;
                    ostatnia = Operacja.dzielenie;
                }
                textbox2.Text = textBox1.Text;
                textboxOper.Text = temp.Content.ToString();
                textBox1.Text = "";
            }
        }

        private void buttonClickWynik(object sender, RoutedEventArgs e)
        {
         
            
            if (textBox1.Text != "")
                wlDzialania();
            buttonKropka.IsEnabled = false;
            button0.IsEnabled = true;
            if (ostatnia==Operacja.dodawanie) 
            {
                textBox1.Text = (double.Parse(textbox2.Text) + double.Parse(textBox1.Text)).ToString();
            }
            if (ostatnia == Operacja.odejmowanie)
            {
                textBox1.Text = (double.Parse(textbox2.Text) - double.Parse(textBox1.Text)).ToString();
            }
            if (ostatnia == Operacja.mnozenie)
            {
                textBox1.Text = (double.Parse(textbox2.Text) * double.Parse(textBox1.Text)).ToString();
            }
            if (ostatnia == Operacja.dzielenie)
            {
                textBox1.Text = (double.Parse(textbox2.Text) / double.Parse(textBox1.Text)).ToString();
            }
            ostatnia = Operacja.wynik;
            textboxOper.Text = "";
            textbox2.Text = "";
        }
        int flagaOdwrot = 1;
        private void butttonClickodwrotna(object sender, RoutedEventArgs e)
        {
            

            if (textBox1.Text != "")
            {
                if (textBox1.Text[0] != '-')
                {
                    if (flagaOdwrot == 1)
                        textBox1.Text = "-" + textBox1.Text;
                }
                else
                    textBox1.Text = textBox1.Text.Remove(0, 1);
            }
            if(textBox1.Text!="")
                flagaOdwrot *= -1;
        }
    }
}