using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    public Log logger;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private Transform origin;

    // Start is called before the first frame update
    void Start()
    {
        origin = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        logger.logHeadMotion(GetComponent<Transform>());
    }
}
