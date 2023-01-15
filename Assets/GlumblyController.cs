using UnityEngine;
using UnityEngine.AI;

// using UnityEngine.Random
public class GlumblyController : MonoBehaviour {
    public  GameObject   target;
    public  float        minimumDistanceToTarget        = 8.0f;
    public  float        distanceToTargetDecreasePerSec = 0.05f;
    private NavMeshAgent agent;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        var positionDifference = target.transform.position - agent.transform.position;

        if (positionDifference.magnitude < minimumDistanceToTarget) {
            var normalizedDirection = (-positionDifference).normalized;

            agent.SetDestination(normalizedDirection * (minimumDistanceToTarget * 2.0f));
        } else {
            agent.SetDestination(target.transform.position);
        }
    }

    private void FixedUpdate() {
        minimumDistanceToTarget -= Time.deltaTime          * distanceToTargetDecreasePerSec;
        agent.stoppingDistance  =  minimumDistanceToTarget * 1.25f;
    }
}
