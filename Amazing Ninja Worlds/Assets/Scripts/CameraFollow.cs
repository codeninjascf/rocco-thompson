using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameManager gameManager;

    public Transform target;
    public Vector3 cameraOffset;
    
    public float smoothingTime = .2f;
    public bool heightLimitActive;
    public float deathHeight = -2;
    public float heightLimit = 16;


    private bool _following;
    private float _cameraHeight;

    private Vector3 _velocity;

    void Start()
    {
        _following = true;
        _cameraHeight = transform.position.y - Camera.main.ViewportToWorldPoint(Vector3.zero).y;
        
        ResetView();
    }

    void Update()
    {
        _following = target.position.y > deathHeight &&
            (!heightLimitActive || target.position.y < heightLimit);
        
        if (target.gameObject.activeSelf && target.position.y <= deathHeight - _cameraHeight)
        {
            gameManager.KillPlayer();
        }
    }
    
    void FixedUpdate()
    {
        if (!_following) return;
        if(target.gameObject.activeSelf && target.position.y >=
            heightLimit + _cameraHeight && heightLimitActive)
        {
            gameManager.KillPlayer();
        }
        
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z) + cameraOffset;
        
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, smoothingTime);
    }

    public void ResetView()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z) + cameraOffset;
        _velocity = Vector3.zero;
    }
}
