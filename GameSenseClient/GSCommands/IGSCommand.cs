namespace GameSenseClient
{
    public interface IGSCommand
    {
        string Uri { get; }
        string GetCommand();
        string ProgramName { get; set; }
    }
}