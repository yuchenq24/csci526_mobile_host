using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UIElements;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance {  get; private set; }
    public static Dictionary<string, CardModel> CardData;
    public static Dictionary<string, SequenceModel> SequenceData;
    public static Dictionary<string, Sprite> BackgroundSprite;
    public static Dictionary<string, Sprite> OutlineSprite;
    public static Dictionary<string, Sprite> ContentSprite;

   
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        CardData = LoadJson<CardModel>("Json/CardData");
        SequenceData = LoadJson<SequenceModel>("Json/SequenceData");
        LoadSprites();
    }
    private static Dictionary<string, T> LoadJson<T>(string path) where T : struct
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

}
