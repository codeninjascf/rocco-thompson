using UnityEngine;

public class EnemyPatrollers : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int currentPoint;
    public float moveSpeed, waitAtPoints, jumpForce;
    private float waitCounter;
    public Rigidbody2D theRB;
    // Start is called before the first frame update
    void Start()
    {
        waitCounter = waitAtPoints;

        foreach (Transform pPoint in patrolPoints)
        {
            pPoint.SetParent(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(transform.position.x = patrolPoints[currentPoint].position.x) < .2f)
        {
            
    }
}
