using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public int interaction;

    private bool _activated;
    // Start is called before the first frame update
    void Start()
    {
        _activated = false; 
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (_activated || !other.CompareTag("Player")) return;

        _activated = true;
        dialogueManager.StartInteraction(interaction);
    }
}
