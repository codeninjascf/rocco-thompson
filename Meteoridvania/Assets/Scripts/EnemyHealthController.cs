using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int totalHealth = 3;
    public GameObject deathEffect;
    public int damageAmount = 1;

    // This method is called when another object collides with this one
    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthController>().DamageEnemy(damageAmount);
        }
    }

    // This method handles the enemy taking damage
    public void DamageEnemy(int damageAmount)
    {
        totalHealth -= damageAmount;

        if (totalHealth <= 0)
        {
            HandleDeath();
        }
    }

    // This method handles the enemy's death effects and destruction
    private void HandleDeath()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
