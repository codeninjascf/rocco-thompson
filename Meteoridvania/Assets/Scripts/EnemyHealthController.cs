using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int totalHealth = 3;

    public Vector2 moveDir;

    public GameObject impactEffect;

    public int damageAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthController>()

        }
    }
    public void DamageEnemy(int damageAmount)
    {
        totalHealth -= damageAmount;

        if(totalHealth <= 0 )
        {
            if(deathEffect != null)
            {
                Instantiate(deathEffect, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }    
    }


    // Start is called before the first frame update
    void Start()
    {
        bzj
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
