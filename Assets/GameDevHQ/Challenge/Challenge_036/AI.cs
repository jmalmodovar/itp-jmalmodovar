using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class AI : MonoBehaviour
    {
        [SerializeField]
        private GameObject _target;
        private NavMeshAgent _agent;


        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.SetDestination(_target.transform.position);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}