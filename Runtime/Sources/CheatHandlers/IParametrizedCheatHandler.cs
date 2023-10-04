namespace Hermer29.Cheats
{
    public interface IParametrizedCheatHandler : ICheatHandler
    {
        string Description { get; }
        void Execute(string[] args);
    }
}