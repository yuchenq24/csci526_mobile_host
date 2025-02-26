
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Async;


public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance { get; private set; }
    /// <summary>
    /// Async Data
    /// </summary>
    public static Dictionary<string, CardSpriteData> CardData;
    public static Dictionary<string, SequenceData> SequenceData;
    public static InventoryData InventoryData;
    public static Dictionary<string, Sprite> BackgroundSprite;
    public static Dictionary<string, Sprite> OutlineSprite;
    public static Dictionary<string, Sprite> ContentSprite;
    public static CardConfig CardConfig;
    public static InventoryConfig InventoryConfig;

    /// <summary>
    /// EnemyData
    /// </summary>
    public static Dictionary<string, EnemyData> EnemyData;
    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
        LoadSprites();
        LoadConfigs();
    }
    private void Start()
    {
        
    }
    private static T LoadJson<T>(string path)
    {
        var jsonText = Resources.Load<TextAsset>(path);
        if (jsonText == null)
        {
            Debug.LogError("No JSON file found at path: " + path);
            return default;
        }
        try
        {
            return JsonConvert.DeserializeObject<T>(jsonText.text);
        }
        catch (JsonException ex)
        {
            Debug.LogError("Error parsing JSON: " + ex.Message);
            return default;
        }
    }
    private static Dictionary<string, T> LoadDictionaryJson<T>(string path)
    {
        var jsonText = Resources.Load<TextAsset>(path);
        if (jsonText == null)
        {
            Debug.LogError("No JSON file found at path: " + path);
            return default;
        }
        try
        {
            return JsonConvert.DeserializeObject<Dictionary<string, T>>(jsonText.text);
        }
        catch (JsonException ex)
        {
            Debug.LogError("Error parsing JSON: " + ex.Message);
            return default;
        }
    }
    private static void SaveData()
    {
    }
    private static void LoadData()
    {
        CardData = LoadDictionaryJson<CardSpriteData>("Json/CardData");
        SequenceData = LoadDictionaryJson<SequenceData>("Json/SequenceData");
        InventoryData = LoadJson<InventoryData>("Json/InventoryData");
    }
    private static void LoadSprites()
    {
        BackgroundSprite = new Dictionary<string, Sprite>();
        OutlineSprite = new Dictionary<string, Sprite>();
        ContentSprite = new Dictionary<string, Sprite>();
        foreach (var c in CardData)
        {
            if (!BackgroundSprite.ContainsKey(c.Value.Background))
                BackgroundSprite.Add(c.Value.Background, Resources.Load<Sprite>("Sprite/Background/" + c.Value.Background));
            if (!OutlineSprite.ContainsKey(c.Value.Outline))
                OutlineSprite.Add(c.Value.Outline, Resources.Load<Sprite>("Sprite/Outline/" + c.Value.Outline));
            if (!ContentSprite.ContainsKey(c.Value.Content))
                ContentSprite.Add(c.Value.Content, Resources.Load<Sprite>("Sprite/Content/" + c.Value.Content));
        }
    }
    private static void LoadConfigs()
    {
        CardConfig = Resources.Load<CardConfig>("Config/CardConfig");
        InventoryConfig = Resources.Load<InventoryConfig>("Config/InventoryConfig");
    }

}
