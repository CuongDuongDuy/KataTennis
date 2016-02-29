namespace KataTennis.App.Contracts
{
    public interface IScoringService
    {
        Player GetWinner();
        void ShowCurrentResults();
    }
}