using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D theRB;
    public Vector2 Movedir;
    public GameObject shotToFire;
    public Transform shotPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = Movedir * bulletSpeed;

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(shotToFire, shotPoint.position, shotPoint.rotation);
        }
    }
}
