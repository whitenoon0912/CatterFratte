using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goalManager6 : MonoBehaviour
{
    public GameObject player;
    public PlayerManager6 pm6;
    private Animator anim;
    private Rigidbody rb;
    private int maxjump = 5;
    private float jumptime = 0f;
    private int Count = 0;
    public GameObject cameraobj;
    public CameraManager6 CA;
    public AudioClip goalAu;
    public AudioSource goal;
    public Animator[] text;
    public GameObject[] texters;
    public Fade fade;
    private bool goalAuPlay = false;
    private bool goalCoin = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        anim.SetBool("walk", false);
        anim.SetBool("jump", false);
        goal.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pm6.Chrtra && Count < maxjump)
        {
            transform.LookAt(cameraobj.transform);
            jumptime += Time.deltaTime;
            if (jumptime >= 2f)
            {
                rb.linearVelocity = new Vector3(0, rb.linearVelocity.y + 4, 0);
                anim.SetBool("walk", true);
                anim.SetBool("jump", false);
                Count++;
                jumptime = 0f;
            }
            else
            {
                anim.SetBool("jump", true);
                anim.SetBool("walk", false);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("goal"))
        {
            pm6.Chrtra = true;
            CA.NGaction = true;
            goal.clip = goalAu;
            scoreManager.StageOn[5] = true;
            goal.volume = scoreManager.goalVolume;
            goal.loop = false;
            goal.playOnAwake = false;
            if (!goalAuPlay)
            {
                goal.Play();
                goalAuPlay = true;
            }
            if (!goalCoin && ItemBool.GetCoin)
            {
                scoreManager.coinscore = Mathf.RoundToInt(scoreManager.coinscore * (100 + 15) / 100);
                scoreManager.coinscore += 3;
                goalCoin = true;
            }
            pm6.BGM.Stop();
            StartCoroutine(texterAnim(1f));
            StartCoroutine(fadein(5f));
            foreach (GameObject obj in texters)
            {
                obj.SetActive(true);
            }
        }
    }

    IEnumerator texterAnim(float delay)
    {

        yield return new WaitForSeconds(delay / 2);
        text[0].SetBool("ku", true);
        yield return new WaitForSeconds(delay);
        text[1].SetBool("ri", true);
        yield return new WaitForSeconds(delay);
        text[2].SetBool("a", true);
        yield return new WaitForSeconds(delay);
        text[3].SetBool("!", true);
        yield return new WaitForSeconds(delay / 2);
    }

    IEnumerator fadein(float delay)
    {
        yield return new WaitForSeconds(delay);
        fade.FadeIn(1f);
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene("HomeScene");
    }
}
