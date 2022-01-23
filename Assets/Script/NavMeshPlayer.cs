using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPlayer : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;


    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       navMeshAgent.destination = movePositionTransform.position;   
       

   
    }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();   
    }
}
