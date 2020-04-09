using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicLookAt : MonoBehaviour
{
    public Transform looked;
    void Start()
    {
        transform.LookAt(looked.transform.position);
    }
}
