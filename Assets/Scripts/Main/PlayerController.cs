using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float shotForce = 10f;
    
    Rigidbody2D _rb;
    private PlayerInput _input;
    private WeaponController _weapon;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();
        _weapon = GetComponentInChildren<WeaponController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.IsShotPressed())
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - (Vector2)transform.position).normalized;
            if (_weapon.Shoot(direction))
            {
                _rb.AddForce(-direction * shotForce, ForceMode2D.Impulse);
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && other.relativeVelocity.magnitude > 1f)
        {
            CameraShake.Instance.Shake(0.02f, 0.2f);
        }
    }
}
