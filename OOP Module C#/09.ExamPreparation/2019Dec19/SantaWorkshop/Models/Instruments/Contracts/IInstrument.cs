namespace SantaWorkshop.Models.Instruments.Contracts
{
    public interface IInstrument
    {
        int Power { get; }

        void Use();

        bool IsBroken();
    }
}
