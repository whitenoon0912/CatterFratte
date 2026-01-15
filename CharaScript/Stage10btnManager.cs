using UnityEngine;

public class Stage10btnManager : MonoBehaviour
{
    public GameObject stage10Button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreManager.StageOn[8] == true && ItemBool.coinbool[0] >= 1 && ItemBool.coinbool[1] >= 1 && ItemBool.coinbool[2] >= 1)
        {
            stage10Button.SetActive(true);
        }
        else
        {
            stage10Button.SetActive(false);
        }
    }
}
