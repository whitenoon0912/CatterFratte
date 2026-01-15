using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MonkeyActions : MonoBehaviour
{
    private float inputHorizontal;
    private float inputVertical;
    private float maxspeed = 5f;
    private float rayLength = 4f;
    private Vector3 cameraForward;
    private Vector3 moveForward;
    private Rigidbody rb;
    public bool isTouched = false;
    public LayerMask jimen;
    private Animator anim;
    private bool push = false;
    public GameObject[] coin;
    public Animator[] coinAnim;

    public AudioClip coinget;
    public AudioSource coinAu;

    public AudioClip[] BGMAu;
    public AudioSource BGM;
    public bool Chrtra = false;
    public bool setting = false;
    public TMP_Text coinCount;
    private ParticleSystem par;
    private int jumpC;
    private bool IsGet = false;
    private int HP = 3;
    private int maxHp = 4;
    private int CursorCounter = 0;
    private bool isvisied = false;
    public GameObject[] HPvar;
    private int GetCoinCount = 0;

    void Awake()
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        par = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        coinAu = GetComponent<AudioSource>();
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
        if (ItemBool.jumpbool)
        {
            scoreManager.jumpCount = 2;
            jumpC = scoreManager.jumpCount;
        }
        else if (!ItemBool.jumpbool)
        {
            scoreManager.jumpCount = 1;
            jumpC = scoreManager.jumpCount;
        }

        if (ItemBool.HPpulas)
        {
            HP++;
            UpdateHearts();
        }
        else if (!ItemBool.HPpulas)
        {
            Debug.Log("恩恵がないです");
        }
    }

    // Update is called once per frame

    void Update()
    {
        coinCount.text = "コイン：" + scoreManager.coinscore.ToString();
        if (setting) return;
        if (!Chrtra)
        {
            Vector3 origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Vector3 direction = Vector3.down;
            RaycastHit hit;
            if (Physics.Raycast(origin, direction, out hit, rayLength, jimen))
            {
                Debug.DrawRay(origin, direction * rayLength, Color.red);
                isTouched = true;
                anim.SetBool("jump", false);
                scoreManager.jumpCount = jumpC;
            }
            else
            {
                isTouched = false;
                anim.SetBool("jump", true);
                anim.SetBool("walk", false);
            }

            if (!isTouched && scoreManager.jumpCount > 1)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    scoreManager.jumpCount -= 1;
                    rb.linearVelocity = new Vector3(rb.linearVelocity.x, 8.0f, rb.linearVelocity.z);
                    anim.SetBool("jump", true);
                    anim.SetBool("walk", false);
                    push = true;
                }
                else if (Input.GetKeyUp(KeyCode.Space))
                {
                    push = false;
                }
            }
            else if (!isTouched && scoreManager.jumpCount == 0)
            {
                return;
            }


            inputHorizontal = Input.GetAxisRaw("Horizontal");
            inputVertical = Input.GetAxisRaw("Vertical");
            if (Input.GetKeyDown(KeyCode.Space) && isTouched && scoreManager.jumpCount >= 1)
            {
                scoreManager.jumpCount -= 1;
                if (!ItemBool.jumpVectorbool)
                {
                    rb.linearVelocity = new Vector3(rb.linearVelocity.x, 8.0f, rb.linearVelocity.z);
                }
                else if (ItemBool.jumpVectorbool)
                {
                    rb.linearVelocity = new Vector3(rb.linearVelocity.x, 8.0f * scoreManager.jumpVector, rb.linearVelocity.z);
                }
                anim.SetBool("jump", true);
                anim.SetBool("walk", false);
                push = true;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                push = false;
            }


            if ((inputHorizontal == 1 || inputVertical == 1 || inputHorizontal == -1 || inputVertical == -1) && push)
            {
                anim.SetBool("walk", false);
                anim.SetBool("jump", true);
            }
            else if (inputHorizontal == 1 || inputVertical == 1 || inputHorizontal == -1 || inputVertical == -1)
            {
                anim.SetBool("walk", true);
                anim.SetBool("jump", false);
            }
            else
            {
                anim.SetBool("walk", false);
                //anim.SetBool("jump", false);
            }
        }
        else if (Chrtra)
        {
            return;
        }

    }

    void FixedUpdate()
    {
        if (Chrtra || setting) return;
        cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        if (ItemBool.Vectorbool)
        {
            moveForward = cameraForward * inputVertical * 1.15f + Camera.main.transform.right * inputHorizontal * 1.15f;
        }
        else if (!ItemBool.Vectorbool)
        {
            moveForward = cameraForward * inputVertical  + Camera.main.transform.right * inputHorizontal;
        }
        rb.linearVelocity = moveForward * maxspeed + new Vector3(0, rb.linearVelocity.y, 0);

        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("coin"))
        {
            par.Play();
            scoreManager.coinscore++;
            scoreManager.coinCounters[0]++;
            Debug.Log(other.gameObject.name);
            if (coin != null || coinAnim != null)
            {
                var othcl = other.gameObject.GetComponent<Collider>();
                othcl.enabled = false;
                StartCoroutine(objbreak(0.4f, other.gameObject));
                coinAu.volume = scoreManager.coinVolume;
                coinAu.clip = coinget;
                coinAu.loop = false;
                coinAu.playOnAwake = false;
                coinAu.Play();
            }
        }
    }

    IEnumerator objbreak(float delay, GameObject obj)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }

    //追加コード
    private void UpdateHearts()
    {
        for (int i = 0; i < HPvar.Length; i++)
        {
            HPvar[i].SetActive(i < HP);
        }
    }

    void DamageHearts()
    {
        if (HP > 0)//ここから
            {
                HP--;
                UpdateHearts();
            }//ここまで
    }
}
