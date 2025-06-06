using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D theRB;
    
    public Vector2 moveDir;

    public GameObject impactEffect;
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    private void OnBecameInsivible()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        theRB.velocity = moveDir * bulletSpeed;  
    }
}
