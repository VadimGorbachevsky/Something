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
using Tennis.Library;

namespace Tennis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TennisGame game;
        public MainWindow()
        {
            InitializeComponent();
            ViewPanel viewPanel = new ViewPanel();
            viewPanel.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public void UpdateAll()
        {
            Side_1.Content = game.LeftSide().Name();
            Side_2.Content = game.RightSide().Name();
            Set10.Content = game.result[0, 0]; Set11.Content = game.result[1, 0];
            Set20.Content = game.result[0, 1]; Set21.Content = game.result[1, 1];
            Set30.Content = game.result[0, 2]; Set31.Content = game.result[1, 2];
            Set40.Content = game.result[0, 3]; Set41.Content = game.result[1, 3];
            Set50.Content = game.result[0, 4]; Set51.Content = game.result[1, 4];
            if (game.Advantage() == game.Player_1().Name())
            {
                player1_score.Content = "AD";
                player2_score.Content = game.Player_2().Score(0);
            }
            else if (game.Advantage() == game.Player_2().Name())
            {
                player1_score.Content = game.Player_1().Score(0);
                player2_score.Content = "AD";
            }
            else
            {
                player1_score.Content = game.Player_1().Score(0);
                player2_score.Content = game.Player_2().Score(0);
            }
            if (game.Winner() != "Nothing")
            {
                winner_place.Content = game.Winner() + "is WINNER!";
                Player_1_Up.IsEnabled = false;
                Player_2_Up.IsEnabled = false;
            }
            if (game.Ball() == 1)
            {
                Player1_ball.IsChecked = true;
                Player2_ball.IsChecked = false;
            }
            if (game.Ball() == 2)
            {
                Player1_ball.IsChecked = false;
                Player2_ball.IsChecked = true;
            }


        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            game = new TennisGame(First_Player.Text, Second_Player.Text);
            Player_1_Up.IsEnabled = true;
            Player_2_Up.IsEnabled = true;
            Player1_Name1.Content = game.Player_1().Name();
            Player1_Name2.Content = game.Player_1().Name();
            Player2_Name1.Content = game.Player_2().Name();
            Player2_Name2.Content = game.Player_2().Name();
            UpdateAll();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            game.UpRound(game.Player_1());
            UpdateAll();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            game.UpRound(game.Player_2());
            UpdateAll();
        }
    }
}
