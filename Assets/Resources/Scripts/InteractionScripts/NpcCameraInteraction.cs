using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCameraInteraction : MonoBehaviour
{
	private Transform player;
	public Transform NPC;
    private Log logger;
    private NpcLookInteractions npcLookAtPlayer;
    private Menu menu;
    private DialogManager dialogManager;
    Animator animator;
    public GameObject focus;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        dialogManager = FindObjectOfType<DialogManager>();
        logger = GameObject.FindObjectOfType<Log>();
        menu = FindObjectOfType<Menu>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {

        npcLookAtPlayer = menu.GetNpcLookInteractions();
        bool dmPlaying = dialogManager.GetPlaying();
        GameObject dmCurrentNpc = dialogManager.GetCurrentNpc();
        if ((dmPlaying && dmCurrentNpc != null))
        {
            bool checkToTalk = (this.name == dmCurrentNpc.name) && dmPlaying;
            if (checkToTalk)
            {
                animator.SetBool("talking", true);
            }
            else
            {
                animator.SetBool("talking", false);
            }
        } else
        {
            animator.SetBool("talking", false);
        }
    }

    public void startAnimation(){
    	animator.SetBool("looked", true);
        logger.logStartWatch(GetComponent<Transform>());
    }

    public void endAnimation(){
    	animator.SetBool("looked", false);
        logger.logEndWatch(GetComponent<Transform>());
    }

    private void OnAnimatorIK()
    {
        animator.SetLookAtWeight(1);
        animator.SetLookAtPosition(focus.GetComponent<Transform>().position);


        switch (npcLookAtPlayer)
        {
            case NpcLookInteractions.WhenLooked:
                {
                    if (animator.GetBool("looked")){
                        
                        focus.GetComponent<focusScript>().MoveTo(player);
                    } else {
                        focus.GetComponent<focusScript>().MoveTo(NPC);
                    }
                    break;
                }
            case NpcLookInteractions.WhenNotLooked:
                {
                    if (animator.GetBool("looked")) {
                        focus.GetComponent<focusScript>().MoveTo(NPC);
                    } else {
                        focus.GetComponent<focusScript>().MoveTo(player);
                    }
                    break;
                }
            case NpcLookInteractions.Never:
                {
                    focus.GetComponent<focusScript>().MoveTo(NPC);
                    break;
                }
            case NpcLookInteractions.Always:
                {
                    focus.GetComponent<focusScript>().MoveTo(player);
                    break;
                }
        }
       
    }
}
