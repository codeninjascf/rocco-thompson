using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaneraController : MonoBehaviour
{
    public GameObject player;
    public BoxCollider2D boundsBox;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(
                Mathf.Clamp(player.transform.position.x, boundsBox.bounds.min.x, boundsBox.bounds.max.x),
                Mathf.Clamp(player.transform.position.y, boundsBox.bounds.min.y, boundsBox.bounds.max.y),
                transform.position.z);

        }
    }
}   
