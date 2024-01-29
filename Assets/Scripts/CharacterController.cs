using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    private const string speedAnimatorParamater = "Speed";
    private const int mudAreaID = 3;
    private bool hasSpecialTevaNaot = true;

    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform[] pathWaypoints;
    private int currentWaypointIndex;
    private void Start()
    {
        Debug.Log("Start route");
        if (hasSpecialTevaNaot)
            navMeshAgent.SetAreaCost(areaIndex: mudAreaID, areaCost: 0.2f);
        navMeshAgent.SetDestination(pathWaypoints[0].position);
    }
    private void Update()
    {
        if (!navMeshAgent.isStopped && navMeshAgent.remainingDistance <= 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= pathWaypoints.Length)
            {
                Debug.Log("Return route");
                currentWaypointIndex = 0;
            }
            navMeshAgent.SetDestination(pathWaypoints[currentWaypointIndex].position);
        }
    }
}