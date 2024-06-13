using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OfficeWorkerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public float range;

    public bool isHit;

    public Transform centerPoint;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        isHit = false;
    }

    void Update()
    {
        if(agent.remainingDistance <= agent.stoppingDistance && isHit == false) //done with path
        {
            Vector3 point;
            if (RandomPoint(centerPoint.position, range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                agent.SetDestination(point);
            }
            Debug.Log("ExitUpdate");
        }
        else if(isHit)
        { 
            Debug.Log("HitUpdate");
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "Object")
        {
            Debug.Log("Hit");
            isHit = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player" || other.tag == "Object")
        {
            Debug.Log("Exit");
            isHit = false;
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

     bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        { 
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
