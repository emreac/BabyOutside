using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs_Z_LtoR : MonoBehaviour
{
    private Vector3 positionDisplacement;
    private Vector3 positionOrigin;
    private float _timePassed;
    private void Start()
    {
        float randomDistance = 2f;
        positionDisplacement = new Vector3(0F, 0f, randomDistance);
        positionOrigin = transform.position;
    }

    private void Update()
    {
        _timePassed += Time.deltaTime;
        transform.position = Vector3.Lerp(positionOrigin, positionOrigin + positionDisplacement,
           Mathf.PingPong(_timePassed, 1));
    }
}
