using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MoreMountains;
using MoreMountains.Feedbacks;

public class UIManager : MonoBehaviour
{
    public enum Gimmicks
    {
        Hielo,
        Borracho,
        Disco,
        Lluvia
    }

    public Gimmicks currentGimmick;
    public GameObject[] gimmickObjects;
    public GameObject countdown;
    //public TMP_Text scoreText;

    [Header("Feedbacks")]

    public MMF_Player borrachoFeedback;
    public MMF_Player hieloFeedback;
    public MMF_Player discoFeedback;
    public MMF_Player lluviaFeedback;

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
        RandomlyChooseGimmick();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
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
            case Gimmicks.Hielo:
                gimmickObjects[0].SetActive(true);
                hieloFeedback?.PlayFeedbacks();
                break;
            case Gimmicks.Borracho:
                gimmickObjects[1].SetActive(true);
                borrachoFeedback?.PlayFeedbacks();
                break;
            case Gimmicks.Disco:
                gimmickObjects[2].SetActive(true);
                discoFeedback?.PlayFeedbacks();
                break;
            case Gimmicks.Lluvia:
                gimmickObjects[3].SetActive(true);
                lluviaFeedback?.PlayFeedbacks();
                break;
        }
    }

    private void RandomlyChooseGimmick()
    {
        // Get all values from the Gimmicks enum
        Gimmicks[] gimmickValues = (Gimmicks[])System.Enum.GetValues(typeof(Gimmicks));

        int randomIndex = Random.Range(0, gimmickValues.Length);

        currentGimmick = gimmickValues[randomIndex];
    }
}
