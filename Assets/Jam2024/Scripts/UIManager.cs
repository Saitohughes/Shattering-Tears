using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public enum Gimmicks
    {
        Default,
        Hielo,
        Borracho,
        Disco
    }
    public Gimmicks currentGimmick;
    public GameObject[] gimmickObjects;
    public GameObject countdown;
    //public TMP_Text scoreText;

    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.G)) {
            GimmickPlayer();
        }
    }
    public void StartCountdown(bool isElementActive)
    {

        Instantiate(countdown);

    }

    public void GimmickPlayer()
    {
        switch (currentGimmick)
        {
            case Gimmicks.Default:
                gimmickObjects[0].SetActive(true);
                break;
            case Gimmicks.Hielo:
                gimmickObjects[1].SetActive(true);
                break;
            case Gimmicks.Borracho:
                Debug.Log("3");
                break;
            case Gimmicks.Disco:
                Debug.Log("4");
                break;
        }

    }
}
