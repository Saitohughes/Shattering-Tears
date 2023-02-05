using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotation : MonoBehaviour
{
    [SerializeField] float speed;
    private Vector3 direction;
    [SerializeField] Transform target;


    // Update is called once per frame
    void Update()
    {
        direction = target.transform.position - transform.position;

        float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        Vector3 dir = new Vector3(90f, 0f, angle);
        Quaternion rotation = Quaternion.Euler(dir);

        //Quaternion newdir = new Quaternion(90f, 0, angle,1);
        //Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
