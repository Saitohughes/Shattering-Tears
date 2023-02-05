using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.CodeDom;

public class Maps : MonoBehaviour
{
    //propertys of maps
    [SerializeField]
    CinemachineVirtualCamera myCam;
    [SerializeField]
    TriggerActive myDoor;
    [SerializeField]
    Maps lastLevel,nextLevel;
    [SerializeField]
    Transform startPosition, nextPosition;
    [SerializeField]
    PlayerController myPlayer;

    public Maps NextLevel { get => nextLevel; set => nextLevel = value; }
    public CinemachineVirtualCamera MyCam { get => myCam; set => myCam = value; }
    public Transform StartPosition { get => startPosition; set => startPosition = value; }
    public TriggerActive MyDoor { get => myDoor; set => myDoor = value; }
    public Maps LastLevel { get => lastLevel; set => lastLevel = value; }

    // Start is called before the first frame update
    void Awake()
    {
        myCam = GetComponentInChildren<CinemachineVirtualCamera>();
        myDoor = GetComponentInChildren<TriggerActive>();
        myPlayer = FindObjectOfType<PlayerController>();

    }
    public void StartLevel()
    {

        nextPosition = nextLevel.startPosition;
        if (LastLevel != null)
        {
            Debug.Log("Estoy haciendo el inicio del nivel");
            myCam.Priority = LastLevel.MyCam.Priority + 1;
            LastLevel.DisableLevel(); 
        }

       myDoor.onTrigger.AddListener(Teleport);
    }

    public void DisableLevel()
    {
      //gameObject.SetActive(false);
        myDoor.enabled=false;
        myCam.Priority=0;



    }
    public void Teleport()
    {

        myPlayer.Teleport(nextPosition);
 
        nextLevel.StartLevel();
        Debug.Log("Estoy Haciendo El metodo");

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
