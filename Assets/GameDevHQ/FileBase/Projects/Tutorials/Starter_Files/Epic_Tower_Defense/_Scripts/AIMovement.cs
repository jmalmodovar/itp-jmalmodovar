using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;
    private NavMeshAgent _agent;
    [SerializeField]
    private float _agentSpeed = 1.5f, _agentHealth, agentWarFund;
    
    


    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (_agent != null)
        {
            _agent.speed = _agentSpeed;
            _target = SpawnManager.Instance.endPoint; // HELP!
            _agent.SetDestination(_target.transform.position);
        }
    }

    void Update()
    {
        //CheckDestinationReached();
    }

    // TODO: turn this into a trigger object.
    void CheckDestinationReached()
    {
        float distanceToTarget = Vector3.Distance(transform.position, _target.transform.position);
        if (distanceToTarget < 1f)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "endPoint")
        {
            this.gameObject.SetActive(false);
        }
    }

}
