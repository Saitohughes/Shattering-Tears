using System.Collections;
using System.Collections.Generic;
using System.Media;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    float _triggerTime;
 
    bool _isActive;
    AudioSource _sound;

    public AudioSource Sound { get => _sound; set => _sound = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator TriggerBomb()
    {
        while (_isActive) 
        {
            _triggerTime -= 1 * Time.deltaTime;

            yield return null;
            if (_triggerTime <=0)
            {
                GetComponentInParent<UManPlayerController>().Dead();
            }
        }
        yield return null;
    }
    public void ActiveBomb(float time)
    {
        _triggerTime = time;
        _isActive = true;
        Sound.Play();
        StartCoroutine(TriggerBomb());  
    }
}
