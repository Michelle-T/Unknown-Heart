using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySimplePatrol : MonoBehaviour
{
    //The agent will wait or not on each mode
    [SerializeField]
    bool _patrolWaiting;

    //Time we wait at wach node
    [SerializeField]
    float _totalWaitTime = 3f;

    //Probability of switching directions
    [SerializeField]
    float _switchProbability = 0.2f;

    //List of all patrol nodes to visit
    [SerializeField]
    List<Waypoint> _patrolPoints;

    //Private variables for base behavior
    NavMeshAgent _navMeshAgent;
    int _currentPatrolIndex;
    bool _travelling;
    bool _waiting;
    bool _patrolForward;
    float _waitTimer;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (_navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name); ;
        }

        else
        {
            if (_patrolPoints != null && _patrolPoints.Count >= 2)
            {
                _currentPatrolIndex = 0;
                SetDestination();
            }

            else
            {
                Debug.Log("Insufficient patrol points for basic patrolling behavior");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Check if we're close to the destination
        if (_travelling && _navMeshAgent.remainingDistance <= 1.0f)
        {
            _travelling = false;

            //If going to wait, then wait
            if (_patrolWaiting)
            {
                _waiting = true;
                _waitTimer = 0f;
            }

            else
            {
                ChangePatrolPoint();
                SetDestination();
            }
        }

        //Instead if we're waiting
        if (_waiting)
        {
            _waitTimer += Time.deltaTime;
            if (_waitTimer >= _totalWaitTime)
            {
                _waiting = false;

                ChangePatrolPoint();
                SetDestination();
            }
        }
    }

    private void SetDestination()
    {
        if (_patrolPoints != null)
        {
            Vector3 targetVector = _patrolPoints[_currentPatrolIndex].transform.position;
            _navMeshAgent.SetDestination(targetVector);
            _travelling = true;
        }
    }

    //Selects new patrol point in available list but also with small change allowing us to move farward or backwards

    private void ChangePatrolPoint()
    {
        if (UnityEngine.Random.Range(0f, 1f) <= _switchProbability)
        {
            _patrolForward = !_patrolForward;
        }

        if (_patrolForward)
        {
            /*
            _currentPatrolIndex++;
            if(current{atrolIndex >= _patrolPoints.Count)
            {
                _currentPatrolIndex = 0;
            }
            */
            _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Count;
        }

        else
        {
            /*
            _currentPatrolIndex--;

            if(_currentPatrolIndex < 0)
            {
                _currentPatrolIndex = _patrolPoints.Count - 1;
            }
            */
            if (--_currentPatrolIndex < 0)
            {
                _currentPatrolIndex = _patrolPoints.Count - 1;
            }
        }
    }
}
