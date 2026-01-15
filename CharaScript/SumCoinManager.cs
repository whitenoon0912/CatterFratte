using TMPro;
using UnityEngine;

public class SumCoinManager : MonoBehaviour
{
    public TMP_Text[] CoinCounts;
    private int[] CoinMax = { 5, 6, 7, 6, 6, 11, 5, 5 };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < CoinCounts.Length; i++)
        {
            CoinCounts[i].text = scoreManager.coinCounters[i].ToString() + "/" + CoinMax[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
