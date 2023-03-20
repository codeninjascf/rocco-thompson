using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float jumpForce = 7f;

    private Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
    }
}
