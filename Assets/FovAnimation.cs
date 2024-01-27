using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class FovAnimation : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        virtualCamera.m_Lens.FieldOfView = 50f;
    }
    void Update()
    {
        // Example: Change FOV from 50 to 60 over a duration of 3 seconds
        ChangeFOV(50f, 60f, 3f);
    }

    void ChangeFOV(float startFOV, float endFOV, float duration)
    {
        // Use DOTween to tween the field of view
        DOTween.To(() => virtualCamera.m_Lens.FieldOfView, x => virtualCamera.m_Lens.FieldOfView = x, endFOV, duration)
            ;
    }
}
