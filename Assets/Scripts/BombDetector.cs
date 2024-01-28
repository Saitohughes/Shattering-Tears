using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb")) {


            UmanPartyGameManager.instance.PutBomb(other.GetComponentInParent<UManPlayerController>());

                
                
        }
    }
}
