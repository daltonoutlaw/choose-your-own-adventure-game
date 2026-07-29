using System.Text.Json;

public class Messages
{
    public string CurrentLanguage { get; set; }
    private Dictionary<string, string> _dictionary;
    private Dictionary<string, string> _raceMap;
    private Dictionary<string, string> _occupationMap;
    private Dictionary<string, string> _displayRaceMap;
    private Dictionary<string, string> _displayOccupationMap;
    private Dictionary<string, string> _displayWeaponMap;

    public Messages()
    {
        CurrentLanguage = "English";
        _dictionary = new Dictionary<string, string>();
        _raceMap = new Dictionary<string, string>();
        _occupationMap = new Dictionary<string, string>();
    }

    public void SetCurrentLanguage(string language)
    {
        CurrentLanguage = language;
    }

    public void ReadDictionary()
    {
        string jsonPath = Path.Combine(AppContext.BaseDirectory, "language_data.json");
        
        if (!File.Exists(jsonPath))
        {
            throw new FileNotFoundException($"Language data file not found at: {jsonPath}");
        }

        try
        {
            string jsonText = File.ReadAllText(jsonPath);
            using JsonDocument doc = JsonDocument.Parse(jsonText);

            if (!doc.RootElement.TryGetProperty(CurrentLanguage, out JsonElement langSection))
            {
                throw new Exception($"Language '{CurrentLanguage}' not found in language data.");
            }

            // Helper to safely load dictionaries
            Dictionary<string, string> LoadMap(string propertyName)
            {
                var map = new Dictionary<string, string>();
                if (langSection.TryGetProperty(propertyName, out JsonElement section))
                {
                    foreach (JsonProperty entry in section.EnumerateObject())
                        map[entry.Name] = entry.Value.GetString() ?? string.Empty;
                }
                return map;
            }

            _dictionary = LoadMap("dictionary");
            _raceMap = LoadMap("raceMap");
            _occupationMap = LoadMap("occupationMap");
            _displayRaceMap = LoadMap("displayRaceMap");
            _displayOccupationMap = LoadMap("displayOccupationMap");
            _displayWeaponMap = LoadMap("displayWeaponMap");
        }
        catch (JsonException ex)
        {
            throw new Exception($"Error parsing language data: {ex.Message}", ex);
        }
    }

    public string GetMessage(string key)
    {
        if (string.IsNullOrWhiteSpace(key)) return "[empty_key]";
        return _dictionary.TryGetValue(key, out string? value) ? value : $"[{key}]";
    }

    public bool IsValidRace(string? input)
    {
        if (string.IsNullOrWhiteSpace(input)) return false;
        return _raceMap.ContainsKey(input.Trim().ToLower());
    }

    public string NormalizeRace(string input)
    {
        return _raceMap.TryGetValue(input.Trim().ToLower(), out string? canonical) ? canonical : input;
    }

    public bool IsValidOccupation(string? input)
    {
        if (string.IsNullOrWhiteSpace(input)) return false;
        return _occupationMap.ContainsKey(input.Trim().ToLower());
    }

    public string NormalizeOccupation(string input)
    {
        return _occupationMap.TryGetValue(input.Trim().ToLower(), out string? canonical) ? canonical : input;
    }

    public string TranslateRaceForDisplay(string race)
    {
        return _displayRaceMap.TryGetValue(race, out string? translated) ? translated : race;
    }

    public string TranslateOccupationForDisplay(string occupation)
    {
        return _displayOccupationMap.TryGetValue(occupation, out string? translated) ? translated : occupation;
    }

    public string TranslateWeaponForDisplay(string weaponType)
    {
        return _displayWeaponMap.TryGetValue(weaponType, out string? translated) ? translated : weaponType;
    }


}
