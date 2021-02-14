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
        System.Windows.Thickness default_first_player_name_place;
        public MainWindow()
        {
            InitializeComponent();
            //Create window to viewers
            ViewPanel viewPanel = new ViewPanel();
            viewPanel.Show();
            //Get default coord-s to switch sides
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(ViewPanel))
                {
                    default_first_player_name_place = (window as ViewPanel).Player1_Name_small.Margin;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        
        public void UpdateAll() //...views
        {
            //Update ViewPanel elements
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(ViewPanel))
                {
                    //SWITCH SIDES
                    if( ((window as ViewPanel).Player1_Name_small.Margin == default_first_player_name_place)  && ( game.LeftSide().Name() == game.Player_2().Name() ) )
                    {
                        System.Windows.Thickness buffer = (window as ViewPanel).Player1_Name_small.Margin;
                        (window as ViewPanel).Player1_Name_small.Margin = (window as ViewPanel).Player2_Name_small.Margin;
                        (window as ViewPanel).Player2_Name_small.Margin = buffer;

                        buffer = (window as ViewPanel).Player1_ball.Margin;
                        (window as ViewPanel).Player1_ball.Margin = (window as ViewPanel).Player2_ball.Margin;
                        (window as ViewPanel).Player2_ball.Margin = buffer;

                        buffer = (window as ViewPanel).player1_score.Margin;
                        (window as ViewPanel).player1_score.Margin = (window as ViewPanel).player2_score.Margin;
                        (window as ViewPanel).player2_score.Margin = buffer;
                    }
                    if (((window as ViewPanel).Player2_Name_small.Margin == default_first_player_name_place) && (game.LeftSide().Name() == game.Player_1().Name()))
                    {
                        System.Windows.Thickness buffer = (window as ViewPanel).Player2_Name_small.Margin;
                        (window as ViewPanel).Player2_Name_small.Margin = (window as ViewPanel).Player1_Name_small.Margin;
                        (window as ViewPanel).Player1_Name_small.Margin = buffer;

                        buffer = (window as ViewPanel).Player2_ball.Margin;
                        (window as ViewPanel).Player2_ball.Margin = (window as ViewPanel).Player1_ball.Margin;
                        (window as ViewPanel).Player1_ball.Margin = buffer;

                        buffer = (window as ViewPanel).player2_score.Margin;
                        (window as ViewPanel).player2_score.Margin = (window as ViewPanel).player1_score.Margin;
                        (window as ViewPanel).player1_score.Margin = buffer;
                    }
                    //THE END OF SWITCH SIDES. Next scores and other
                    (window as ViewPanel).Set10.Content = game.result[0, 0]; (window as ViewPanel).Set11.Content = game.result[1, 0];
                    (window as ViewPanel).Set20.Content = game.result[0, 1]; (window as ViewPanel).Set21.Content = game.result[1, 1];
                    (window as ViewPanel).Set30.Content = game.result[0, 2]; (window as ViewPanel).Set31.Content = game.result[1, 2];
                    (window as ViewPanel).Set40.Content = game.result[0, 3]; (window as ViewPanel).Set41.Content = game.result[1, 3];
                    (window as ViewPanel).Set50.Content = game.result[0, 4]; (window as ViewPanel).Set51.Content = game.result[1, 4];
                    if (game.Winner() != "Nothing")
                    {
                        (window as ViewPanel).winner_place.Content = game.Winner() + "is WINNER!";
                    }
                    if (game.Ball() == 1)
                    {
                        (window as ViewPanel).Player1_ball.IsChecked = true;
                        (window as ViewPanel).Player2_ball.IsChecked = false;
                    }
                    if (game.Ball() == 2)
                    {
                        (window as ViewPanel).Player1_ball.IsChecked = false;
                        (window as ViewPanel).Player2_ball.IsChecked = true;
                    }
                    if (game.Advantage() == game.Player_1().Name())
                    {
                        (window as ViewPanel).player1_score.Content = "AD";
                        (window as ViewPanel).player2_score.Content = game.Player_2().Score(0);
                    }
                    else if (game.Advantage() == game.Player_2().Name())
                    {
                        (window as ViewPanel).player1_score.Content = game.Player_1().Score(0);
                        (window as ViewPanel).player2_score.Content = "AD";
                    }
                    else
                    {
                        (window as ViewPanel).player1_score.Content = game.Player_1().Score(0);
                        (window as ViewPanel).player2_score.Content = game.Player_2().Score(0);
                    }
                }
            }

            //Update main elements
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
        //Game Creation
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            game = new TennisGame(First_Player.Text, Second_Player.Text);
            Player_1_Up.IsEnabled = true;
            Player_2_Up.IsEnabled = true;
            Player1_Name1.Content = game.Player_1().Name();
            Player1_Name2.Content = game.Player_1().Name();
            Player2_Name1.Content = game.Player_2().Name();
            Player2_Name2.Content = game.Player_2().Name();
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(ViewPanel))
                {
                    (window as ViewPanel).Player1_Name_small.Content = game.Player_1().Name();
                    (window as ViewPanel).Player2_Name_small.Content = game.Player_2().Name();
                }
            }
            UpdateAll();
        }

        //First player UPSCORE
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            game.UpRound(game.Player_1());
            UpdateAll();
        }

        //Second player UPSCORE
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            game.UpRound(game.Player_2());
            UpdateAll();
        }
    }
}
