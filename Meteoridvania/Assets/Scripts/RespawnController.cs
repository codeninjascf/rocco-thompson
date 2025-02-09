using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnController : MonoBehaviour
{


    private GameObject thePlayer;
    public float waitToRespawn;
    public static RespawnController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance=this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame Update
    public Vector3 respawnPoint;

    public void Respawn()
    {
        StartCoroutine(RespawnCo());
    }
    void Start()
    {
        thePlayer = PlayerHealthController.instance.gameObject;
        respawnPoint = thePlayer.transform.position;
    }

    IEnumerator RespawnCo()
    {
        thePlayer.SetActive(false);
        yield return new WaitForSeconds(waitToRespawn);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        thePlayer.SetActive(true);
        PlayerHealthController.instance.FillHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
