using System.Collections;
using System.Collections.Generic;
using System.Media;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    float _triggerTime;
    float _explodeTime;
    bool _isActive;
    SoundPlayer _sound;
    
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
            _triggerTime += 1 * Time.deltaTime;

            yield return null;
            if (_triggerTime >=_explodeTime)
            {

            }
        }
        yield return null;
    }
    public void ActiveBomb(float time)
    {
        _triggerTime = time;
        _isActive = true;
        _sound.Play();
    }
}
