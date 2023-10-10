
public static class Teams
{
    public static Team Hanover;
    public static Team Hamburg;
    public static Team Bremen;
    public static Team Bayern;
    public static Team Frankfurt;

    /// <summary>
    /// Simple contructor where the teams get initialised
    /// </summary>
    static Teams()
    {
        InitTeams();
    }

    /// <summary>
    /// Initialise teams with there names
    /// </summary>
    private static void InitTeams()
    {
        Hanover = new Team("Hannover");
        Hamburg = new Team("Hamburg");
        Bremen = new Team("Bremen");
        Bayern = new Team("Bayern");
        Frankfurt = new Team("Frankfurt");
    }
}
