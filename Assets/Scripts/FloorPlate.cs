using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;


public enum StateTypes
{
   RAIN,
   EARTHQUAKE,
   ICE,
   DRUNK,
   DISCO,

}
[RequireComponent(typeof(Collider))]

public class FloorPlate : MonoBehaviour
{
    // Start is called before the first frame update

    //una lista de estados check
    //un cambio de estado
    //el cambio de estado
    //activadores
    [Header("Base Parameters")]
    [SerializeField]
    private StateTypes _types;

    [Header("Rain Parameters")]
    [SerializeField]
    RainObject _actualObject;
    [SerializeField]
    RainManager _rainManager;//
    [SerializeField]
    Transform[] _rainPositions;

    [Header("Earthquake Parameters")]
    Vector3 _newPositionl;
    Vector3 _originalPosition;

    [Header("Ice parameters")]
    Collider _myCol;
    [SerializeField]
    PhysicMaterial _iceMat;

    public RainObject ActualObject { get => _actualObject; set => _actualObject = value; }

    void Start()
    {
        _rainManager=FindObjectOfType<RainManager>();
        _myCol=GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            ActiveStates();
        
        }
    }
    
    /// <summary>
    /// Funcion para activar los estados dependiendo de su tipo
    /// </summary>
    ///
    public void ActiveStates()
    {
        switch (_types)
        {
            case StateTypes.RAIN:
                _rainManager.SendRain(this);
                break;
            case StateTypes.EARTHQUAKE:
                if (!LeanTween.isTweening(this.gameObject))
                {
                    LeanTween.moveLocalY(this.gameObject, transform.position.y + 0.5f, 0.5f).setDelay(Random.Range(0, 4)).
                               setEase(LeanTweenType.easeInBounce).
                               setOnComplete(() => { LeanTween.moveLocalY(this.gameObject, transform.position.y - 0.5f, 0.5f); }); 
                }

                break;
            case StateTypes.ICE:
                _myCol.material = _iceMat;
                //variables del personaje 

                break;
        }

    }

    public Transform RainSelectedPosition()
    {
        return _rainPositions[Random.Range(0,_rainPositions.Length)];
    }
     // f(x) = y

}
