using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemBool : MonoBehaviour
{
    [Header("buyitemButton.csの能力追加Bool")]
    public static bool jumpbool = false;
    public static bool jumpVectorbool = false;
    public static bool Vectorbool = false;
    public static bool AddAudio = false;
    public static bool AddAudioClick = false;
    public static bool GetCoin = false;
    public static bool HPpulas = false;
    public static bool GetCoin1 = false;
    public static bool GetCoin2 = false;
    public static bool GetCoin3 = false;
    [Header("ボタンを押した回数制御")]
    private static int ButtonClick = 0;
    private static int ButtonClick2 = 0;
    private static int ButtonClick3 = 0;
    private static int ButtonClick4 = 0;
    private static int ButtonClick5 = 0;
    private static int ButtonClick6 = 0;
    private static int ButtonClick7 = 0;
    private static int ButtonClick8 = 0;
    private static int ButtonClick9 = 0;
    public static List<int> ButtonClickCounter = new List<int>() { ButtonClick, ButtonClick2, ButtonClick3, ButtonClick4, ButtonClick5, ButtonClick6, ButtonClick7, ButtonClick8, ButtonClick9 };
    [Header("現在の特殊コインの所持数")]
    public static int BCoin = 0;
    public static int YCoin = 0;
    public static int RCoin = 0;
    public static List<int> coinbool = new List<int>() { BCoin, YCoin, RCoin };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
