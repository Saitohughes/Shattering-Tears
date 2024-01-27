using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Cinemachine;

public class CombinedAnimation : MonoBehaviour
{
    public TMP_Text countdownText;
    public CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        // Set the initial alpha of the countdown text to 0
        countdownText.color = new Color(countdownText.color.r, countdownText.color.g, countdownText.color.b, 0f);

        // Start the countdown and FOV animation
        StartCountdown();
    }

    void StartCountdown()
    {
        // Set the initial text
        countdownText.text = "3";

        // Set the initial rotation to hide the first number
        countdownText.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);

        // Use DOTween to animate the countdown
        DOTween.Sequence()
            .Join(countdownText.transform.DORotate(new Vector3(0, 0, 0), 0.5f)) // Set the correct initial rotation
            .AppendCallback(() => Countdown(3)) // Start the countdown from 3
            .Append(countdownText.DOFade(1f, 0.5f)); // Fade in the text
    }

    void Countdown(int seconds)
    {
        if (seconds > 0)
        {
            // Use DOTween to animate the countdown
            countdownText.text = seconds.ToString();

            // Rotation, scaling, and punch scale animations
            countdownText.transform.DORotate(new Vector3(0, 180, 360), 0.5f, RotateMode.FastBeyond360).SetEase(Ease.OutBack);
            countdownText.transform.DOScale(Vector3.one * 1.5f, 0.5f).SetEase(Ease.OutBack).OnComplete(() => ResetScale());
            countdownText.transform.DOPunchScale(Vector3.one * 0.2f, 0.5f); // Add a punch effect

            // Change FOV dynamically during the countdown
            float duration = seconds; // Use the countdown value as the duration
            ChangeFOV(50f, 60f, duration);

            // Wait for a second before decreasing the countdown
            DOVirtual.DelayedCall(1f, () => Countdown(seconds - 1));
        }
        else
        {
            // Countdown is complete
            countdownText.text = "Hot Potato!!!";

            // Scale up the text without rotation for the last count
            countdownText.transform.DOScale(Vector3.one * 1.2f, 0.5f).SetEase(Ease.OutQuint);
            countdownText.DOFade(0f, 0.5f) // Fade out the text
                .OnComplete(() => ResetScale());
        }
    }

    void ResetScale()
    {
        // Reset the scale after scaling animation
        countdownText.transform.DOScale(Vector3.one, 0.1f).SetEase(Ease.OutQuint);
    }

    void ChangeFOV(float startFOV, float endFOV, float duration)
    {
        // Use DOTween to tween the field of view
        DOTween.To(() => virtualCamera.m_Lens.FieldOfView, x => virtualCamera.m_Lens.FieldOfView = x, endFOV, duration)
            .SetEase(Ease.OutSine);
    }
}
