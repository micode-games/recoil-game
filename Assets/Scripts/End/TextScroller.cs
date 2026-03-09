using UnityEngine;

public class TextScroller : MonoBehaviour
{
    [SerializeField] private float speed = 100f;

    private RectTransform rect;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        rect.anchoredPosition += Vector2.down * speed * Time.deltaTime;

        if (rect.anchoredPosition.y < -275f)
        {
            rect.anchoredPosition = new Vector2(
                rect.anchoredPosition.x,
                347f
            );
        }
    }
}