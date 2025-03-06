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
    public GameObject[] cardPrefabs=new GameObject[3];
    public TextMeshProUGUI[] cardDescriptions;

    private GameObject[] instantiatedCards = new GameObject[3];
    private Vector2 cardOffset = new Vector2(20, 300);
    private int[] selectedIndices=new int[3];

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
        selectedIndices=ShuffleIndices(cardPrefabs.Length,3);
        Debug.Log("Shuffled indices: " + string.Join(",", selectedIndices));
        for(int i=0;i<3;i++){
            if (instantiatedCards[i] != null) {
                Destroy(instantiatedCards[i]);
            }
            Debug.Log("Instantiating card at index: " + selectedIndices[i]);
            instantiatedCards[i] = Instantiate(cardPrefabs[selectedIndices[i]], cardButtons[i].transform);
            RectTransform cardRect = instantiatedCards[i].GetComponent<RectTransform>();
            cardRect.anchoredPosition = cardOffset;
            cardRect.localScale = Vector3.one;

            cardDescriptions[i].text = "Card " + selectedIndices[i] + " at time: " + Time.time;
        }
        cardSelectionPanel.SetActive(true);
    }

    private int[] ShuffleIndices(int n,int k){
        int[] indices=new int[n];
        for (int i = 0; i < n; i++)
        {
            indices[i] = i;
        }

        for (int i = n - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (indices[i], indices[j]) = (indices[j], indices[i]);
        }
        return indices[..k];
    }
    private void SelectCard(int index){
        Debug.Log("Selecting card at index: " + index+" with card ID: "+selectedIndices[index]);
        AsyncManager.Instance.GainCard(selectedIndices[index]);
        cardSelectionPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
