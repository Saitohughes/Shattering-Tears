using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class UManPlayerController : MonoBehaviour
{
    [SerializeField]
    float Score;
    Rigidbody[] _allrigidbodies;
    [SerializeField]
    Animator _animatedAnimator,_physicalAnimator;
    Rigidbody _physicalHips;
    Transform _animatedHips;

    [Header("Fisica")]
    [SerializeField]
    float _movementSpeed;
    Vector3 _forceDirection=Vector3.zero;



    [SerializeField]
    ConfigurableJoint[] _physicaljoints;
    [SerializeField]
    Transform[] _animateBones;
    [SerializeField]
    Quaternion[] _initialJointRotation;

    //inputActions
    ActiveRagdollActions _activeRagdollActions;
    
   
   
    private void Awake()
    {
        _activeRagdollActions = new ActiveRagdollActions();


       
 
        var animators  = GetComponentsInChildren<Animator>();

        if (animators.Length == 2)
        {
            _physicalAnimator = animators[0];
            _animatedAnimator = animators[1];

        }
        if (_physicalHips==null)
        {
            _physicalHips = _physicalAnimator.GetBoneTransform(HumanBodyBones.Hips).GetComponent<Rigidbody>();
        }
        if (_animatedHips==null)
        {
            _animatedHips = _animatedAnimator.GetBoneTransform(HumanBodyBones.Hips);

        }

        _allrigidbodies =  _physicalHips.GetComponentsInChildren<Rigidbody>();
        //_physicaljoints = _physicalHips.GetComponentsInChildren<ConfigurableJoint>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _activeRagdollActions.Player.Move.performed += OnMove;

        foreach (Rigidbody rb in _allrigidbodies)
        {
            rb.solverIterations = 8;
            rb.solverVelocityIterations = 8;
            rb.maxAngularVelocity = 30;
        }
        _initialJointRotation = new Quaternion[_physicaljoints.Length];
        for (int i = 0; i < _physicaljoints.Length; i++)
        {
            _initialJointRotation[i] = _physicaljoints[i].transform.localRotation;
        }
    }

    private void FixedUpdate()
    {

        //OnMove();

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void PutBomb(UManPlayerController victim)
    {
        victim.AddComponent<Bomb>();

    }
    public void UpdateAnim()
    {
        for (int i = 0; i < _physicaljoints.Length; i++)
        {
            ConfigurableJointExtensions.SetTargetRotationLocal(_physicaljoints[i], _animateBones[i].rotation, _initialJointRotation[i]);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        //UpdateAnim();
        Vector3 direccion = new Vector3(context.ReadValue<Vector2>().x, 0f, context.ReadValue<Vector2>().y) * _movementSpeed;
        _forceDirection += direccion;
        Debug.Log(context.ReadValue<Vector2>());
        Debug.Log("Mul" + _movementSpeed);
        Debug.Log(direccion);
        _physicalHips.AddForce(_forceDirection, ForceMode.Impulse);
        _forceDirection = Vector3.zero;
    }

}
