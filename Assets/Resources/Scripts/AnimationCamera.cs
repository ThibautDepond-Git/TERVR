using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCamera : MonoBehaviour
{
		public Transform player;
		public Transform NPC;


    public void startAnimation(){
    	GetComponent<Animator>().SetBool("boule", false);
        FindObjectOfType<AudioManager>().Play("Hello");
        transform.LookAt(player.transform.position);
        transform.SetPositionAndRotation(transform.position, new Quaternion(0, transform.rotation.y, 0, transform.rotation.w));
    }

    public void endAnimation(){
    	GetComponent<Animator>().SetBool("boule", true);
    	transform.LookAt(NPC.transform.position);
    }
}
