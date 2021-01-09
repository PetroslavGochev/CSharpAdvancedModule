using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exceptions
{
   public  class InvalidMissionCompletionException : Exception
    {
        private const string MESSAGE = "Mission already completed!";
        public InvalidMissionCompletionException()
            : base(MESSAGE)
        {

        }
        public InvalidMissionCompletionException(string message)
            :base(message)
        {

        }
    }
}
