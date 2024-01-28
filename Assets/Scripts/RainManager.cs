using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainManager : MonoBehaviour
{
    [SerializeField]
    RainObject[] _rainPool;
    // Start is called before the first frame update
    void Start()
    {
        _rainPool=FindObjectsOfType<RainObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendRain(FloorPlate currentPlate)
    {
        for (int i = 0; i < _rainPool.Length; i++)
        {
            if (!_rainPool[i].IsOccupied)
            {
                _rainPool[i].MoveToRainPoint(currentPlate.RainSelectedPosition());
                currentPlate.ActualObject = _rainPool[i];
                break;
            }
        }
    }


}
