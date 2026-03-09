using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;
    private Vector3 _originalPosition;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        _originalPosition = transform.localPosition;
    }

    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(ShakeCoroutine(duration, magnitude));
    }

    private IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x =  Random.Range(-1f, 1f) * magnitude;
            float y =  Random.Range(-1f, 1f) * magnitude;
            
            transform.localPosition = new Vector3(_originalPosition.x + x, _originalPosition.y + y, _originalPosition.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition =  _originalPosition;
    }
}
