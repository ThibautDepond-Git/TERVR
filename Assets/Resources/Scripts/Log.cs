using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    public Transform player;
    public Transform NPC;

    public void MyPrint()
    {
        Debug.Log(player.transform.position);
        Debug.Log(NPC);
    }
}