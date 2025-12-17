using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Blackjack
{
    public partial class MainWindow : Window
    {
        // Deck (laat zoals je hebt, met pack-URI's)
        private readonly Card[] _deck = new Card[]
        {
            // CLUBS
            new Card { ImageUrl="pack://application:,,,/Images/cards/clubs_A.png", Value=new[] {1,11}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/clubs_2.png", Value=new[] {2}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/clubs_3.png", Value=new[] {3}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/clubs_4.png", Value=new[] {4}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/clubs_5.png", Value=new[] {5}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/clubs_6.png", Value=new[] {6}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/clubs_7.png", Value=new[] {7}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/clubs_8.png", Value=new[] {8}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/clubs_9.png", Value=new[] {9}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/clubs_10.png", Value=new[] {10}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/clubs_J.png", Value=new[] {10}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/clubs_Q.png", Value=new[] {10}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/clubs_K.png", Value=new[] {10}},
            // DIAMONDS
            new Card { ImageUrl="pack://application:,,,/Images/cards/diamonds_A.png", Value=new[] {1,11}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/diamonds_2.png", Value=new[] {2}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/diamonds_3.png", Value=new[] {3}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/diamonds_4.png", Value=new[] {4}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/diamonds_5.png", Value=new[] {5}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/diamonds_6.png", Value=new[] {6}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/diamonds_7.png", Value=new[] {7}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/diamonds_8.png", Value=new[] {8}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/diamonds_9.png", Value=new[] {9}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/diamonds_10.png", Value=new[] {10}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/diamonds_J.png", Value=new[] {10}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/diamonds_Q.png", Value=new[] {10}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/diamonds_K.png", Value=new[] {10}},
            // HEARTS
            new Card { ImageUrl="pack://application:,,,/Images/cards/hearts_A.png", Value=new[] {1,11}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/hearts_2.png", Value=new[] {2}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/hearts_3.png", Value=new[] {3}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/hearts_4.png", Value=new[] {4}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/hearts_5.png", Value=new[] {5}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/hearts_6.png", Value=new[] {6}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/hearts_7.png", Value=new[] {7}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/hearts_8.png", Value=new[] {8}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/hearts_9.png", Value=new[] {9}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/hearts_10.png", Value=new[] {10}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/hearts_J.png", Value=new[] {10}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/hearts_Q.png", Value=new[] {10}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/hearts_K.png", Value=new[] {10}},
            // SPADES
            new Card { ImageUrl="pack://application:,,,/Images/cards/spades_A.png", Value=new[] {1,11}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/spades_2.png", Value=new[] {2}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/spades_3.png", Value=new[] {3}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/spades_4.png", Value=new[] {4}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/spades_5.png", Value=new[] {5}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/spades_6.png", Value=new[] {6}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/spades_7.png", Value=new[] {7}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/spades_8.png", Value=new[] {8}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/spades_9.png", Value=new[] {9}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/spades_10.png", Value=new[] {10}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/spades_J.png", Value=new[] {10}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/spades_Q.png", Value=new[] {10}},
            new Card { ImageUrl="pack://application:,,,/Images/cards/spades_K.png", Value=new[] {10}},
        };

        private readonly Random _rnd = new Random();
        private int _botScore = 0;
        private int _playerScore = 0;

        public class Card
        {
            public string ImageUrl { get; set; } = "";
            public int[] Value { get; set; } = Array.Empty<int>();
        }

        public MainWindow()
        {
            InitializeComponent();

            Play.Visibility = Visibility.Hidden;
            PlayLabel.Visibility = Visibility.Hidden;
            PlayText.Visibility = Visibility.Hidden;
            CardButton.Visibility = Visibility.Hidden;
            StopButton.Visibility = Visibility.Hidden;

            CardImage1.Visibility = Visibility.Hidden;
            CardImage2.Visibility = Visibility.Hidden;
            PlayerCard1.Visibility = Visibility.Hidden;
            PlayerCard2.Visibility = Visibility.Hidden;

            LoseBack.Visibility = Visibility.Hidden;
            LoseText.Visibility = Visibility.Hidden;
            WonBack.Visibility = Visibility.Hidden;
            WonText.Visibility = Visibility.Hidden;
        }

        // Kies 11 voor Aas als het past, anders 1
        private int GetCardPoints(Card card, bool isPlayer)
        {
            if (card.Value.Length == 2)
            {
                int low = card.Value[0];
                int high = card.Value[1];
                int current = isPlayer ? _playerScore : _botScore;
                return (current + high <= 21) ? high : low;
            }
            return card.Value[0];
        }

        private Card DrawRandomCard() => _deck[_rnd.Next(_deck.Length)];

        private void Start(object sender, RoutedEventArgs e)
        {
            // reset scores
            _botScore = 0;
            _playerScore = 0;
            Botscore.Text = "0";
            Playerscore.Text = "0";

            Play.Visibility = Visibility.Visible;
            PlayLabel.Visibility = Visibility.Visible;
            PlayText.Visibility = Visibility.Visible;

            CardImage1.Visibility = Visibility.Visible;
            CardImage2.Visibility = Visibility.Visible;
            PlayerCard1.Visibility = Visibility.Visible;
            PlayerCard2.Visibility = Visibility.Visible;

            // Bot krijgt 2 kaarten
            var b1 = DrawRandomCard();
            CardImage1.Source = new BitmapImage(new Uri(b1.ImageUrl, UriKind.Absolute));
            _botScore += GetCardPoints(b1, isPlayer: false);

            var b2 = DrawRandomCard();
            CardImage2.Source = new BitmapImage(new Uri(b2.ImageUrl, UriKind.Absolute));
            _botScore += GetCardPoints(b2, isPlayer: false);

            Botscore.Text = _botScore.ToString();
            CardValueText.Text = _botScore.ToString(); // centrale teller
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            CardButton.Visibility = Visibility.Visible;
            StopButton.Visibility = Visibility.Visible;

            Play.Visibility = Visibility.Hidden;
            PlayLabel.Visibility = Visibility.Hidden;
            PlayText.Visibility = Visibility.Hidden;

            // Speler krijgt 2 kaarten
            var p1 = DrawRandomCard();
            PlayerCard1.Source = new BitmapImage(new Uri(p1.ImageUrl, UriKind.Absolute));
            _playerScore += GetCardPoints(p1, isPlayer: true);

            var p2 = DrawRandomCard();
            PlayerCard2.Source = new BitmapImage(new Uri(p2.ImageUrl, UriKind.Absolute));
            _playerScore += GetCardPoints(p2, isPlayer: true);

            Playerscore.Text = _playerScore.ToString();
        }

        private void CardButton_Click(object sender, RoutedEventArgs e)
        {
            // Extra kaart voor speler
            var next = DrawRandomCard();
            PlayerCard2.Source = new BitmapImage(new Uri(next.ImageUrl, UriKind.Absolute));
            _playerScore += GetCardPoints(next, isPlayer: true);
            Playerscore.Text = _playerScore.ToString();
        }
    }
}