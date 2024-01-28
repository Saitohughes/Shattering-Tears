using System.Collections;
using System.Collections.Generic;
using System.Media;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class UmanPartyGameManager : MonoBehaviour
{
    public static UmanPartyGameManager instance;
    //manager de las propiedades del juego
    [Header("Gimic Parameters")]
    [SerializeField]
    FloorPlate[] _plates;
    int[,] _grid;
    [SerializeField]
    StateTypes _actualState;

    [Header("Match and Game parameters")]
    [SerializeField]
    float roundTime;
    float parameter = 30;
    List<UManPlayerController> _players;
    [SerializeField]
    AudioSource _bombSound;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this.gameObject);
    }

    //UiManager
    public IEnumerator  Round()
    {
       while(roundTime >= 20f)
        {

            
            yield return null;

        }

        yield return 1f;
        EndRound(); 

    }
    public void EndRound() 
    {
    
    
    }

    public void PutBomb(UManPlayerController victim)
    {
        victim.AddComponent<Bomb>();
        victim.ReceiveBomb();
        victim.BombRender.SetActive(true);
        victim.TryGetComponent<Bomb>(out Bomb bomb);
        if (bomb)
        {
            bomb.ActiveBomb( parameter - 10f);
            bomb.Sound = _bombSound;
          switch (parameter)
            {
                case (30f):
                    
                    break;
            }
        }
     

    }

    public void CreateGrid()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
