using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCamera : MonoBehaviour
{

    public void startAnimation(){
    	GetComponent<Animator>().SetBool("boule", true);
    }

    public void endAnimation(){
    	GetComponent<Animator>().SetBool("boule", false);
    }
}
