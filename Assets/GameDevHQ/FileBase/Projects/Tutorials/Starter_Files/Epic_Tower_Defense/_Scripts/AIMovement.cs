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
    [SerializeField]
    private GameObject[] _enemyPrefab;


    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = _agentSpeed;
        _target = SpawnManager.Instance.endPoint; // HELP!
        _agent.SetDestination(_target.transform.position);
    }

    void Update()
    {
        CheckDestinationReached();
    }

    void CheckDestinationReached()
    {
        float distanceToTarget = Vector3.Distance(transform.position, _target.transform.position);
        if (distanceToTarget < 1f)
        {
            this.gameObject.SetActive(false);
        }
    }
}
