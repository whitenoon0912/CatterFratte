using UnityEngine;

public class AudioManager2 : MonoBehaviour
{
    public AudioClip getcoin;
    public AudioClip goal;
    public AudioSource[] Audio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (AudioSource obj in Audio)
        {
            obj.GetComponents<AudioSource>();
        }
        Audio[0].clip = getcoin;
        Audio[1].clip = goal;

        Audio[0].loop = false;
        Audio[1].loop = false;

        Audio[0].playOnAwake = false;
        Audio[1].playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
