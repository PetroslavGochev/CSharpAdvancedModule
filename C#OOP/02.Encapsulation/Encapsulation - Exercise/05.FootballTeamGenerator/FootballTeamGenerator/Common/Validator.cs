using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Common
{
    public class Validator
    {
        public const string InvalidRating = "{0} should be between 0 and 100.";
        public const string InvalidName = "A name should not be empty.";
        public const string PlayerNotExist = "Player {0} is not in {1} team.";
        public const string TeamNotExist = "Team {0} does not exist.";
      
    }
}
