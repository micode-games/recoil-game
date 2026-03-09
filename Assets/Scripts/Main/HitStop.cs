using System;
using UnityEngine;
using System.Collections;

public class HitStop : MonoBehaviour
{
    public static HitStop Instance;
    bool isWaiting = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Stop(float duration)
    {
        if(isWaiting) return;
        Time.timeScale = 0.0f;
        StartCoroutine(Wait(duration));
    }

    IEnumerator Wait(float duration)
    {
        isWaiting = true;
        yield return new WaitForSecondsRealtime(duration);
        
        Time.timeScale = 1.0f;
        isWaiting = false;
    }
}
