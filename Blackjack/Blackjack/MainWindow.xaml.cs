using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Blackjack
{
    public partial class MainWindow : Window
    {
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

        private readonly Image[] _playerSlots;
        private readonly Image[] _botSlots;
        private int _playerCardCount = 0;
        private int _botCardCount = 0;

        public class Card
        {
            public string ImageUrl { get; set; } = "";
            public int[] Value { get; set; } = Array.Empty<int>();
        }

        public MainWindow()
        {
            InitializeComponent();

            _playerSlots = new[]
            {
                PlayerCard1, PlayerCard2, PlayerCard3, PlayerCard4, PlayerCard5, PlayerCard6
            };
            _botSlots = new[]
            {
                CardImage1, CardImage2, CardImage3, CardImage4, CardImage5, CardImage6
            };

            Play.Visibility = Visibility.Hidden;
            PlayLabel.Visibility = Visibility.Hidden;
            PlayText.Visibility = Visibility.Hidden;
            CardButton.Visibility = Visibility.Hidden;
            StopButton.Visibility = Visibility.Hidden;

            HideAllSlots();
            HideResult();

            StopButton.Click += StopButton_Click;
        }

        private void HideAllSlots()
        {
            foreach (var slot in _playerSlots)
            {
                slot.Visibility = Visibility.Hidden;
                slot.Source = null;
            }
            foreach (var slot in _botSlots)
            {
                slot.Visibility = Visibility.Hidden;
                slot.Source = null;
            }
        }

        private void HideResult()
        {
            WonBack.Visibility = Visibility.Hidden;
            WonText.Visibility = Visibility.Hidden;
            LoseBack.Visibility = Visibility.Hidden;
            LoseText.Visibility = Visibility.Hidden;
            TieBack.Visibility = Visibility.Hidden;
            TieText.Visibility = Visibility.Hidden;
        }

        private void ShowWin()
        {
            HideResult();
            WonBack.Visibility = Visibility.Visible;
            WonText.Visibility = Visibility.Visible;
        }

        private void ShowLose()
        {
            HideResult();
            LoseBack.Visibility = Visibility.Visible;
            LoseText.Visibility = Visibility.Visible;
        }

        private void ShowNeutral()
        {
            HideResult();
            TieBack.Visibility = Visibility.Visible;
            TieText.Visibility = Visibility.Visible;
        }

        private void ResetPlayerSlots()
        {
            foreach (var slot in _playerSlots)
            {
                slot.Visibility = Visibility.Hidden;
                slot.Source = null;
            }
            _playerCardCount = 0;
        }

        private void ResetBotSlots()
        {
            foreach (var slot in _botSlots)
            {
                slot.Visibility = Visibility.Hidden;
                slot.Source = null;
            }
            _botCardCount = 0;
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

        private void DealCardToPlayer(Card card)
        {
            if (_playerCardCount >= _playerSlots.Length) return;
            var slot = _playerSlots[_playerCardCount++];
            slot.Source = new BitmapImage(new Uri(card.ImageUrl, UriKind.Absolute));
            slot.Visibility = Visibility.Visible;

            _playerScore += GetCardPoints(card, isPlayer: true);
            Playerscore.Text = _playerScore.ToString();
        }

        private void DealCardToBot(Card card)
        {
            if (_botCardCount >= _botSlots.Length) return;
            var slot = _botSlots[_botCardCount++];
            slot.Source = new BitmapImage(new Uri(card.ImageUrl, UriKind.Absolute));
            slot.Visibility = Visibility.Visible;

            _botScore += GetCardPoints(card, isPlayer: false);
            Botscore.Text = _botScore.ToString();
            CardValueText.Text = _botScore.ToString();
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            _botScore = 0;
            _playerScore = 0;
            Botscore.Text = "0";
            Playerscore.Text = "0";
            CardValueText.Text = "0";

            HideResult();
            ResetPlayerSlots();
            ResetBotSlots();

            Play.Visibility = Visibility.Visible;
            PlayLabel.Visibility = Visibility.Visible;
            PlayText.Visibility = Visibility.Visible;

            CardButton.Visibility = Visibility.Hidden;
            StopButton.Visibility = Visibility.Hidden;

            DealCardToBot(DrawRandomCard());
            DealCardToBot(DrawRandomCard());
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            CardButton.Visibility = Visibility.Visible;
            StopButton.Visibility = Visibility.Visible;

            Play.Visibility = Visibility.Hidden;
            PlayLabel.Visibility = Visibility.Hidden;
            PlayText.Visibility = Visibility.Hidden;

            DealCardToPlayer(DrawRandomCard());
            DealCardToPlayer(DrawRandomCard());

            CheckImmediateBusts();
        }

        private void CardButton_Click(object sender, RoutedEventArgs e)
        {
            DealCardToPlayer(DrawRandomCard());
            CheckImmediateBusts();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            while (_botScore < 17)
            {
                DealCardToBot(DrawRandomCard());
            }

            FinishRound();
        }

        private void CheckImmediateBusts()
        {
            if (_playerScore > 21)
            {
                EndGame(playerWins: false);
            }
        }

        private void FinishRound()
        {
            if (_botScore > 21)
            {
                EndGame(playerWins: true);
                return;
            }

            if (_playerScore > 21)
            {
                EndGame(playerWins: false);
                return;
            }

            if (_playerScore > _botScore)
                EndGame(playerWins: true);
            else if (_playerScore < _botScore)
                EndGame(playerWins: false);
            else
                EndGameNeutral();
        }

        private void EndGame(bool playerWins)
        {
            if (playerWins) ShowWin();
            else ShowLose();
            CardButton.Visibility = Visibility.Hidden;
            StopButton.Visibility = Visibility.Hidden;
        }

        private void EndGameNeutral()
        {
            CardButton.Visibility = Visibility.Hidden;
            StopButton.Visibility = Visibility.Hidden;
            ShowNeutral();
        }
    }
}