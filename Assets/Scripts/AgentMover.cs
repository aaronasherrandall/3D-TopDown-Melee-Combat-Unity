using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMover : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _Agent;

    public event Action<float> OnSpeedChanged;

    public void SetDestination(Vector3 destination) {
      _Agent.destination = destination;
    }

    private void Update() {
      OnSpeedChanged?.Invoke(
        Mathf.Clamp01(_Agent.velocity.magnitude * 100 / _Agent.speed)); // limit to 0 to 1

      if (_Agent.remainingDistance <= _Agent.stoppingDistance) {
          OnSpeedChanged?.Invoke(Mathf.Clamp01(_Agent.velocity.magnitude / _Agent.speed));
      }
    }

    // New method to move the agent based on direction
    public void MoveInDirection(Vector3 direction) {
        _Agent.velocity = direction.normalized * _Agent.speed;
    }

    public void InterruptPointAndClickMovement() {
    // Check if the agent is currently following a path
    if (_Agent.pathStatus != NavMeshPathStatus.PathInvalid)
    {
        // Reset the agent's path or destination
        _Agent.ResetPath();
    }
  }


}
