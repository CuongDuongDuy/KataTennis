namespace KataTennis.App.Contracts
{
    public interface IScoringService
    {
        Player GetWinner();
        string GetCurrentResults();
    }
}