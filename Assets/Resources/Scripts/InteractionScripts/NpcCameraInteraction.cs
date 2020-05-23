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

        switch (npcLookAtPlayer)
        {
            case NpcLookInteractions.WhenLooked:
                {
                    if (animator.GetBool("looked")){ 
                        animator.SetLookAtPosition(player.position);
                    } else {
                        animator.SetLookAtPosition(NPC.position);
                    }
                    break;
                }
            case NpcLookInteractions.WhenNotLooked:
                {
                    if (animator.GetBool("looked")) {
                        animator.SetLookAtPosition(NPC.position);
                    } else {
                        animator.SetLookAtPosition(player.position);
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
