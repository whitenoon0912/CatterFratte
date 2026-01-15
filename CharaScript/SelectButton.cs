using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    private string[] stageName = {  "MonkeyFratte",
                                    "Lv2Scene",
                                    "Lv3Scene",
                                    "Lv4Scene",
                                    "Lv5Scene",
                                    "Lv6Scene",
                                    "Lv7Scene",
                                    "Lv8Scene",
                                    "Lv10Scene",
                                    "shopScene",
                                    "HomeScene"};
    public AudioClip ClickAu;
    private AudioSource Click;
    private string stage;
    public Button[] Selectbtn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioSetting();
        for (int i = 0; i < Selectbtn.Length; i++)
        {
            if (scoreManager.StageOn[0] == false)
            {
                Selectbtn[i].interactable = i == 0;
            }
            else if (scoreManager.StageOn[0] == true)
            {
                Selectbtn[i].interactable = i <= 1;
            }
            if (scoreManager.StageOn[1] == true)
            {
                Selectbtn[i].interactable = i <= 2;
            }
            if (scoreManager.StageOn[2] == true)
            {
                Selectbtn[i].interactable = i <= 3;
            }
            if (scoreManager.StageOn[3] == true)
            {
                Selectbtn[i].interactable = i <= 4;
            }
            if (scoreManager.StageOn[4] == true)
            {
                Selectbtn[i].interactable = i <= 5;
            }
            if (scoreManager.StageOn[5] == true)
            {
                Selectbtn[i].interactable = i <= 6;
            }
            if (scoreManager.StageOn[6] == true)
            {
                Selectbtn[i].interactable = i <= 7;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        if (scoreManager.StageOn[7] == true)
        {
            scoreManager.StageOn[8] = true;
            scoreManager.GetCoinOK = true;
        }
    }

    void AudioSetting()
    {
        Click = GetComponent<AudioSource>();
        Click.clip = ClickAu;
        Click.volume = scoreManager.AudioVolume;
        Click.loop = false;
        Click.playOnAwake = false;
    }
    
    void StopAudio()
    {
        BGMManager.StopBGM();
    }

    public void StopClick()
    {
        StopAudio();
    }

    public void Lv1()
    {
        StopAudio();
        Click.Play();
        stage = stageName[0];
        scoreManager.CoinHozon[0] += scoreManager.coinCounters[0];
        StartCoroutine(Start(stage, 1.5f));
    }

    public void Lv2()
    {
        StopAudio();
        Click.Play();
        stage = stageName[1];
        scoreManager.CoinHozon[1] += scoreManager.coinCounters[1];
        StartCoroutine(Start(stage, 1.5f));
    }

    public void Lv3()
    {
        StopAudio();
        Click.Play();
        stage = stageName[2];
        scoreManager.CoinHozon[2] += scoreManager.coinCounters[2];
        StartCoroutine(Start(stage, 1.5f));
    }

    public void Lv4()
    {
        StopAudio();
        Click.Play();
        stage = stageName[3];
        scoreManager.CoinHozon[3] += scoreManager.coinCounters[3];
        StartCoroutine(Start(stage, 1.5f));
    }

    public void Lv5()
    {
        StopAudio();
        Click.Play();
        stage = stageName[4];
        scoreManager.CoinHozon[4] += scoreManager.coinCounters[4];
        StartCoroutine(Start(stage, 1.5f));
    }

    public void Lv6()
    {
        StopAudio();
        Click.Play();
        stage = stageName[5];
        scoreManager.CoinHozon[5] += scoreManager.coinCounters[5];
        StartCoroutine(Start(stage, 1.5f));
    }

    public void Lv7()
    {
        StopAudio();
        Click.Play();
        stage = stageName[6];
        scoreManager.CoinHozon[6] += scoreManager.coinCounters[6];
        StartCoroutine(Start(stage, 1.5f));
    }

    public void Lv8()
    {
        StopAudio();
        Click.Play();
        stage = stageName[7];
        scoreManager.CoinHozon[7] += scoreManager.coinCounters[7];
        StartCoroutine(Start(stage, 1.5f));
    }
    public void Lv10()
    {
        StopAudio();
        Click.Play();
        stage = stageName[8];
        StartCoroutine(Start(stage, 1.5f));
    }

    public void Cshop()
    {
        Click.Play();
        stage = stageName[9];
        StartCoroutine(Start(stage, 1.5f));
    }
    
    public void BackButton()
    {
        StopAudio();
        Click.Play();
        stage = stageName[10];
        StartCoroutine(Start(stage, 1.5f));
    }

    IEnumerator Start(string StartName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(StartName);
    }
}
