using MilitaryElite.Contacts;
using MilitaryElite.Enumerator;
using System;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        private State state;
        public Mission(string codeName,string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }
        public string CodeName { get; }

        public string State
        {
            get
            {
                return this.state.ToString();
            }
            set
            {
                //State state;
                if (!Enum.TryParse<State>(value, out this.state))
                {
                    throw new ArgumentException();
                }
                //this.state = state;
            }
        }

        public void CompleteMission()
        {
            if(this.state == Enumerator.State.Finished)
            {
                throw new ArgumentException();
            }
            this.state = Enumerator.State.Finished;
        }
        public override string ToString()
        {
            return $"  Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
