using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BowlingGame.Files.Repository;
public abstract class BaseListFileRepository<T> where T : class
{
    protected static IEnumerable<T> Get(string fileName)
    {
        string? directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (directory is null) return new List<T>();

        string? filePath = $"{directory}\\{fileName}";
        if (!File.Exists(filePath)) return new List<T>();

        string json = File.ReadAllText(filePath);
        JsonMenu<T>? menu = JsonSerializer.Deserialize<JsonMenu<T>>(json);

        return menu is null ? new List<T>() : menu.Items;
    }
}

internal class JsonMenu<T>
{
    [JsonPropertyName("items")]
    public List<T> Items { get; set; } = new List<T>();
}
