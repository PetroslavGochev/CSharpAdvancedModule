using System;
using System.Collections.Generic;
using System.Text;
using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Models
{
    public class Stats
    {
        private const int MAX = 100;
        private const int MIN = 0;
        private const int NUMBER_OF_TEAMS = 5;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(string[] data)
        {
            this.Endurance = int.Parse(data[0]);
            this.Sprint = int.Parse(data[1]);
            this.Dribble = int.Parse(data[2]);
            this.Passing = int.Parse(data[3]);
            this.Shooting = int.Parse(data[4]);
        }
        private int Endurance
        {
             set
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException(String.Format(Common.Validator.InvalidRating,"Endurance"));
                }
                this.endurance = value;
            }
        }
        private int Sprint
        {
            set
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException(String.Format(Common.Validator.InvalidRating, "Sprint"));
                }
                this.sprint = value;
            }
        }
        private int Dribble
        {
            set
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException(String.Format(Common.Validator.InvalidRating, "Dribble"));
                }
                this.dribble = value;
            }
        }
        private int Passing
        {
            set
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException(String.Format(Common.Validator.InvalidRating, "Passing"));
                }
                this.passing = value;
            }
        }
        private int Shooting
        {
            set
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException(String.Format(Common.Validator.InvalidRating, "Shooting"));
                }
                this.shooting = value;
            }
        }


        private bool IsValid(int value) => value >= MIN && value <= MAX;
        public double Average()
        {
            double average = (this.endurance + this.dribble + this.shooting + this.passing + this.sprint) / 5.00;
            return average;
        }
       
    }
}
