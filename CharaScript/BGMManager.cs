using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private static AudioManager instance;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static void SetAudioManager(AudioManager am)
    {
        instance = am;
    }

    // Update is called once per frame
    public static void PlayBGM()
    {
        if (instance != null)
        {
            instance.PlayBGM();
        }
    }
    public static void StopBGM()
    {
        if (instance != null)
        {
            instance.StopBGM();
        }
    }
}
