using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    
    public static RespawnController respawnController;

    public int totalHealth = 3;
    public GameObject deathEffect;
    public void FillHealth()
    {
        print("yes");
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator wait()
    {
       yield return new WaitForSeconds(0.5f);
        gameObject.transform.localScale = new Vector3(2,2,2);

    }




    [HideInInspector]
        public int currentHealth;
    public int maxHealth;

    public float invincLength, flashLength;
    private float invicCounter, flashCounter;
    public SpriteRenderer[] playerSprites;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (invicCounter > 0)
        {
            invicCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                foreach (SpriteRenderer sr in playerSprites)
                {
                    sr.enabled = !sr.enabled;
                }
                flashCounter = flashLength;
            }

            if (invicCounter <= 0)
            {
                foreach (SpriteRenderer SR in playerSprites)
                {
                    SR.enabled = true;
                }
                flashCounter = 0f;
            }


        }
        // Your update logic here (if needed)
    }

    public void DamagePlayer(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            currentHealth = 0; // resets to 0 if goes into minus (for UI reasons
            RespawnController.instance.Respawn(); // calls the Respawn Function
        }
    }

}
