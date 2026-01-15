
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerManager8 : MonoBehaviour
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
    public GameObject[] HPvar;
    public GameObject maincamera;
    public Collider col;
    public bool CameraAc = false;
    private bool downHp = false;
    private bool restart = false;
    private bool GameOver = false;
    [SerializeField]private Transform playerpos;
    public Fade fade;
    public TMP_Text[] GAMEOVER;
    public GameObject[] retitle;
    private string[] titlename = { "Lv2Scene", "HomeScene", "Lv3Scene", "Lv5Scene", "Lv7Scene", "Lv8Scene" };
    private string titlename2;
    public GameObject Goals;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        par = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        coinAu = GetComponent<AudioSource>();
        var goalac = Goals.GetComponent<BoxCollider>();
        goalac.enabled = false;
        Goals.SetActive(false);
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
        mainMesod();
        if (GameOver)
        {
            if (HP == 0)
            {
                Debug.Log("HPが０になりました");
                CameraAc = true;
                StartCoroutine(PlayAnimations(GAMEOVER, 2f));
            }
            else if (HP > 0)
            {
                col.enabled = true;
                CameraAc = false;
                transform.position = new Vector3(362.3f,7.78f,428.8f);
                Rigidbody rb = GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.linearVelocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
                StartCoroutine(cooltimer(2f));
            }
            GameOver = false;
        }
        else
        {
            return;
        }
    }

    void mainMesod()
    {
        coinCount.text = "コイン：" + scoreManager.coinscore.ToString();
        if (transform.position.y < -40)
        {
            Debug.Log("Trigger Entered by sea at y=" + transform.position.y);
            CameraAc = true;
            col.enabled = false;
        }

        if (transform.position.y < -100)
        {
            GameOver = true;
        }
            
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
                int layerIndex = hit.collider.gameObject.layer;
                if (LayerMask.LayerToName(layerIndex) == "rocker")
                {
                    rb.linearVelocity = new Vector3(rb.linearVelocity.x, 10.0f, rb.linearVelocity.z);
                }

                if (LayerMask.LayerToName(layerIndex) == "StartRock")
                {
                    transform.position = new Vector3(362.3f, 7.78f, 428.8f);
                    var goalac2 = Goals.GetComponent<BoxCollider>();
                    goalac2.enabled = true;
                    Goals.SetActive(true);
                }
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
            scoreManager.coinCounters[7]++;
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

    IEnumerator cooltimer(float delay)
    {
        if (!downHp)
        {
            DamageHearts();
            downHp = true;
        }
        setting = true;
        yield return new WaitForSeconds(delay);
        switch (HP)
        {
            case 4:
                StartCoroutine(HPDown(2f, HPvar));
                break;
            case 3:
                StartCoroutine(HPDown2(2f, HPvar));
                break;
            case 2:
                StartCoroutine(HPDown3(2f, HPvar));
                break;
            case 1:
                StartCoroutine(HPDown4(2f, HPvar));
                break;
            case 0:
                StartCoroutine(HPDown5(2f));
                break;
        }
    }

    IEnumerator HPDown(float delay, GameObject[] HP)
    {
        Debug.Log("コルーチン作動中");
        if (HP == null) yield break;
        List<Vector2> pos = new List<Vector2>();
        for (int i = 0; i < HP.Length; i++)
        {
            RectTransform rect = HP[i].GetComponent<RectTransform>();
            pos.Add(rect.anchoredPosition);
        }

        Vector2[] SP = pos.ToArray();

        Vector2[] endpos = new Vector2[]
        {
            new Vector2(-82f, 0f),
            new Vector2(-28f, 0f),
            new Vector2(28f, 0f),
            new Vector2(81f, 0f),
        };

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / delay;
            for (int i = 0; i < SP.Length; i++)
            {
                SP[i] = Vector2.Lerp(SP[i], endpos[i], Mathf.Clamp01(t));
                HP[i].GetComponent<RectTransform>().anchoredPosition = SP[i];
            }
            yield return null;
        }

        for (int i = 0; i < endpos.Length; i++)
        {
            HP[i].GetComponent<RectTransform>().anchoredPosition = endpos[i];
        }

        yield return new WaitForSeconds(delay);
        StartCoroutine(ReturnHearts(2f, HPvar));
    }

    IEnumerator HPDown2(float delay, GameObject[] HP)
    {
        if (HP == null) yield break;
        List<Vector2> pos = new List<Vector2>();

        for (int i = 0; i < HP.Length; i++)
        {
            RectTransform rect = HP[i].GetComponent<RectTransform>();
            pos.Add(rect.anchoredPosition);
        }

        Vector2[] startpos = pos.ToArray();

        Vector2[] endpos = new Vector2[HP.Length];
        for (int i = 0; i < HP.Length; i++)
        {
            endpos[i] = new Vector2(-28f + (28f * i), 0f);
        }

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime/delay;
            for (int i = 0; i < startpos.Length; i++)
            {
                startpos[i] = Vector2.Lerp(startpos[i], endpos[i], Mathf.Clamp01(t));
                HP[i].GetComponent<RectTransform>().anchoredPosition = startpos[i];
            }
            yield return null;
        }

        for (int i = 0; i < endpos.Length; i++)
        {
            HP[i].GetComponent<RectTransform>().anchoredPosition = endpos[i];
        }
        yield return new WaitForSeconds(delay);
        StartCoroutine(ReturnHearts(2f, HPvar));
    }

    IEnumerator HPDown3(float delay, GameObject[] HP)
    {
        if (HP == null) yield break;
        List<Vector2> pos = new List<Vector2>();

        for (int i = 0; i < HP.Length; i++)
        {
            RectTransform rect = HP[i].GetComponent<RectTransform>();
            pos.Add(rect.anchoredPosition);
        }

        Vector2[] startpos = pos.ToArray();

        Vector2[] endpos = new Vector2[HP.Length];
        for (int i = 0; i < HP.Length; i++)
        {
            float x = (i == 0) ? -28f : 28f;
            endpos[i] = new Vector2(x, 0f);
        }


        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime/delay;
            for (int i = 0; i < startpos.Length; i++)
            {
                startpos[i] = Vector2.Lerp(startpos[i], endpos[i], Mathf.Clamp01(t));
                HP[i].GetComponent<RectTransform>().anchoredPosition = startpos[i];
            }
            yield return null;
        }

        for (int i = 0; i < endpos.Length; i++)
        {
            HP[i].GetComponent<RectTransform>().anchoredPosition = endpos[i];
        }

        yield return new WaitForSeconds(delay);
        StartCoroutine(ReturnHearts(2f, HPvar));
    }

    IEnumerator HPDown4(float delay, GameObject[] HP)
    {
        if (HP == null) yield break;
        List<Vector2> pos = new List<Vector2>();

        for (int i = 0; i < HP.Length; i++)
        {
            RectTransform rect = HP[i].GetComponent<RectTransform>();
            pos.Add(rect.anchoredPosition);
        }

        Vector2[] startpos = pos.ToArray();

        Vector2[] endpos = new Vector2[HP.Length];
        for (int i = 0; i < HP.Length; i++)
        {
            endpos[i] = new Vector2(0f, 0f);
        }


        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / delay;
            for (int i = 0; i < startpos.Length; i++)
            {
                startpos[i] = Vector2.Lerp(startpos[i], endpos[i], Mathf.Clamp01(t));
                HP[i].GetComponent<RectTransform>().anchoredPosition = startpos[i];
            }
            yield return null;
        }

        for (int i = 0; i < endpos.Length; i++)
        {
            HP[i].GetComponent<RectTransform>().anchoredPosition = endpos[i];
        }

        yield return new WaitForSeconds(delay);
        StartCoroutine(ReturnHearts(2f, HPvar));
    }

    IEnumerator HPDown5(float delay)
    {
        yield return new WaitForSeconds(delay);
        setting = false;
    }

    IEnumerator ReturnHearts(float delay, GameObject[] HPobj)
    {
        if (HPobj == null) yield break;

        List<Vector2> pos = new List<Vector2>();

        for (int i = 0; i < HPobj.Length; i++)
        {
            RectTransform rect = HPobj[i].GetComponent<RectTransform>();
            pos.Add(rect.anchoredPosition);
        }

        Vector2[] startpos = pos.ToArray();

        float t = 0f;

        switch (HP)
        {
            case 3:
                Vector2[] endpos1 = new Vector2[HPobj.Length];
                for (int i = 0; i < HPobj.Length; i++)
                {
                    endpos1[i] = new Vector2(-333 + (i * 55), 202);
                }

                while (t < 1f)
                {
                    t += Time.deltaTime / delay;
                    for (int i = 0; i < HPobj.Length; i++)
                    {
                        startpos[i] = Vector2.Lerp(startpos[i], endpos1[i], Mathf.Clamp01(t));
                        HPobj[i].GetComponent<RectTransform>().anchoredPosition = startpos[i];
                    }
                    yield return null;
                }

                for (int i = 0; i < startpos.Length; i++)
                {
                    HPobj[i].GetComponent<RectTransform>().anchoredPosition = endpos1[i];
                }
                break;
            case 2:
                Vector2[] endpos2 = new Vector2[HPobj.Length];
                for (int i = 0; i < HPobj.Length; i++)
                {
                    float x = (i == 0) ? -333f : -279f;
                    endpos2[i] = new Vector2(x, 202);
                }

                while (t < 1f)
                {
                    t += Time.deltaTime / delay;
                    for (int i = 0; i < HPobj.Length; i++)
                    {
                        startpos[i] = Vector2.Lerp(startpos[i], endpos2[i], Mathf.Clamp01(t));
                        HPobj[i].GetComponent<RectTransform>().anchoredPosition = startpos[i];
                    }
                    yield return null;
                }

                for (int i = 0; i < startpos.Length; i++)
                {
                    HPobj[i].GetComponent<RectTransform>().anchoredPosition = endpos2[i];
                }
                break;
            case 1:
                Vector2[] endpos3 = new Vector2[HPobj.Length];
                for (int i = 0; i < HPobj.Length; i++)
                {
                    endpos3[i] = new Vector2(-351, 187);
                }

                while (t < 1f)
                {
                    t += Time.deltaTime / delay;
                    for (int i = 0; i < HPobj.Length; i++)
                    {
                        startpos[i] = Vector2.Lerp(startpos[i], endpos3[i], Mathf.Clamp01(t));
                        HPobj[i].GetComponent<RectTransform>().anchoredPosition = startpos[i];
                    }
                    yield return null;
                }

                for (int i = 0; i < startpos.Length; i++)
                {
                    HPobj[i].GetComponent<RectTransform>().anchoredPosition = endpos3[i];
                }
                break;
        }
        downHp = false;
        setting = false;
    }

    IEnumerator PlayAnimations(TMP_Text[] texter, float delay)
    {
        if (texter == null) yield break;
        Debug.Log("コルーチン作動中");
        foreach (var text in GAMEOVER)
        {
            Debug.Log("foreach作動中");
            text.gameObject.SetActive(true);
        }
        foreach (GameObject btn in retitle)
        {
            btn.SetActive(true);
        }
        for (int i = 0; i < texter.Length; i++)
        {
            Debug.Log("for作動中");
            Animator anim = texter[i].GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetTrigger("Play");
            }
            yield return new WaitForSeconds(delay);
        }
    }

    public void titlebtnClick()
    {
        titlename2 = titlename[1];
        StartCoroutine(transfade(1.5f));
    }

    public void restartbtnClick()
    {
        titlename2 = titlename[5];
        StartCoroutine(transfade(1.5f));
    }

    IEnumerator transfade(float delay)
    {
        fade.FadeIn(delay);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(titlename2);
    }
}
