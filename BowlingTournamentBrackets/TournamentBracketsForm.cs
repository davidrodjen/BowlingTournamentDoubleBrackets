using BowlingTournamentBrackets.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BowlingTournamentBrackets
{
    public partial class TournamentBracketsForm : Form
    {
        // VS Code Generated this Field
        private List<string> _tourneyFile;
        private string[,] _tournament;

        private const int _playerName = 0; // just a different variable name, constants not necessary
        private const int _scoreGame1 = 1;
        private const int _scoreGame2 = 2;
        private const int _scoreGame3 = 3;


        private int FirstPlayerData { get; set; }
        private int SecondPlayerData { get; set; }
        private int ThirdPlayerData { get; set; }
        private int FourthPlayerData { get; set; }
        private int FifthPlayerData { get; set; }
        private int SixthPlayerData { get; set; }
        private int SeventhPlayerData { get; set; }
        private int EightPlayerData { get; set; }

        /// <summary>
        /// Pulls and splits the data on the Text file in the resource folder
        /// </summary>
        public TournamentBracketsForm()
        {
            InitializeComponent();
            _tourneyFile = new List<string>();

            string filePath = Resources.tournament;

            string[] file = filePath.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (string line in file)
            {
                string[] lineAsArray = line.Split(' ');

                foreach (string item in lineAsArray)
                {
                    _tourneyFile.Add(item);
                }
            }
        }

        private void TournamentBracketsForm_Load(object sender, EventArgs e)
        {
            int line = 8;
            int lineItems = 4;

            string[,] tourneyArray = new string[line, lineItems];

            // File list index as iterator to process for loop
            int fileListIndex = 0;

            for ( int row = 0; row < line; row++)
            {
                for (int col = 0; col < lineItems; col++)
                {
                    tourneyArray[row, col] = _tourneyFile[fileListIndex];
                    fileListIndex++;
                }
            }

            _tournament = tourneyArray;

        }

        private void createTournamentBtn_Click(object sender, EventArgs e)
        {
            

            // List to store all assigned players for randomization
            List<int> addIdNum = new List<int>();

            // Add an IDNUM to each player row to aid in identifying the player data
            FirstPlayerData = GetPlayer(addIdNum);
            SecondPlayerData = GetPlayer(addIdNum);
            ThirdPlayerData = GetPlayer(addIdNum);
            FourthPlayerData = GetPlayer(addIdNum);
            FifthPlayerData = GetPlayer(addIdNum);
            SixthPlayerData = GetPlayer(addIdNum);
            SeventhPlayerData = GetPlayer(addIdNum);
            EightPlayerData = GetPlayer(addIdNum);

            // Get the values from the rows and add them directly as text to the text boxes as the string values
            G1P1txt.Text = $"{_tournament[FirstPlayerData, _playerName]} {_tournament[FirstPlayerData, _scoreGame1]}";
            G1P2txt.Text = $"{_tournament[SecondPlayerData, _playerName]} {_tournament[SecondPlayerData, _scoreGame1]}";
            G1P3txt.Text = $"{_tournament[ThirdPlayerData, _playerName]} {_tournament[ThirdPlayerData, _scoreGame1]}";
            G1P4txt.Text = $"{_tournament[FourthPlayerData, _playerName]} {_tournament[FourthPlayerData, _scoreGame1]}";
            G1P5txt.Text = $"{_tournament[FifthPlayerData, _playerName]} {_tournament[FifthPlayerData, _scoreGame1]}";
            G1P6txt.Text = $"{_tournament[SixthPlayerData, _playerName]} {_tournament[SixthPlayerData, _scoreGame1]}";
            G1P7txt.Text = $"{_tournament[SeventhPlayerData, _playerName]} {_tournament[SeventhPlayerData, _scoreGame1]}";
            G1P8txt.Text = $"{_tournament[EightPlayerData, _playerName]} {_tournament[EightPlayerData, _scoreGame1]}";

            // The winner of game1Winner1 is the storage variable
            // That passes to the second bracket
            int firstGameWinner1;
            int firstGameWinner2;
            int firstGameWinner3;
            int firstGameWinner4;

            // This is for the first Bracket of Games
            // P1 vs P2
            // If player one wins
            if (Convert.ToInt32(_tournament[FirstPlayerData, _scoreGame1]) > Convert.ToInt32(_tournament[SecondPlayerData, _scoreGame1]))
            {
                // set text into the text box as the string value
                G2P1txt.Text = $"{_tournament[FirstPlayerData, _playerName]} {_tournament[FirstPlayerData, _scoreGame2]}";
                // stores value of player that wins into the variable
                firstGameWinner1 = FirstPlayerData;
            }
            else // player two wins
            {
                G2P1txt.Text = $"{_tournament[SecondPlayerData, _playerName]} {_tournament[SecondPlayerData, _scoreGame2]}";
                firstGameWinner1 = SecondPlayerData;
            }

            // P3 vs P4
            // If player three wins
            if (Convert.ToInt32(_tournament[ThirdPlayerData, _scoreGame1]) > Convert.ToInt32(_tournament[FourthPlayerData, _scoreGame1]))
            {
                G2P2txt.Text = $"{_tournament[ThirdPlayerData, _playerName]} {_tournament[ThirdPlayerData, _scoreGame2]}";
                firstGameWinner2 = ThirdPlayerData;
            }
            else // player four wins
            {
                G2P2txt.Text = $"{_tournament[FourthPlayerData, _playerName]} {_tournament[FourthPlayerData, _scoreGame2]}";
                firstGameWinner2 = FourthPlayerData;
            }

            // P5 vs P6
            // If player five wins
            if (Convert.ToInt32(_tournament[FifthPlayerData, _scoreGame1]) > Convert.ToInt32(_tournament[SixthPlayerData, _scoreGame1]))
            {
                G2P3txt.Text = $"{_tournament[FifthPlayerData, _playerName]} {_tournament[FifthPlayerData, _scoreGame2]}";
                firstGameWinner3 = FifthPlayerData;
            }
            else // player six wins
            {
                G2P3txt.Text = $"{_tournament[SixthPlayerData, _playerName]} {_tournament[SixthPlayerData, _scoreGame2]}";
                firstGameWinner3 = SixthPlayerData;
            }

            // P7 vs P8
            // If player seven wins
            if (Convert.ToInt32(_tournament[SeventhPlayerData, _scoreGame1]) > Convert.ToInt32(_tournament[EightPlayerData, _scoreGame1]))
            {
                G2P4txt.Text = $"{_tournament[SeventhPlayerData, _playerName]} {_tournament[SeventhPlayerData, _scoreGame2]}";
                firstGameWinner4 = SeventhPlayerData;
            }
            else // player eight wins
            {
                G2P4txt.Text = $"{_tournament[EightPlayerData, _playerName]} {_tournament[EightPlayerData, _scoreGame2]}";
                firstGameWinner4 = EightPlayerData;
            }


            //SECOND BRACKET

            // The winner of game2Winner1 is the storage variable
            // That passes to the third bracket
            int secondGameWinner1;
            int secondGameWinner2;

            // Game 2 bracket 1 winner vs Game 2 bracket 2 winner
            if (Convert.ToInt32(_tournament[firstGameWinner1, _scoreGame2]) > Convert.ToInt32(_tournament[firstGameWinner2, _scoreGame2]))
            {
                G3P1txt.Text = $"{_tournament[firstGameWinner1, _playerName]} {_tournament[firstGameWinner1, _scoreGame3]}";
                secondGameWinner1 = firstGameWinner1;
            }
            else
            {
                G3P1txt.Text = $"{_tournament[firstGameWinner2, _playerName]} {_tournament[firstGameWinner2, _scoreGame3]}";
                secondGameWinner1 = firstGameWinner2;
            }

            // Game 2 bracket 3 winner vs Game 2 bracket 4 winner
            if (Convert.ToInt32(_tournament[firstGameWinner3, _scoreGame2]) > Convert.ToInt32(_tournament[firstGameWinner4, _scoreGame2]))
            {
                G3P2txt.Text = $"{_tournament[firstGameWinner3, _playerName]} {_tournament[firstGameWinner3, _scoreGame3]}";
                secondGameWinner2 = firstGameWinner3;
            }
            else
            {
                G3P2txt.Text = $"{_tournament[firstGameWinner4, _playerName]} {_tournament[firstGameWinner4, _scoreGame3]}";
                secondGameWinner2 = firstGameWinner4;

            }


            // THIRD BRACKET *WINNER*

            int firstPlaceWinner;
            int secondPlaceWinner;

            if (Convert.ToInt32(_tournament[secondGameWinner1, _scoreGame3]) > Convert.ToInt32(_tournament[secondGameWinner2, _scoreGame3]))
            {
                firstPlaceWinner = secondGameWinner1;
                secondPlaceWinner = secondGameWinner2;
            }
            else
            {
                firstPlaceWinner = secondGameWinner2;
                secondPlaceWinner = secondGameWinner1;
            }

            // Display winners
            firstPlacetxt.Text = $"{_tournament[firstPlaceWinner, _playerName]} $25";
            secondPlacetxt.Text = $"{_tournament[secondPlaceWinner, _playerName]} $10";

        }


        /// <summary>
        /// Method that pulls and assigns and random number variable
        /// as an ID and assigns to the Player so that it can be 
        /// assigned as a random number variable.
        /// </summary>
        /// <param name="addIdNum"></param>
        /// <returns></returns>
        private int GetPlayer(List<int> addIdNum)
        {
            Random rand = new Random();

            bool cont = true;
            int playerNumber = -1;

            while (cont)
            {
                // Generate a random number from 0 - 7
                int num = rand.Next(0, 8);

                // If that number hasn't been assigned, assign it to playerNumber
                // and return it.
                if (!addIdNum.Contains(num))
                {
                    addIdNum.Add(num);
                    cont = false;
                    playerNumber = num;
                }
                else
                {
                    cont = true;
                }
            }

            return playerNumber;
        }
    }
}
