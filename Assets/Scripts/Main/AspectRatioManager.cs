using UnityEngine;
using UnityEngine.SceneManagement;

public class AspectRatioManager : MonoBehaviour
{
    public static AspectRatioManager Instance;

    void Awake()
    {
        // Делаем синглтон и не уничтожаем при смене сцены
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        Apply();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Apply();
    }

    void Apply()
    {
        Camera cam = Camera.main;

        if (cam == null)
        {
            Debug.LogWarning("Camera.main не найдена");
            return;
        }

        float targetAspect = 1094f / 505f;
        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        Rect rect = cam.rect;

        if (scaleHeight < 1f)
        {
            rect.width = 1f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1f - scaleHeight) / 2f;
        }
        else
        {
            float scaleWidth = 1f / scaleHeight;
            rect.width = scaleWidth;
            rect.height = 1f;
            rect.x = (1f - scaleWidth) / 2f;
            rect.y = 0;
        }

        cam.rect = rect;
    }
}
