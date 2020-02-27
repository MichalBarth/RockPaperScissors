using RockPaperScissors.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private RPSResult _player;
        private RPSResult _computer;
        private int playerScore;
        private int computerScore;

        private Random _rand;

        public MainViewModel()
        {
            Player = RPSResult.None;
            Computer = RPSResult.None;
            playerScore = 0;
            computerScore = 0;
            _rand = new Random();
            Play = new ParametrizedRelayCommand(
                (param) =>
                {
                    if (param is /*RPSResult*/ string)
                    {
                        switch (param)
                        {
                            case /*RPSResult.Rock*/ "1": Player = RPSResult.Rock; break;
                            case "2": Player = RPSResult.Paper; break;
                            case "3": Player = RPSResult.Scissors; break;
                            default: Player = RPSResult.None; break;
                        }
                        Computer = (RPSResult)_rand.Next(3) + 1;
                    }
                    if ((Player == RPSResult.Rock && Computer == RPSResult.Paper) || (Player == RPSResult.Paper && Computer == RPSResult.Scissors) || (Player == RPSResult.Scissors && Computer == RPSResult.Rock))
                    {
                        ComputerScore++;
                    }
                    else if ((Player == RPSResult.Rock && Computer == RPSResult.Scissors) || (Player == RPSResult.Paper && Computer == RPSResult.Rock) || (Player == RPSResult.Scissors && Computer == RPSResult.Paper))
                    {
                        PlayerScore++;
                    }
                },
                (param) => true
            );
        }

        public RPSResult Player
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
                NotifyPropertyChanged();
            }
        }

        public RPSResult Computer
        {
            get
            {
                return _computer;
            }
            set
            {
                _computer = value;
                NotifyPropertyChanged();
            }
        }

        public int PlayerScore
        {
            get
            {
                return playerScore;
            }
            set
            {
                playerScore = value;
                NotifyPropertyChanged();
            }
        }
        public int ComputerScore
        {
            get
            {
                return computerScore;
            }
            set
            {
                computerScore = value;
                NotifyPropertyChanged();
            }
        }

        public ParametrizedRelayCommand Play { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
