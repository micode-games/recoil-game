using UnityEngine;

[RequireComponent(typeof(Camera))]
public class LetterBox : MonoBehaviour
{

    [Header("Target Resolution")]
    public int targetWidth = 1920;
    public int targetHeight = 1080;

    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        cam.orthographic = true;
        ApplyLetterbox();
    }

    void ApplyLetterbox()
    {
        float targetAspect = (float)targetWidth / targetHeight;
        float windowAspect = (float)Screen.width / Screen.height;

        float scaleHeight = windowAspect / targetAspect;
        Rect rect = cam.rect;

        if (scaleHeight < 1f)
        {
            // Letterbox (black bars top/bottom)
            rect.width = 1f;
            rect.height = scaleHeight;
            rect.x = 0f;
            rect.y = (1f - scaleHeight) / 2f;
        }
        else
        {
            // Pillarbox (black bars left/right)
            float scaleWidth = 1f / scaleHeight;
            rect.width = scaleWidth;
            rect.height = 1f;
            rect.x = (1f - scaleWidth) / 2f;
            rect.y = 0f;
        }

        cam.rect = rect;
    }

    void OnValidate()
    {
        if (Application.isPlaying)
            ApplyLetterbox();
    }
}
