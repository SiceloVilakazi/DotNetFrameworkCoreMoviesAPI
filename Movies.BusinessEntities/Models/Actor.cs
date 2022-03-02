namespace Movies.BusinessEntities;

public class Actor
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public int AgentId { get; set; }

    public Agent? agents { get; set; }

    public string FullName
    {
        get { return Name + " " + Surname; }
    }

}

