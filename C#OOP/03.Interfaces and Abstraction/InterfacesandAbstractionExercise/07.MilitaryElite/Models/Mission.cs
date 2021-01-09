using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;
using MilitaryElite.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName,string state)
        {
            this.CodeName = codeName;
            this.State = this.TryParse(state);
        }
        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            if (this.State == State.Finished)
            {
                throw new InvalidMissionCompletionException();
            }
            this.State = State.Finished;
        }
        private State TryParse(string stateStr)
        {
            State state;
            bool parse = Enum.TryParse<State>(stateStr, out state);
            if (!parse)
            {
                throw new InvalidStateExceptions();
            }
            return state;
        }
        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
