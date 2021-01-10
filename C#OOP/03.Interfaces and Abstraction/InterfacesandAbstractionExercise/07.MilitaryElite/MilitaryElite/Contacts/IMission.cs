using MilitaryElite.Enumerator;

namespace MilitaryElite.Contacts
{
    public interface IMission
    {
        public string CodeName { get;  }
        public string State { get; }
        public void CompleteMission();
    }
}
