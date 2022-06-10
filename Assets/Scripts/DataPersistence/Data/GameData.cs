using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    public int deathCount;
    public Vector3 playerPosition;
    public SerializableDictionary<string, bool> coinsCollected;
    public AttributesData playerAttributesData;

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData() 
    {
        this.deathCount = 0;
        playerPosition = Vector3.zero;
        coinsCollected = new SerializableDictionary<string, bool>();
        playerAttributesData = new AttributesData();
    }

    public int GetPercentageComplete() 
    {
        // figure out how many coins we've collected
        int totalCollected = 0;
        foreach (bool collected in coinsCollected.Values) 
        {
            if (collected) 
            {
                totalCollected++;
            }
        }

        // ensure we don't divide by 0 when calculating the percentage
        int percentageCompleted = -1;
        if (coinsCollected.Count != 0) 
        {
            percentageCompleted = (totalCollected * 100 / coinsCollected.Count);
        }
        return percentageCompleted;
    }
}
