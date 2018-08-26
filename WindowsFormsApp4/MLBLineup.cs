using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    class MLBLineup
    {
        private String pitcher;
        private String of1;
        private String of2;
        private String of3;
        private String c1b;
        private String firstBase;
        private String secondBase;
        private String thirdBase;
        private String shortStop;
        private String util;
        private double cost;
        private double score;

        public string Pitcher { get => pitcher; set => pitcher = value; }
        public string Of1 { get => of1; set => of1 = value; }
        public string Of2 { get => of2; set => of2 = value; }
        public string Of3 { get => of3; set => of3 = value; }
        public string C1b { get => c1b; set => c1b = value; }
        public string FirstBase { get => firstBase; set => firstBase = value; }
        public string SecondBase { get => secondBase; set => secondBase = value; }
        public string ThirdBase { get => thirdBase; set => thirdBase = value; }
        public string Util { get => util; set => util = value; }
        public double Cost { get => cost; set => cost = value; }
        public double Score { get => score; set => score = value; }
        public string ShortStop { get => shortStop; set => shortStop = value; }
    }
}
