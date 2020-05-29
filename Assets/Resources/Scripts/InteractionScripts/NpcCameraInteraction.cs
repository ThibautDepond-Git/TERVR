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

    float smoother = 3f;
    float lookWeight = 0f;

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
        animator.SetLookAtWeight(lookWeight);

        switch (npcLookAtPlayer)
        {
            case NpcLookInteractions.WhenLooked:
                {
                    if (animator.GetBool("looked")){
                        animator.SetLookAtPosition(player.position);
                        lookWeight = Mathf.Lerp(lookWeight, 1f, Time.deltaTime * smoother);
                    } else {
                        lookWeight = Mathf.Lerp(lookWeight, 0.2f, Time.deltaTime * smoother);
                        animator.SetLookAtPosition(NPC.position);
                        lookWeight = Mathf.Lerp(lookWeight, 1f, Time.deltaTime * smoother);
                    }
                    break;
                }
            case NpcLookInteractions.WhenNotLooked:
                {
                    if (animator.GetBool("looked")) {
                        animator.SetLookAtPosition(NPC.position);
                        lookWeight = Mathf.Lerp(lookWeight, 1f, Time.deltaTime * smoother);
                    } else {
                        lookWeight = Mathf.Lerp(lookWeight, 0.2f, Time.deltaTime * smoother);
                        animator.SetLookAtPosition(player.position);
                        lookWeight = Mathf.Lerp(lookWeight, 1f, Time.deltaTime * smoother);
                    }
                    break;
                }
            case NpcLookInteractions.Never:
                {
                    animator.SetLookAtPosition(NPC.position);
                    break;
                }
            case NpcLookInteractions.Always:
                {
                    animator.SetLookAtPosition(player.position);
                    break;
                }
        }
       
    }
}
