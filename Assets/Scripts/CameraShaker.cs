using DG.Tweening;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private float _shakeDuration;
    [SerializeField] private float _shakeStrength;
    [SerializeField] private int _shakeVibrations;

    public void Shake()
    {
        transform.DOShakePosition(_shakeDuration, _shakeStrength, _shakeVibrations);
    }
}