using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;
    public float jumpForce;
    public Transform groundPoint;
    private bool isOnGround;
    public LayerMask whatIsGround;

    public Animator anim;
    public BulletController shotToFire;
    public Transform shotPoint;

    private bool canDoubleJump;

    public float dashSpeed, dashTime;
    private float dashCounter;

    public SpriteRenderer theSR, afterImage;
    public float afterImageLifetime, timeBetweenAfterImages;
    private float afterImageCounter;
    public Color afterImageColor;

    public float waitAfterDashing;
    private float dashRechargeCounter;

    public gameObject standing, ball;
    public float waitToBall;
    private float ballCounter;
    public animator ballAnim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dashRechargeCounter > 0)
        {
          

        }
        //dashing
        if (Input.GetButtonDown("Fire2") && standing.activeSelf)
        {
            dashCounter = dashTime;

            ShowAfterImage();
        }

        if (dashCounter > 0)
        {
            dashCounter = dashCounter - Time.deltaTime;

            theRB.velocity = new Vector2(dashSpeed * transform.localScale.x, theRB.velocity.y);

            afterImageCounter -= Time.deltaTime;
            if(afterImageCounter <= 0)
            {
                ShowAfterImage();
            }
        }
        // move sideways
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);



        // hande direction change
        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (theRB.velocity.x > 0)
        {
            transform.localScale = Vector3.one;
        }

        // checking if on the ground
        isOnGround = Physics2D.OverlapCircle(groundPoint.position, .2f, whatIsGround);

        // jumping
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            if (isOnGround)
            {
                canDoubleJump = true;
            }
            else
            {
                canDoubleJump = false;
            }
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);


            anim.SetBool("isOnGround", isOnGround);
            anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(shotToFire, shotPoint.position, shotPoint.rotation);
        }

        private void ShowAfterImage()
        {
            SpriteRenderer image = Instantiate(afterImage, transform.position, transform.rotation);
            image.sprite = theSR.sprite;
            image.transform.localScale = transform.localScale;
            image.color = afterImage.color;

            Destroy(image.gameObject, afterImageLifetime);

            afterImageCounter = timeBetweenAfterImages;
        }

        if!(ball.activeSelf)
        {
            if (Input.GetAxisRaw("Vertical") < -.9f)
            {
                ballCounter -= Time.deltaTime;
                if (ballCounter <= 0)
                {
                    ball.SetActive(true);
                    standing.SetActive(false);
                }
            }
            else
            {
                ballCounter = waitToBall;
            }
        }
        // moving animations
        if (standing.activeSelf)
        {
            anim.SetBool("isOnGround, isOnGround)", isOnGround);
            anim.SetFloat("speed", Mathf.abs(theRB.velocity.x));
        }

        if(ball.activeSelf)
        {
            ballAnim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
        }
    }
}