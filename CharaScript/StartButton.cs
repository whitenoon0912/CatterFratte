using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject text;
    public GameObject Button;
    public GameObject Board;
    public GameObject[] minas;
    public GameObject[] pulas;
    public TMP_Text[] Scaletext;
    public AudioClip Click;
    private AudioSource ClickAu;
    private int ClickCount = 0;
    public AudioManager am;
    public AudioManager2 am2;
    public GameObject[] texter;
    public TMP_Text coinCount;
    public Fade fade;
    public GameObject Cshop;
    private int AudioClickCount = 0;
    public GameObject BG;
    public GameObject title;
    public GameObject No1;
    public GameObject No2;
    public GameObject Audio1;
    public GameObject Audio2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = true;
        ClickAu = GetComponent<AudioSource>();
        ClickAu.clip = Click;
        ClickAu.loop = false;
        ClickAu.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        coinCount.text = "コイン：" + scoreManager.coinscore;
        float targetAudio = scoreManager.AudioVolume;
        am.bgAu.volume = targetAudio;
        ClickAu.volume = targetAudio;
        am2.Audio[0].volume = scoreManager.coinVolume;
        am2.Audio[1].volume = scoreManager.goalVolume;
        Scaletext[0].text = scoreManager.AudioVolume.ToString("F1");
        Scaletext[1].text = scoreManager.coinVolume.ToString("F1");
        Scaletext[2].text = scoreManager.goalVolume.ToString("F1");
    }

    public void SelectButton()
    {
        ClickAu.Play();
        StartCoroutine(Scene1(1f));
    }

    public void Setting()
    {
        ClickCount++;
        if (ClickCount == 1)
        {
            Cshop.SetActive(false);
            Board.SetActive(true);
            Button.SetActive(false);
            text.SetActive(false);
            foreach (GameObject obj in pulas)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in minas)
            {
                obj.SetActive(true);
            }
            foreach (TMP_Text obj in Scaletext)
            {
                obj.gameObject.SetActive(true);
            }
            foreach (GameObject obj in texter)
            {
                obj.SetActive(true);
            }
        }
        else if (ClickCount == 2)
        {
            Board.SetActive(false);
            Button.SetActive(true);
            text.SetActive(true);
            Cshop.SetActive(true);
            foreach (GameObject obj in pulas)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in minas)
            {
                obj.SetActive(false);
            }
            foreach (TMP_Text obj in Scaletext)
            {
                obj.gameObject.SetActive(false);
            }
            foreach (GameObject obj in texter)
            {
                obj.SetActive(false);
            }
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
        ClickAu.Play();
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
        am2.Audio[0].Play();
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
        am2.Audio[1].Play();
    }

    public void minusButton1()
    {
        if (scoreManager.AudioVolume <= 0)
        {
            scoreManager.AudioVolume = 0;
        }
        else if (scoreManager.AudioVolume > 0)
        {
            scoreManager.AudioVolume -= 0.1f;
        }
        ClickAu.Play();
    }
    public void minusButton2()
    {
        if (scoreManager.coinVolume <= 0)
        {
            scoreManager.coinVolume = 0;
        }
        else if (scoreManager.coinVolume > 0)
        {
            scoreManager.coinVolume -= 0.1f;
        }
        am2.Audio[0].Play();
    }
    public void minusButton3()
    {
        if (scoreManager.goalVolume <= 0)
        {
            scoreManager.goalVolume = 0;
        }
        else if (scoreManager.goalVolume > 0)
        {
            scoreManager.goalVolume -= 0.1f;
        }
        am2.Audio[1].Play();
    }

    IEnumerator Scene1(float delay)
    {
        fade.FadeIn(delay);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("SelectStage");
    }

    public void AudioButton()
    {
        AudioClickCount++;
        if (AudioClickCount == 1)
        {
            BG.SetActive(true);
            title.SetActive(true);
            No1.SetActive(true);
            Audio1.SetActive(true);
            if (ItemBool.AddAudio)
            {
                No2.SetActive(true);
                Audio2.SetActive(true);
            }
            else if (!ItemBool.AddAudio)
            {
                No2.SetActive(false);
                Audio2.SetActive(false);
            }
        }
        else if (AudioClickCount == 2)
        {
            BG.SetActive(false);
            title.SetActive(false);
            No1.SetActive(false);
            No2.SetActive(false);
            Audio1.SetActive(false);
            Audio2.SetActive(false);
            AudioClickCount = 0;
        }
    }
}
