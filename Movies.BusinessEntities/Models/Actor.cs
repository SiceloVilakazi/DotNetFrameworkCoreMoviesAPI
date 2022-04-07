using System.Text.Json.Serialization;

namespace Movies.BusinessEntities;

public class Actor
{
    [JsonPropertyName("Id")]
    public int Id { get; set; }

    [JsonPropertyName("Name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("Surname")]
    public string Surname { get; set; } = string.Empty;

    [JsonPropertyName("AgentId")]

    public int AgentId { get; set; }

    #nullable enable
    [JsonPropertyName("agents")]
    public Agent? agents { get; set; }
 
    [JsonPropertyName("FullName")]
    public string FullName
    {
        get { return Name + " " + Surname; }
    }

    public bool isDeleted { get; set; } = false;

}

