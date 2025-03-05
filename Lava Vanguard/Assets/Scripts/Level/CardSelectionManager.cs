using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using　Async;
using UnityEngine.UI;
public class CardSelectionManager : MonoBehaviour
{
    public static CardSelectionManager Instance { get; private set; }
    public GameObject cardSelectionPanel;
    public Button[] cardButtons;
    public Image[] cardBackgrounds;
    public Image[] cardOutlines;
    public Image[] cardContents;
    public TextMeshProUGUI[] cardDescriptions;

    //private List<Module> availableModules = new List<Module>();
    //private Module[] selectedModules = new Module[3];
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<3;i++){
            int index=i;
            cardButtons[i].onClick.RemoveAllListeners();
            cardButtons[i].onClick.AddListener(()=>SelectCard(index));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartSelection(){
        Time.timeScale = 0;
        for(int i=0;i<3;i++){
            CardSpriteData cardSpriteData = GameDataManager.CardData["Card_01"];
            cardBackgrounds[i].sprite = GameDataManager.BackgroundSprite[cardSpriteData.Background];
            cardOutlines[i].sprite = GameDataManager.OutlineSprite[cardSpriteData.Outline];
            cardContents[i].sprite = GameDataManager.ContentSprite[cardSpriteData.Content];
            cardDescriptions[i].text = ""+Time.time;
        }
        cardSelectionPanel.SetActive(true);
    }

    private void SelectCard(int index){
        Debug.Log("Selecting card at index: " + index);
        InventoryManager.Instance.inventoryView.AddCardView(new CardRankData("000", "Card_01", 1));
        cardSelectionPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
