using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueAnimator : MonoBehaviour
{
    public Animator startAnim;
    public DialogueManager dm;
    
    public Dialogue dialogue;
    
    private GameObject _player;

    private bool _inTrigger;
    private void Start()
    {
        _player = GameObject.Find("Player");
        _inTrigger = false;
    }

    private void Update()
    {
        if (_inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (dm.areStarted)
                dm.DisplayNextSentence();
            else
                dm.StartDialogue(dialogue);
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _inTrigger = true;
            startAnim.SetBool("startOpen", true);
        }
            
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _inTrigger = false;
            startAnim.SetBool("startOpen", false);
            dm.EndDialogue();
        }
        
    }

}
