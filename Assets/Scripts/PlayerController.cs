using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using ToonBoom.Harmony;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using MoreMountains.Feedbacks;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Animator myAnim;

    [SerializeField]
    MMFeedbacks deadScreen;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public Vector3 PlayerMovement()
    {
         movInput = playerInput.actions["Move"].ReadValue<Vector2>();
        if (movInput.magnitude == 0)
        {
            myAnim.SetBool("F", false);
            myAnim.SetBool("L", false);
            myAnim.SetBool("B", false);
            myAnim.SetBool("R", false);
        }
        if (movInput.y>0)
        {
            myAnim.SetBool("F", false);
            myAnim.SetBool("L", false);
            myAnim.SetBool("B", true);
            myAnim.SetBool("R", false);
        } 
        if (movInput.y<0)
        {
            myAnim.SetBool("B", false);
            myAnim.SetBool("F", true);
            myAnim.SetBool("L", false);
            myAnim.SetBool("R", false);
        } 
        if (movInput.x>0)
        {
            myAnim.SetBool("R", true);
            myAnim.SetBool("F", false);
            myAnim.SetBool("L", false);
            myAnim.SetBool("B", false);
        } if (movInput.x>0)
        {
            myAnim.SetBool("L", true);
            myAnim.SetBool("F", false);
            myAnim.SetBool("B", false);
            myAnim.SetBool("R", false);
        }
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
            deadScreen.PlayFeedbacks();
            //Dead();
        }
    }

    public void Dead()
    {
        SceneManager.LoadScene("scn_Dead");
    }

}
