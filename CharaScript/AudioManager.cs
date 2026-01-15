using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] bg;
    public AudioSource bgAu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        BGMManager.SetAudioManager(this);
        PlayBGM();
    }
    public void PlayBGM()
    {
        if (ItemBool.AddAudio && ItemBool.AddAudioClick)
        {
            bgAu.clip = bg[1];
            bgAu.loop = true;
            bgAu.playOnAwake = true;
            bgAu.Play();
            DontDestroyOnLoad(gameObject);
        }
        else if (!ItemBool.AddAudioClick)
        {
            bgAu.clip = bg[0];
            bgAu.loop = true;
            bgAu.playOnAwake = true;
            bgAu.Play();
            DontDestroyOnLoad(gameObject);
        }

    }
    
    public void StopBGM()
    {
        bgAu.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioClicks()
    {
        StopBGM();
        bgAu.clip = bg[0];
        bgAu.loop = true;
        bgAu.playOnAwake = true;
        bgAu.Play();
        DontDestroyOnLoad(gameObject);
        ItemBool.AddAudioClick = false;
    }
    
    public void AudioClicks2()
    {
        StopBGM();
        bgAu.clip = bg[1];
        bgAu.loop = true;
        bgAu.playOnAwake = true;
        bgAu.Play();
        DontDestroyOnLoad(gameObject);
        ItemBool.AddAudioClick = true;
    }
}
