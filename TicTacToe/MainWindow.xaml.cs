using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace TicTacToe
{
    public partial class MainWindow
    {

        int players;

        public MainWindow()
            : base()
        {
            this.InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            players = 1;
        }

        private void win(string baton)
        {
            if ((button1.Content == baton & button2.Content == baton & button3.Content == baton)
                | (button1.Content == baton & button4.Content == baton & button7.Content == baton)
                | (button1.Content == baton & button5.Content == baton & button9.Content == baton)
                | (button2.Content == baton & button5.Content == baton & button8.Content == baton)
                | (button3.Content == baton & button6.Content == baton & button9.Content == baton)
                | (button4.Content == baton & button5.Content == baton & button6.Content == baton)
                | (button7.Content == baton & button8.Content == baton & button9.Content == baton)
                | (button3.Content == baton & button5.Content == baton & button7.Content == baton))
            {
                if (baton == "O")
                {

                    MessageBox.Show("Нолики победили");

                }
                else if (baton == "X")
                {
                    MessageBox.Show("Крестики победили");

                }
                if (players == 1)
                    players = 2;
                else
                    players = 1;
                buttons.IsEnabled = false;
            }

            else
            {
                foreach (Button noone in buttons.Children)
                {
                    if (noone.IsEnabled == true)
                        return;
                }
                MessageBox.Show("Ничья");
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button baton = sender as Button;
            if (players == 1)
            {
                baton.Content = "X";
                bot("O");

            }
            else
            {
                baton.Content = "O";
                bot("X");
            }
            baton.IsEnabled = false;
            win(baton.Content.ToString());
/*            players += 1;
            if (players >2)
            {
                players = 1;
            }*/

        }
        private void bot(string xo)
        {

            Button baton = new Button { };
            Random random = new Random();
            if (baton.IsEnabled == true)
            {
            int ind = random.Next(buttons.Children.Count);
            (buttons.Children[ind] as Button).Content = xo;
            buttons.Children[ind].IsEnabled = false;
            }



        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button baton in buttons.Children)
            {
                buttons.IsEnabled = true;
                baton.Content = "";
                baton.IsEnabled = true;

            }


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}