using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float groundDistanceThreshold = 0.55f;
    public float spriteHeight = 1.78f;
    public LayerMask whatIsGround;
    public Transform throwPosition;
    public GameObject shuriken;
    private bool _gravityFlipped;
    private bool _isGrounded;
    private bool _enabled;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private AudioManager _audioManager;
    private AudioManager audioManager;
    public bool GravityFlipped
    {
        get => _gravityFlipped;
        set
        {
            _gravityFlipped = value;

            int multiplier = value ? -1 : 1;
            _rigidbody.gravityScale = multiplier * Mathf.Abs(_rigidbody.gravityScale);
            jumpForce = multiplier * Mathf.Abs(jumpForce);

            Transform body = transform.GetChild(0);
            body.localScale = new Vector3(1, multiplier, 1);
        }
    }
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioManager = FindObjectOfType<AudioManager>();

        _enabled = true;
        GravityFlipped = false;
        _enabled = true;    
    }



    void Update()
    {
        if (!_enabled) return;

        bool previouslyGrounded = _isGrounded;

        if(!previouslyGrounded && _isGrounded)
        {
            audioManager.PlayAudio("PlayerLand");
        }

        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistanceThreshold, whatIsGround);
        _isGrounded = !GravityFlipped ?
            Physics2D.Raycast(transform.position, Vector2.down,
            groundDistanceThreshold, whatIsGround)
            : Physics2D.Raycast(transform.position, Vector2.up,
            groundDistanceThreshold + spriteHeight, whatIsGround);

        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _animator.SetBool("Jumping", true);
            _rigidbody.velocity = Vector2.up * jumpForce;
            _audioManager.PlayAudio("PlayerJump");
        }
        else
        {
            _animator.SetBool("Jumping", false);
        }

        _animator.SetBool("Falling", !_isGrounded);

        if (Input.GetButtonDown("Fire1") && gameManager.Shurikens > 0)
        {
            GameObject newShuriken = Instantiate(shuriken,
                throwPosition.position, Quaternion.identity);
            newShuriken.GetComponent<ShurikenController>().Initialise(
                (int)transform.localScale.x);
            gameManager.Shurikens--;
        }
    }

    void FixedUpdate()
    {
        if (!_enabled) return;

        float movement = moveSpeed * Input.GetAxisRaw("Horizontal");

        _animator.SetBool("Moving", movement != 0);

        if (movement > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (movement < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        _rigidbody.position += movement * Time.deltaTime * Vector2.right;
    }

    public void Enable()
    {
        _enabled = true;
    }

    public void Disable()
    {
        _enabled = false;

        _animator.SetBool("Moving", false);
        _animator.SetBool("Jumping", false);
        _animator.SetBool("Falling", false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            gameManager.KillPlayer();
        }
    }


}
