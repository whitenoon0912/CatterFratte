using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class buyitemButton : MonoBehaviour
{
    public TMP_Text coin;
    private int[] buyCoin = { 5, 12, 18, 17, 25, 23, 25, 25, 25 };
    public Button[] buybutton;
    private int Num;
    public TMP_Text[] HasCoin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coin.text = "コイン：" + scoreManager.coinscore;

        int[] ColorCoins = new int[] { ItemBool.BCoin, ItemBool.YCoin, ItemBool.RCoin };//int[]のリスト(または配列)に並べて整理する
        for (int i = 0; i < HasCoin.Length; i++)
        {
            HasCoin[i].text = "獲得数" + ColorCoins[i];//for文で獲得数(文字列)のみを共通で表示できるようにする + ColorCoinsをfor文に適応させる
        }

        for (int i = 0; i < buyCoin.Length; i++)
        {
            for (int t = 0; t < buybutton.Length; t++)
            {
                if (scoreManager.coinscore < buyCoin[i])
                {
                    buybutton[i].interactable = false;
                }
                else if (scoreManager.coinscore >= buyCoin[i])
                {
                    buybutton[i].interactable = true;
                }
            }
        }

        for (int s = 6; s < buybutton.Length; s++)
        {
            if (scoreManager.GetCoinOK)
            {
                buybutton[s].interactable = true;
            }
            else if (!scoreManager.GetCoinOK)
            {
                buybutton[s].interactable = false;
            }
        }

        if (ItemBool.ButtonClickCounter[0] >= 1)
        {
            buybutton[0].interactable = false;
        }
        if (ItemBool.ButtonClickCounter[1] >= 1)
        {
            buybutton[1].interactable = false;
        }
        if (ItemBool.ButtonClickCounter[2] >= 1)
        {
            buybutton[2].interactable = false;
        }
        if (ItemBool.ButtonClickCounter[3] >= 1)
        {
            buybutton[3].interactable = false;
        }
        if (ItemBool.ButtonClickCounter[4] >= 1)
        {
            buybutton[4].interactable = false;
        }
        if (ItemBool.ButtonClickCounter[5] >= 1)
        {
            buybutton[5].interactable = false;
        }
        if (ItemBool.ButtonClickCounter[6] >= 1)
        {
            buybutton[6].interactable = false;
        }
        if (ItemBool.ButtonClickCounter[7] >= 1)
        {
            buybutton[7].interactable = false;
        }
        if (ItemBool.ButtonClickCounter[8] >= 1)
        {
            buybutton[8].interactable = false;
        }
    }

    public void buy1()
    {
        if (scoreManager.coinscore < buyCoin[0])
        {
            Debug.Log("買えません");
        }
        else
        {
            scoreManager.coinscore -= buyCoin[0];
            ItemBool.ButtonClickCounter[0]++;
            ItemBool.jumpbool = true;
        }
    }

    public void buy2()
    {
        if (scoreManager.coinscore < buyCoin[1])
        {
            Debug.Log("買えません");
        }
        else
        {
            scoreManager.coinscore -= buyCoin[1];
            ItemBool.ButtonClickCounter[1]++;
            ItemBool.jumpVectorbool = true;
        }
    }
    public void buy3()
    {
        if (scoreManager.coinscore < buyCoin[2])
        {
            Debug.Log("買えません");
        }
        else
        {
            scoreManager.coinscore -= buyCoin[2];
            ItemBool.ButtonClickCounter[2]++;
            ItemBool.Vectorbool = true;
        }
    }

    public void buy4()
    {
        if (scoreManager.coinscore < buyCoin[3])
        {
            Debug.Log("買えません");
        }
        else
        {
            scoreManager.coinscore -= buyCoin[3];
            ItemBool.ButtonClickCounter[3]++;
            ItemBool.AddAudio = true;
        }
    }

    public void buy5()
    {
        if (scoreManager.coinscore < buyCoin[4])
        {
            Debug.Log("買えません");
        }
        else
        {
            scoreManager.coinscore -= buyCoin[4];
            ItemBool.ButtonClickCounter[4]++;
            ItemBool.GetCoin = true;
        }
    }

    public void buy6()
    {
        if (scoreManager.coinscore < buyCoin[5])
        {
            Debug.Log("買えません");
        }
        else
        {
            scoreManager.coinscore -= buyCoin[5];
            ItemBool.ButtonClickCounter[5]++;
            ItemBool.HPpulas = true;
        }
    }

    public void buy7()
    {
        if (scoreManager.coinscore < buyCoin[6])
        {
            Debug.Log("買えません");
        }
        else
        {
            scoreManager.coinscore -= buyCoin[6];
            ItemBool.ButtonClickCounter[6]++;
            ItemBool.BCoin++;
            ItemBool.coinbool[0]++;
            ItemBool.GetCoin1 = true;
        }
    }

    public void buy8()
    {
        if (scoreManager.coinscore < buyCoin[7])
        {
            Debug.Log("買えません");
        }
        else
        {
            scoreManager.coinscore -= buyCoin[7];
            ItemBool.ButtonClickCounter[7]++;
            ItemBool.YCoin++;
            ItemBool.coinbool[1]++;
            ItemBool.GetCoin2 = true;
        }
    }

    public void buy9()
    {
        if (scoreManager.coinscore < buyCoin[8])
        {
            Debug.Log("買えません");
        }
        else
        {
            scoreManager.coinscore -= buyCoin[8];
            ItemBool.ButtonClickCounter[8]++;
            ItemBool.RCoin++;
            ItemBool.coinbool[2]++;
            ItemBool.GetCoin3 = true;
        }
    }
}
