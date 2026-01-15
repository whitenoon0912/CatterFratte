using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OnSceneCuror: MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.shadows = ShadowQuality.Disable;
        StartCoroutine(Start());
    }
    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        if (SceneManager.GetActiveScene().name == "HomeScene")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (SceneManager.GetActiveScene().name == "MonkeyFratte" ||
                SceneManager.GetActiveScene().name == "Lv2Scene" ||
                SceneManager.GetActiveScene().name == "Lv3Scene" ||
                SceneManager.GetActiveScene().name == "Lv4Scene" ||
                SceneManager.GetActiveScene().name == "Lv5Scene" ||
                SceneManager.GetActiveScene().name == "Lv6Scene" ||
                SceneManager.GetActiveScene().name == "Lv7Scene" ||
                SceneManager.GetActiveScene().name == "Lv8Scene" ||
                SceneManager.GetActiveScene().name == "Lv9Scene" ||
                SceneManager.GetActiveScene().name == "Lv10Scene")
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Update()
    {
        CursorActived();
    }
    
    void CursorActived()
    {
        if (SceneManager.GetActiveScene().name == "HomeScene")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (SceneManager.GetActiveScene().name == "MonkeyFratte" ||
                SceneManager.GetActiveScene().name == "Lv2Scene" ||
                SceneManager.GetActiveScene().name == "Lv3Scene" ||
                SceneManager.GetActiveScene().name == "Lv4Scene" ||
                SceneManager.GetActiveScene().name == "Lv5Scene" ||
                SceneManager.GetActiveScene().name == "Lv6Scene" ||
                SceneManager.GetActiveScene().name == "Lv7Scene" ||
                SceneManager.GetActiveScene().name == "Lv8Scene" ||
                SceneManager.GetActiveScene().name == "Lv9Scene" ||
                SceneManager.GetActiveScene().name == "Lv10Scene")
        {
            Debug.Log("今のシーンは：" + SceneManager.GetActiveScene().name);

            bool isOverUI = EventSystem.current.IsPointerOverGameObject();

            if (isOverUI)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                return;
            }
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }

            if (!Cursor.visible && !Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
