using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCamera : MonoBehaviour
{
		public Transform player;
		public Transform NPC;
        public Log logger;
        Animator animator;


    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void startAnimation(){
    	animator.SetBool("talking", true);
        FindObjectOfType<AudioManager>().Play("Hello");

        logger.logStartWatch(NPC);
    }

    public void endAnimation(){
    	animator.SetBool("talking", false);

        logger.logEndWatch(NPC);
    }

    private void OnAnimatorIK()
    {
        if (animator.GetBool("talking"))
        {
            animator.SetLookAtWeight(1);
            animator.SetLookAtPosition(player.position);
        } else
        {
            animator.SetLookAtWeight(1);
            animator.SetLookAtPosition(NPC.position);
        }
        
    }
}
