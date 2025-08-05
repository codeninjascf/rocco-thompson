using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class RespawnController : MonoBehaviour
{
    public static RespawnController instance;

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

    public Vector3 respawnPoint;
    public float waitToRespawn;
    public GameObject thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = PlayerHealthController.instance.gameObject;
        respawnPoint = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSpawn(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCo());
    }

    IEnumerator RespawnCo()
    {
        thePlayer.SetActive(false);
        yield return new WaitForSeconds(waitToRespawn);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        thePlayer.transform.position = respawnPoint;
        thePlayer.SetActive(true);
        PlayerHealthController.instance.FillHealth();


        yield return new WaitForSeconds(waitToRespawn);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        thePlayer.transform.position = respawnPoint;
        thePlayer.SetActive(true);

        PlayerHealthController.instance.FillHealth();
    }
}



