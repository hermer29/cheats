namespace Hermer29.Cheats
{
    public interface ICheatHandler
    {
        /// <summary>
        /// Case insensitive
        /// </summary>
        string GetCheatCode();

        /// <summary>
        /// Cheat execution
        /// </summary>
        void Execute();
    }
}