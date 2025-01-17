using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    public int totalHealth = 3;
    public GameObject deathEffect;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [HideInInspector]
    public int currentHealth;
    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Your update logic here (if needed)
    }

    public void DamagePlayer(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            currentHealth = 0; // resets to 0 if goes into minus (for UI reasons)
            Instantiate(deathEffect, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}
