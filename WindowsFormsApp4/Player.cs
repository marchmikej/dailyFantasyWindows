using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    class Player
    {
        public int id;
        public String lastName;
        public String firstName;
        public String position;
        public int fanDuelCost;
        public double rotogrindersFanDuelProjection;
        public double numberfireFanDuelProjection;

        public Player()
        {
            lastName = "";
            firstName = "";
            position = "";
            fanDuelCost = -1;
            rotogrindersFanDuelProjection = -1;
            numberfireFanDuelProjection = -1;
            id = -1;
        }

        public double getExpectedValue()
        {
            return (numberfireFanDuelProjection + rotogrindersFanDuelProjection) / 2;
        }

        public String print()
        {
            return lastName + ", " + firstName + " Pos: " + position + " Cost: " + fanDuelCost.ToString() + " rotoProjection: " + rotogrindersFanDuelProjection.ToString() + " numfireProj: " + numberfireFanDuelProjection.ToString();
        }
    }
}
