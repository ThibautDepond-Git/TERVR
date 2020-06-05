using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class focusScript : MonoBehaviour
{
    [Range(0f, 10f)]
    public float speed;
    private Transform target;

    void Start()
    {
        target = transform;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            transform.SetPositionAndRotation(target.position, transform.rotation);
        }
    }

    public void MoveTo(Transform newTarget)
    {
        target = newTarget;
    }
}
