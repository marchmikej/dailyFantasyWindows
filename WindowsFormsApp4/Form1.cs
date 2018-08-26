using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {

        List<Player> players = new List<Player>();

        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void sbtButton_Click(object sender, EventArgs e)
        {
            if(radioRotoGrinders.Checked)
            {
                radioGrindersMLB();
            } else if(radioNumberFire.Checked)
            {
                radioNumFireMLB();
            }

        }

        private void radioNumFireMLB()
        {
            String mlbFile = txtHTML.Text;
            int playerLocal = mlbFile.IndexOf("<a class=\"full\" href=");
            txtHTML.Text = "";
            while (playerLocal > 0)
            {
                mlbFile = mlbFile.Substring(playerLocal + 2);

                //Player Name Start
                int locStart = mlbFile.IndexOf(">");
                int locEnd = mlbFile.IndexOf("<");
                String playerName = mlbFile.Substring(locStart + 1, locEnd - locStart - 1);
                mlbFile = mlbFile.Substring(locEnd + 3);
                String lastName = "";
                String firstName = "";
                playerName = playerName.Trim();
                int spaceName = playerName.IndexOf(" ");
                if (spaceName > 0)
                {
                    lastName = playerName.Substring(spaceName + 1);
                    firstName = playerName.Substring(0, spaceName);
                }
                else
                {
                    lastName = playerName;
                }
                //Player Name End

                //Position Start
                locStart = mlbFile.IndexOf("<span class=\"player-info--position");
                mlbFile = mlbFile.Substring(locStart + 5);
                locStart = mlbFile.IndexOf(">");
                locEnd = mlbFile.IndexOf("<");
                String playerPosition = mlbFile.Substring(locStart + 1, locEnd - locStart - 1);
                if(playerPosition.Contains("C") || playerPosition.Contains("1B"))
                {
                    playerPosition = "C-1B";
                }
                //Position End 

                //Projected Points Start
                locStart = mlbFile.IndexOf("<td class=\"fp active\">");
                mlbFile = mlbFile.Substring(locStart + 10);
                locStart = mlbFile.IndexOf(">");
                locEnd = mlbFile.IndexOf("<");
                String playerPointsString = mlbFile.Substring(locStart + 1, locEnd - locStart - 1);
                playerPointsString = playerPointsString.Replace(" ", "");
                playerPointsString = playerPointsString.Replace("\n", "");
                double playerPoints = Double.Parse(playerPointsString);
                //Projected Points End

                //Salary Start
                locStart = mlbFile.IndexOf("<td class=\"cost\"");
                mlbFile = mlbFile.Substring(locStart + 2);
                locStart = mlbFile.IndexOf(">");
                locEnd = mlbFile.IndexOf("<");
                String playerFanDuelSalaryString = mlbFile.Substring(locStart + 1, locEnd - locStart - 1);
                playerFanDuelSalaryString = playerFanDuelSalaryString.Replace(" ", "");
                playerFanDuelSalaryString = playerFanDuelSalaryString.Replace(",", "");
                playerFanDuelSalaryString = playerFanDuelSalaryString.Replace("\n", "");
                playerFanDuelSalaryString = playerFanDuelSalaryString.Replace("$", "");
                int playerFanDuelSalary = Int32.Parse(playerFanDuelSalaryString);
                //Salary End

                txtHTML.Text = txtHTML.Text + " " + lastName + ", " + firstName + " position: " + playerPosition + " projected: " + playerPoints + " Salary: " + playerFanDuelSalary.ToString() + "\n";

                Player thisPlayer = new Player();
                thisPlayer.lastName = lastName;
                thisPlayer.firstName = firstName;
                thisPlayer.fanDuelCost = playerFanDuelSalary;
                thisPlayer.numberfireFanDuelProjection = playerPoints;
                thisPlayer.position = playerPosition;

                //players.Add(thisPlayer);

                UpdatePlayerList(thisPlayer);

                playerLocal = mlbFile.IndexOf("<a class=\"full\" href=");
            }
        }

        private void radioGrindersMLB()
        {
            String mlbFile = txtHTML.Text;
            int playerLocal = mlbFile.IndexOf("<a class=\"player-popup\" data-url=\"https://rotogrinders.com");
            txtHTML.Text = "";
            while (playerLocal>0)
            {
                mlbFile = mlbFile.Substring(playerLocal + 2);
                //Player Name Start
                int locStart = mlbFile.IndexOf(">");
                int locEnd = mlbFile.IndexOf("<");
                String playerName = mlbFile.Substring(locStart + 1, locEnd - locStart - 1);
                String lastName = "";
                String firstName = "";
                int spaceName = playerName.IndexOf(" ");
                if(spaceName > 0)
                {
                    lastName = playerName.Substring(spaceName + 1);
                    firstName = playerName.Substring(0, spaceName);
                } else
                {
                    lastName = playerName;
                }
                //txtHTML.Text = txtHTML.Text + "\n" + playerName;
                mlbFile = mlbFile.Substring(locEnd + 12);
                //Player Name End
                
                //Player Position Start
                locStart = mlbFile.IndexOf("<span class=\"position\">");
                mlbFile = mlbFile.Substring(locStart + 2);
                locStart = mlbFile.IndexOf(">");
                locEnd = mlbFile.IndexOf("<");
                String playerPosition = mlbFile.Substring(locStart + 1, locEnd - locStart - 1);
                playerPosition = playerPosition.Replace(" ", "");
                playerPosition = playerPosition.Replace("\n", "");
                if (playerPosition.Contains("C") || playerPosition.Contains("1B"))
                {
                    playerPosition = "C-1B";
                }
                //txtHTML.Text = txtHTML.Text + " position: " + playerPosition;
                //Player Position End

                //Player Salary Start
                locStart = mlbFile.IndexOf("data-salary=");
                mlbFile = mlbFile.Substring(locStart + 2);
                locStart = mlbFile.IndexOf(">");
                locEnd = mlbFile.IndexOf("<");
                String playerFanDuelSalaryString = mlbFile.Substring(locStart + 1, locEnd - locStart - 1);
                playerFanDuelSalaryString = playerFanDuelSalaryString.Replace(" ", "");
                playerFanDuelSalaryString = playerFanDuelSalaryString.Replace("\n", "");
                Double playerFanDuelSalaryDouble = -1;
                if(playerFanDuelSalaryString.Length>0)
                {
                    playerFanDuelSalaryString = playerFanDuelSalaryString.Replace("$", "");
                    if(playerFanDuelSalaryString.Contains("K"))
                    {
                        playerFanDuelSalaryString = playerFanDuelSalaryString.Replace("K", "");
                        playerFanDuelSalaryDouble = Double.Parse(playerFanDuelSalaryString);
                        playerFanDuelSalaryDouble = playerFanDuelSalaryDouble * 1000;
                    }
                }
                int playerFanDuelSalary = Int32.Parse(playerFanDuelSalaryDouble.ToString());
                //txtHTML.Text = txtHTML.Text + " salary: $" + playerFanDuelSalary.ToString();
                //Player Salary End

                //RotoGrinders Projection Start
                locStart = mlbFile.IndexOf("data-fpts=");
                mlbFile = mlbFile.Substring(locStart + 10);
                locStart = 0;
                locEnd = mlbFile.IndexOf("\">");
                double playerPointsDouble = Double.Parse(mlbFile.Substring(locStart + 1, locEnd - locStart - 1));
                //txtHTML.Text = txtHTML.Text + " points: " + playerPointsDouble.ToString();
                //RotoGrinders Projection End

                //Check for next player start
                playerLocal = mlbFile.IndexOf("<a class=\"player-popup\" data-url=\"https://rotogrinders.com");

        
                Player thisPlayer = new Player();
                thisPlayer.lastName = lastName;
                thisPlayer.firstName = firstName;
                thisPlayer.fanDuelCost = playerFanDuelSalary;
                thisPlayer.rotogrindersFanDuelProjection = playerPointsDouble;
                thisPlayer.position = playerPosition;

                //players.Add(thisPlayer);

                UpdatePlayerList(thisPlayer);
                
                txtHTML.Text = txtHTML.Text + thisPlayer.print() + "\n";
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtHTML.Text = "";
            foreach(Player player in players)
            {
                txtHTML.Text = txtHTML.Text + player.print() + "\n";
            }
        }

        private bool UpdatePlayerList(Player newPlayer)
        {
            foreach (Player player in players)
            {
                if (player.lastName == newPlayer.lastName && player.firstName == newPlayer.firstName && player.position == newPlayer.position)
                {
                    // Player already exists
                    if (player.rotogrindersFanDuelProjection == -1)
                    {
                        player.rotogrindersFanDuelProjection = newPlayer.rotogrindersFanDuelProjection;
                    }
                    if (player.numberfireFanDuelProjection == -1)
                    {
                        player.numberfireFanDuelProjection = newPlayer.numberfireFanDuelProjection;
                    }
                    if (player.fanDuelCost == -1)
                    {
                        player.fanDuelCost = newPlayer.fanDuelCost;
                    }
                    return false;
                }
            }
            players.Add(newPlayer);
            return true;
        }

        private void btnClearScreen_Click(object sender, EventArgs e)
        {
            txtHTML.Text = "";
        }

        private void btnRunStats_Click(object sender, EventArgs e)
        {
            txtHTML.Text = "Running Stats Started!";

            List<Player> firstBasemen = new List<Player>();
            List<Player> secondBasemen = new List<Player>();
            List<Player> thirdBasemen = new List<Player>();
            List<Player> shortStops = new List<Player>();
            List<Player> of1s = new List<Player>();
            List<Player> of2s = new List<Player>();
            List<Player> of3s = new List<Player>();
            List<Player> utils = new List<Player>();
            List<Player> pitchers = new List<Player>();
            List<MLBLineup> lineups = new List<MLBLineup>();
            double highValue = 0;
            double highCost = 0;

            txtHTML.Text = "";
            int count = 1;
            foreach (Player player in players)
            {
                player.id = count;
                count++;
                if (player.position == "P" && player.getExpectedValue() > 5)
                {
                    pitchers.Add(player);
                }
                else
                {
                    if (player.getExpectedValue() > 2) {
                        utils.Add(player);
                    }
                }
                if (player.position == "C-1B" && player.getExpectedValue() > 2)
                {
                    firstBasemen.Add(player);
                }
                else if (player.position == "2B" && player.getExpectedValue() > 2)
                {
                    secondBasemen.Add(player);
                }
                else if (player.position == "3B" && player.getExpectedValue() > 2)
                {
                    thirdBasemen.Add(player);
                }
                else if (player.position == "SS" && player.getExpectedValue() > 2)
                {
                    shortStops.Add(player);
                }
                else if (player.position == "OF" && player.getExpectedValue() > 2)
                {
                    of1s.Add(player);
                    of2s.Add(player);
                    of3s.Add(player);
                }
            }
            new Thread(() =>
            {
                int pitcherCount = 0;
                int shortStopCount = 0;
                int secondBaseCount = 0;
                int firstBaseCount = 0;
                int of2Count = 0;
                int of3Count = 0;
                foreach (Player pitcher in pitchers)
                {
                    pitcherCount++;
                    foreach (Player of1 in of1s)
                    {
                        foreach (Player of2 in of2s)
                        {
                            of2Count++;
                            if (of1.id != of2.id)
                            {
                                foreach (Player of3 in of3s)
                                {
                                    of3Count++;
                                    if (of3.id != of2.id && of3.id != of1.id)
                                    {
                                        foreach (Player shortStop in shortStops)
                                        {
                                            shortStopCount++;
                                            txtHTML.Invoke((MethodInvoker)delegate
                                            {
                                                txtHTML.Text = lineups.Count.ToString() + "\n pitcherCount: " + pitcherCount.ToString() + "\n secondBaseCount: " + secondBaseCount.ToString() + "\n shortStopCount: " + shortStopCount.ToString() + "\n highScore: " + highValue.ToString() + "\n of2Count: " + of2Count.ToString() + "\n of3Count: " + of3Count.ToString() + "\n highCost: " + highCost.ToString() + "\n firstBaseCount: " + firstBaseCount.ToString();
                                            });
                                            foreach (Player firstBaseman in firstBasemen)
                                            {
                                                firstBaseCount++;
                                                foreach (Player secondBaseman in secondBasemen)
                                                {
                                                    secondBaseCount++;
                                                    foreach (Player thirdBaseman in thirdBasemen)
                                                    {
                                                        foreach (Player util in utils)
                                                        {
                                                            if (util.id != of1.id && util.id != of2.id && util.id != of3.id && util.id != shortStop.id && util.id != firstBaseman.id && util.id != secondBaseman.id && util.id != thirdBaseman.id)
                                                            {
                                                                double expectedScore = shortStop.getExpectedValue() + thirdBaseman.getExpectedValue() + secondBaseman.getExpectedValue() + firstBaseman.getExpectedValue() + of1.getExpectedValue() + of2.getExpectedValue() + of3.getExpectedValue() + util.getExpectedValue() + pitcher.getExpectedValue();
                                                                if (expectedScore > 135)
                                                                {
                                                                    double fanDuelCost = shortStop.fanDuelCost + thirdBaseman.fanDuelCost + secondBaseman.fanDuelCost + firstBaseman.fanDuelCost + of1.fanDuelCost + of2.fanDuelCost + of3.fanDuelCost + util.fanDuelCost + pitcher.fanDuelCost;
                                                                    if (fanDuelCost <= 38000)
                                                                    {
                                                                        if(highValue < expectedScore)
                                                                        {
                                                                            highValue = expectedScore;
                                                                            highCost = fanDuelCost;
                                                                        }
                                                                        /*
                                                            MLBLineup lineup = new MLBLineup();
                                                            lineup.Of1 = of1.lastName + ", " + of1.firstName;
                                                            lineup.Of2 = of2.lastName + ", " + of2.firstName;
                                                            lineup.Of3 = of3.lastName + ", " + of3.firstName;
                                                            lineup.FirstBase = firstBaseman.lastName + ", " + firstBaseman.firstName;
                                                            lineup.SecondBase = secondBaseman.lastName + ", " + secondBaseman.firstName;
                                                            lineup.ThirdBase = thirdBaseman.lastName + ", " + thirdBaseman.firstName;
                                                            lineup.ShortStop = shortStop.lastName + ", " + shortStop.firstName;
                                                            lineup.Util = util.lastName + ", " + util.firstName;
                                                            lineup.Pitcher = pitcher.lastName + ", " + pitcher.firstName;
                                                            lineup.Score = expectedScore;
                                                            lineup.Cost = fanDuelCost;
                                                            lineups.Add(lineup);
                                                            if (lineups.Count % 1000 == 1)
                                                            { 
                                                                        txtHTML.Invoke((MethodInvoker)delegate
                                                                        {
                                                                            txtHTML.Text = lineups.Count.ToString() + "\n pitcherCount: " + pitcherCount.ToString() + "\n secondBaseCount: " + secondBaseCount.ToString() + "\n shortStopCount: " + shortStopCount.ToString() + "\n highScore: " + highValue.ToString() + "\n of2Count: " + of2Count.ToString() + "\n of3Count: " + of3Count.ToString() + "\n highCost: " + highCost.ToString() + "\n firstBaseCount: " + firstBaseCount.ToString();
                                                                        });
                                                                        }*/
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }).Start();
        }
    }
}
