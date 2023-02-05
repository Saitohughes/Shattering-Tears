using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class RotateToTarget : MonoBehaviour
{
    [SerializeField] float rotationSpeed,speed;
    [SerializeField] Vector3 direction;
    PlayerController myplayer;
    [SerializeField] float angle;
    [SerializeField] bool follow,detect;
    [SerializeField]Transform originalPos;
    [SerializeField]float distanceDect,followDistance;

    public bool Follow { get => follow; set => follow = value; }
    public bool Detect { get => detect; set => detect = value; }

    private void Start()
    {
        myplayer= PlayerController.instance;
    }


    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, myplayer.transform.position);

        OnFollow(distance);
        
        if (Detect)
        {
            direction = myplayer.transform.position - transform.position;

            angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
            Vector3 dir = new Vector3(90f, 0f, angle);
            Quaternion rotation = Quaternion.Euler(dir);

            //Quaternion newdir = new Quaternion(90f, 0, angle,1);
            //Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);


            if (follow)
            {
                transform.position = Vector3.MoveTowards(transform.position, myplayer.transform.position, speed);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPos.position, speed);
        }
    }

    public void OnFollow(float distance)
    {
        if (distance <= distanceDect)
        {
            Detect = true;
        }
        else
        {
            Detect = false;
            follow = false;
        }
        
    }

}
