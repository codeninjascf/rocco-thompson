using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("Boss Movement")]
    public float width;
    public float height;
    public float speed;
    public float waitTime;

    [Header("Firball")]
    public GameObject fireball;
    public float fireballSpeed;

    private float currentWaitTime;
    private Vector2 startPos;
    private Vector2 movePos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        currentWaitTime = waitTime;
        SetRandomPosition();
    }

    void shotFireball()
    {
        Vector2 playerPos = PlayerHealthController.instance.gameObject.transform.position;
        Vector2 direction = (playerPos - transform.position.ConvertTo<Vector2>()).normalized;
        GameObject newFireball = Instantiate(fireball, transform.position, Quaternion.identity);
        newFireball.GetComponent<Rigidbody2D>().velocity = direction * fireballSpeed;
        Destroy(newFireball, 10f);
    }

    void SetRandomPosition()
    {
        movePos = startPos + Vector2.right * Random.Range(-width, width) + Vector2.up * Random.Range(-height, height);
    }



    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePos, speed * Time.deltaTime);
        if (Vector2.Distance(movePos, transform.position) <= 1f)
        {
            currentWaitTime -= Time.deltaTime;
            if (currentWaitTime <= 0)
            {
                SetRandomPosition();
                shotFireball();
                currentWaitTime = waitTime;
            }
        }
    }
}
