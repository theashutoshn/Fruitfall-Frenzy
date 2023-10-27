using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform _cameraTransform;

    private float _shakeDuration = 2f;
    private float _shakeAmount = 0.7f;
    private float _decreaseFactor = 1f;

    Vector3 originalPos;

    void Awake()
    {
        if (_cameraTransform == null)
        {
            _cameraTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    private void OnEnable()
    {
        originalPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShakeCamera()
    {
        if (_shakeDuration > 0)
        {
            _cameraTransform.localPosition = originalPos + Random.insideUnitSphere * _shakeAmount;

            _shakeDuration -= Time.deltaTime * _decreaseFactor;
        }
        else
        {
            _shakeDuration = 0f;
            _cameraTransform.localPosition = originalPos;
        }
    }
}
