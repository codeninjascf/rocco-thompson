using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameManager gameManager;
    public Transform target;
    public float smoothingTime = .2f;
    public Vector3 cameraOffset;
    private Vector3 _velocity;

    public float deathHeight = -2;

    private bool _following;
    private float _cameraHeight;
    void Update()
    {
        _following = target.position.y > deathHeight;

        if(target.gameObject.activeSelf && target.position.y <=
            deathHeight - _cameraHeight)
        {
            gameManager.KillPlayer();
        }
        Vector3 targetPos = new Vector3(target.position.x, target.position.y,
            transform.position.z) + cameraOffset;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos,
          ref _velocity, smoothingTime);
    }

    void Start()
    {
        _following = true;
        _cameraHeight = transform.position.y -
            Camera.main.ViewportToWorldPoint(Vector3.zero).y;

        ResetView();
    }

    private void FixedUpdate()
    {
        if (!_following) return;
    }

    public void ResetView()
    {
        transform.position = new Vector3(target.position.x,
            target.position.y, transform.position.z) + cameraOffset;
        _velocity = Vector3.zero;

    }

}
