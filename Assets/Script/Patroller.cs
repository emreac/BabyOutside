using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{

    public Transform[] targets;
    public int speed;
    private int targetIndex;
    private float dist;

    // Start is called before the first frame update
    void Start()
    {
        targetIndex = 0;
        transform.LookAt(targets[targetIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, targets[targetIndex].position);
        if(dist < 1f)
        {
            IncreaseIndex();

        }
        Patrol();
    }

    void Patrol()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        targetIndex++;
        if (targetIndex >= targets.Length)
        {
            targetIndex = 0;

        }

        transform.LookAt(targets[targetIndex].position);



    }
}
