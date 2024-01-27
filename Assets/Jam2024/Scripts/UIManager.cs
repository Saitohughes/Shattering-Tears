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
    public GameObject[] gimmicks;
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

    private void Start()
    {
        
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
                Debug.Log("Holi");
                break;
            case Gimmicks.Hielo:
                Debug.Log("holi2");
                break;
            case Gimmicks.Borracho:
                Debug.Log("holi3");
                break;
            case Gimmicks.Disco:
                Debug.Log("Holi4");
                break;
        }

    }
}
