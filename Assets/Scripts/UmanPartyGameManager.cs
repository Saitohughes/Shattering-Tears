using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmanPartyGameManager : MonoBehaviour
{
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
    List<UManPlayerController> _players;

   



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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
