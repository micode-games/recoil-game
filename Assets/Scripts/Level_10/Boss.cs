using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        MoveWall();
    }

    private void MoveWall()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
