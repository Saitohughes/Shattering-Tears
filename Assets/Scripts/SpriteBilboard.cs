using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBilboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation=Quaternion.Euler(30f, Camera.main.transform.rotation.eulerAngles.y, 0f);
    }
}
