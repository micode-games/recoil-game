using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapFinish : MonoBehaviour
{
    private int _hits;
    
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _hits++;

            if (_hits < 3)
            {
                transform.position = new Vector2(Random.Range(-9f, 9f), Random.Range(-4f, 4f));
            }
            else
            {
                Destroy(other.gameObject);
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
        }
    }
}
