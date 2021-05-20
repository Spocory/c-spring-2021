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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum selection
        {
            empty,
            X,
            O
        }

        public bool player1;
        private selection[] scoring;
        private bool ended;

        public MainWindow()
        {
            InitializeComponent();
            player1 = true;
            scoring = new selection[9];
            uxGrid.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Content = null;
                    for (var i = 0; i < scoring.Length; i++)
                        scoring[i] = selection.empty;

                });
           
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);
         

            if (player1)
            {
                if (button.Content is null)
                {
                    
                    scoring[index] = selection.X;
                    button.Content = "X";
                    player1 = false;
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (button.Content is null)
                {
                    scoring[index] = selection.O;
                    button.Content = 'O';
                    player1 = true;
                }
                else
                {
                    return;
                 }
            }
            CheckWinner();
           
        }

        private void CheckWinner()
        {
            if (scoring[0] != selection.empty &&(scoring[0] & scoring[1] & scoring[2]) == scoring[0])
            {
                MessageBox.Show("Winner!");
                NewGame();
            }
            if (scoring[3] != selection.empty && (scoring[3] & scoring[4] & scoring[5]) == scoring[3])
            {
                MessageBox.Show("Winner!");
                NewGame();
            }
            if (scoring[6] != selection.empty && (scoring[6] & scoring[7] & scoring[8]) == scoring[6])
            {
                MessageBox.Show("Winner!");
                NewGame();
            }
            if (scoring[0] != selection.empty && (scoring[0] & scoring[4] & scoring[8]) == scoring[0])
            {
                MessageBox.Show("Winner!");
                NewGame();
            }
            if (scoring[2] != selection.empty && (scoring[2] & scoring[4] & scoring[6]) == scoring[2])
            {
                MessageBox.Show("Winner!");
                NewGame();
            }
            if (scoring[0] != selection.empty && (scoring[0] & scoring[3] & scoring[6]) == scoring[0])
            {
                MessageBox.Show("Winner!");
                NewGame();
            }
            if (scoring[1] != selection.empty && (scoring[1] & scoring[4] & scoring[7]) == scoring[1])
            {
                MessageBox.Show("Winner!");
                NewGame();
            }
            if (scoring[2] != selection.empty && (scoring[2] & scoring[5] & scoring[8]) == scoring[2])
            {
                MessageBox.Show("Winner!");
                NewGame();
            }
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private void NewGame()
        {
            foreach (Button B in uxGrid.Children)
            {
                B.Content = null;
                player1 = true;
            }
            
            for (var i = 0; i < scoring.Length; i++)
                scoring[i] = selection.empty;
        }
    }
}
