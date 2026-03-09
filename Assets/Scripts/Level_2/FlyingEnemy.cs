using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField] private float flySpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * flySpeed * Time.deltaTime);
        
        if (transform.position.y >= 4)
        {
            var rotation = transform.rotation;
            rotation =  Quaternion.Euler(0f, 0f,180f);
            transform.rotation = rotation;
        }

        if (transform.position.y <= -4f)
        {
            var rotation = transform.rotation;
            rotation =  Quaternion.Euler(0f, 0f,0);
            transform.rotation = rotation;
        }
    }
}
