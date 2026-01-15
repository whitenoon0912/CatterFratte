using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scoreManager : MonoBehaviour
{
    public static int coinscore = 0;
    public static int countdown = 0;
    public static float AudioVolume = 0.3f;
    public static float coinVolume = 0.3f;
    public static float goalVolume = 0.3f;
    public static int jumpCount = 1;
    public static float jumpVector = 1.15f;
    [Header("最終ゴールした時のコイン交換解放")]
    public static bool GetCoinOK = false;
    private static int coincount1 = 0;
    private static int coincount2 = 0;
    private static int coincount3 = 0;
    private static int coincount4 = 0;
    private static int coincount5 = 0;
    private static int coincount6 = 0;
    private static int coincount7 = 0;
    private static int coincount8 = 0;
    private static int coincount9 = 0;
    private static int coincount10 = 0;
    public static List<int> coinCounters = new List<int>() { coincount1, coincount2, coincount3, coincount4, coincount5, coincount6, coincount7, coincount8, coincount9, coincount10 };
    public static bool CursorActiveBool = false;
    public static bool Stage1 = false;
    public static bool Stage2 = false;
    public static bool Stage3 = false;
    public static bool Stage4 = false;
    public static bool Stage5 = false;
    public static bool Stage6 = false;
    public static bool Stage7 = false;
    public static bool Stage8 = false;
    public static bool Stage9 = false;
    public static bool Stage10 = false;
    public static List<bool> StageOn = new List<bool>() { Stage1, Stage2, Stage3, Stage4, Stage5, Stage6, Stage7, Stage8, Stage9, Stage10 };
    public static int coin1;
    public static int coin2;
    public static int coin3;
    public static int coin4;
    public static int coin5;
    public static int coin6;
    public static int coin7;
    public static int coin8;

    public static List<int> CoinHozon = new List<int>(){ coin1, coin2, coin3, coin4, coin5, coin6, coin7, coin8 };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
