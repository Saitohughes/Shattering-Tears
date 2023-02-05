using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using ToonBoom.Harmony;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    PlayerInput playerInput;
    CharacterController myControl;
    Camera myCamera;

    [SerializeField]
    float speed;
    public static PlayerController instance;


    [SerializeField]
    Vector2 movInput;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
 
        playerInput=GetComponent<PlayerInput>();
        myControl=GetComponent<CharacterController>();


    }
     void Start()
    {
        //playerInput.actions["Move"].performed += IBindCtx => PlayerMovement();
    }

    // Update is called once per frame
    void Update()
    {
        myControl.Move(PlayerMovement());
        
    }

    public Vector3 PlayerMovement()
    {
         movInput = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 finalMov = new Vector3(movInput.x,0f, movInput.y) * speed;
        //myControl.Move(finalMov);
        return finalMov;
    }
    public void Teleport(Transform newPosition)
    {
        Debug.Log("Estoy Haciendo El metodo desde el player");
        myControl.enabled = false;
        gameObject.transform.position = newPosition.position;

        Invoke("ReActiveControl", 0.5f);
    }
    public void ReActiveControl()
    {
        myControl.enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DeadTrigger")
        {
            Dead();
        }
    }

    public void Dead()
    {
        SceneManager.LoadScene("scn_Dead");
    }

}
