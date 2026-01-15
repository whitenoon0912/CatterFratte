using UnityEngine;

public class Playerls : MonoBehaviour
{
    public AudioClip[] BGMAu;
    public AudioSource BGM;
    private Rigidbody rb;
    private float moveForce = 3f;
    public bool Chrtra = false;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        if (ItemBool.AddAudio && ItemBool.AddAudioClick)
        {
            BGM.volume = scoreManager.AudioVolume;
            BGM.clip = BGMAu[1];
            BGM.loop = true;
            BGM.playOnAwake = true;
            BGM.Play();
        }
        else if (!ItemBool.AddAudio)
        {
            BGM.volume = scoreManager.AudioVolume;
            BGM.clip = BGMAu[0];
            BGM.loop = true;
            BGM.playOnAwake = true;
            BGM.Play();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Chrtra)
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, moveForce);
            anim.SetBool("walk", true);
        }
        else if (Chrtra)
        {
            return;
        }
    }
}
