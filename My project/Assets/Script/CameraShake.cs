using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;

    public float shakeAmount = 0.15f;
    public float shakeTime = 0.15f;

    private Vector3 originalPos;

    void Awake()
    {
        Instance = this;
        originalPos = transform.localPosition;
    }

    public void Shake()
    {
        StopAllCoroutines();
        StartCoroutine(ShakeRoutine());
    }

    IEnumerator ShakeRoutine()
    {
        float timer = 0f;

        while (timer < shakeTime)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            timer += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
