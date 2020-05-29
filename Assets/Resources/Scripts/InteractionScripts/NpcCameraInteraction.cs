using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCameraInteraction : MonoBehaviour
{
	public Transform player;
	public Transform NPC;
    public Log logger;
    private NpcLookInteractions npcLookAtPlayer;
    public StartScenario menu;
    Animator animator;
    public GameObject focus;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        npcLookAtPlayer = menu.GetNpcLookInteractions();
    }

    public void startAnimation(){
    	animator.SetBool("looked", true);
        logger.logStartWatch(NPC);
    }

    public void endAnimation(){
    	animator.SetBool("looked", false);
        logger.logEndWatch(NPC);
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
