using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCollectedText : MonoBehaviour, IDataPersistence
{
    [SerializeField] private int totalCoins = 0;

    private int coinsCollected = 0;

    private TextMeshProUGUI coinsCollectedText;

    private void Awake() 
    {
        coinsCollectedText = this.GetComponent<TextMeshProUGUI>();
    }

    private void Start() 
    {
        // subscribe to events
        GameEventsManager.instance.onCoinCollected += OnCoinCollected;
    }

    public void LoadData(GameData data) 
    {
        foreach(KeyValuePair<string, bool> pair in data.coinsCollected) 
        {
            if (pair.Value) 
            {
                coinsCollected++;
            }
        }
    }

    public void SaveData(GameData data)
    {
        // no data needs to be saved for this script
    }

    private void OnDestroy() 
    {
        // unsubscribe from events
        GameEventsManager.instance.onCoinCollected -= OnCoinCollected;
    }

    private void OnCoinCollected() 
    {
        coinsCollected++;
    }

    private void Update() 
    {
        coinsCollectedText.text = coinsCollected + " / " + totalCoins;
    }
}
