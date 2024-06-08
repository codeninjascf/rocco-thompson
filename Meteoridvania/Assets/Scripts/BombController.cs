using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{

    public float timetoExplode = .5f;
    public GameObject explosion;

    public float blastRange;
    public LayerMask whatIsDestructible;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timetoExplode -= Time.deltaTime;
        if(timetoExplode <= 0)
        {
            if(explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            
        }
        Destroy(gameObject);

        Collider2D[] objectToRemove = Physics2D.OverlapCircleAll(transform.position, blastRange, whatIsDestructible);

        if(objectToRemove.Length < 0)
        {
            foreach(Collider2D col in objectToRemove)
            {
                Destroy(col.gameObject);
            }
        }
    }
}
