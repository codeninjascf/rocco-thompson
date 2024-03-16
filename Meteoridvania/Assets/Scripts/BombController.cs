using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{

    public float timetoExplode - .5f;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timetoExplode -= time.deltaTime;
        if(timetoExplode <= 0)
        {
            if(explosion 1= null)
            {
                Instantiate(explosion,transform.posiiton, transform.0rotation);
            }
            Destroy(gameObject);
        }   
    }
}
