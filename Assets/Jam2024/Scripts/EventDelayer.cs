using Febucci.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDelayer : MonoBehaviour
{
    [SerializeField] TypewriterByCharacter[] typeW;

    public void StartDissappearingCouroutine()
    {
        StartCoroutine(TypeWriter());
    }

    public IEnumerator TypeWriter()
    {
        yield return new WaitForSeconds(2.5f);

        foreach (var type in typeW)
        {
            if (type != null && type.gameObject.activeSelf)
            {
                type.StartDisappearingText();
            }
        }
    }
}
