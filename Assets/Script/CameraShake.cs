using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Transform cameraTrans;
    Vector3 initialPos;

    private void Start() {
        cameraTrans = Camera.main.transform;
    }
    private void Update() {
        initialPos = cameraTrans.position;
    }
    private void OnEnable() {
        QTE2Script.OnShake += CameraShakeFunc;
    }
    private void OnDisable() {
        QTE2Script.OnShake -= CameraShakeFunc;
    }

    public void CameraShakeFunc(){
        StartCoroutine(ShakeSequence());
    }
    private IEnumerator ShakeSequence()
    {
        float duration = 0.5f; // Duration of the shake sequence
        float magnitude = 0.2f; // Magnitude of the camera shake
        float elapsed = 0f;

        while (elapsed < duration)
        {
            // Calculate the random displacement for the camera within the given magnitude
            Vector3 shakeOffset = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f) * magnitude;

            // Move the camera to the new position
            cameraTrans.position = initialPos + shakeOffset;

            elapsed += Time.deltaTime;
            yield return null;
        }
        
        // Reset the camera position to the initial position after the shake sequence
        cameraTrans.position = initialPos;
    }
}
