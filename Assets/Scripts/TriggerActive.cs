using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerActive : MonoBehaviour
{
    public UnityEvent onTrigger;
    [SerializeField] private string tag;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag== tag)
        {
            onTrigger.Invoke();
        }
    }
}
