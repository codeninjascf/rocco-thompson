using JetBrains.Annotations;
using UnityEngine;

public class PlayerAbilityTracker : MonoBehaviour
{

    public bool canDoubleJump, canDash, canBecomeBall, canDropBomb;
    public bool unlockDoubleJump, unlockDash, unlockBecomeBall, unlockDropBomb;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerAbilityTracker player = other.GetComponentInParent<PlayerAbilityTracker>();
            if(unlockDoubleJump)
            {
                player.canDoubleJump = true;
            }
            if (unlockDash)
            {
                player.canDash = true;
            }

            if (unlockBecomeBall)
            {
                player.canBecomeBall = true;
            }

            if (unlockDropBomb)
            {
                player.canDropBomb = true;
            }

            Destroy(gameObject);
        }
        
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
