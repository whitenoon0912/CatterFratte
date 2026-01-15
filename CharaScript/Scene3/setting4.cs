using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting4 : MonoBehaviour
{
    public GameObject[] text1;
    public GameObject[] plus;
    public GameObject[] minus;
    public TMP_Text[] text2;
    public GameObject bg;
    private int ClickCount = 0;
    public PlayerManager3 pm3;
    public goalManager3 gm3;
    public Button Settings;
    public textManager tm;
    public GameObject ritia;
    public GameObject ritiatext;
    public GameObject[] orbtn;
    public Fade fade;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager.coinCounters[2] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pm3.BGM.volume = scoreManager.AudioVolume;
        pm3.coinAu.volume = scoreManager.coinVolume;
        gm3.goal.volume = scoreManager.goalVolume;
        text2[0].text = scoreManager.AudioVolume.ToString("F1");
        text2[1].text = scoreManager.coinVolume.ToString("F1");
        text2[2].text = scoreManager.goalVolume.ToString("F1");
    }

    public void ClickSetting()
    {
        ClickCount++;
        if (ClickCount == 1)
        {
            pm3.setting = true;
            bg.SetActive(true);
            foreach (GameObject obj in text1)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in plus)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in minus)
            {
                obj.SetActive(true);
            }
            foreach (TMP_Text text in text2)
            {
                text.gameObject.SetActive(true);
            }
            ritia.SetActive(true);
        }
        else if (ClickCount == 2)
        {
            pm3.setting = false;
            bg.SetActive(false);
            foreach (GameObject obj in text1)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in plus)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in minus)
            {
                obj.SetActive(false);
            }
            foreach (TMP_Text text in text2)
            {
                text.gameObject.SetActive(false);
            }
            ritia.SetActive(false);

            ClickCount = 0;
        }
    }

    public void pulasButton1()
    {
        if (scoreManager.AudioVolume >= 1)
        {
            scoreManager.AudioVolume = 1;
        }
        else if (scoreManager.AudioVolume < 1)
        {
            scoreManager.AudioVolume += 0.1f;
        }
    }
    public void pulasButton2()
    {
        if (scoreManager.coinVolume >= 1)
        {
            scoreManager.coinVolume = 1;
        }
        else if (scoreManager.coinVolume < 1)
        {
            scoreManager.coinVolume += 0.1f;
        }
        pm3.coinAu.Play();
    }
    public void pulasButton3()
    {
        if (scoreManager.goalVolume >= 1)
        {
            scoreManager.goalVolume = 1;
        }
        else if (scoreManager.goalVolume < 1)
        {
            scoreManager.goalVolume += 0.1f;
        }
        gm3.goal.Play();
    }

    public void minusButton1()
    {
        if (scoreManager.AudioVolume < 0.1f)
        {
            scoreManager.AudioVolume = 0;
        }
        else if (scoreManager.AudioVolume > 0)
        {
            scoreManager.AudioVolume -= 0.1f;
        }
    }
    public void minusButton2()
    {
        if (scoreManager.coinVolume < 0.1f)
        {
            scoreManager.coinVolume = 0;
        }
        else if (scoreManager.coinVolume > 0)
        {
            scoreManager.coinVolume -= 0.1f;
        }
        pm3.coinAu.Play();
    }
    public void minusButton3()
    {
        if (scoreManager.goalVolume < 0.1f)
        {
            scoreManager.goalVolume = 0;
        }
        else if (scoreManager.goalVolume > 0)
        {
            scoreManager.goalVolume -= 0.1f;
        }
        gm3.goal.Play();
    }

    public void ritiaButtonClick()
    {
        pm3.setting = true;
        Settings.interactable = false;
        bg.SetActive(false);
        foreach (GameObject obj in text1)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in plus)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in minus)
        {
            obj.SetActive(false);
        }

        foreach (TMP_Text text in text2)
        {
            text.gameObject.SetActive(false);
        }
        ritiatext.SetActive(true);
        foreach (var obj in orbtn)
        {
            obj.gameObject.SetActive(true);
        }
        ritia.SetActive(false);
    }

    public void decideClick()
    {
        fade.FadeIn(2f);
        scoreManager.coinCounters[2] = 0;
        scoreManager.coinCounters[2] += scoreManager.CoinHozon[2];
        StartCoroutine(decideritia(2f));
    }

    public void ReturnGameClick()
    {
        pm3.setting = false;
        Settings.interactable = true;
        ClickCount = 0;
        ritiatext.SetActive(false);
        foreach (var obj in orbtn)
        {
            obj.gameObject.SetActive(false);
        }
        ritia.SetActive(false);
    }
    
    IEnumerator decideritia(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("HomeScene");
    }
}
