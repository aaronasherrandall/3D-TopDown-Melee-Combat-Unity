using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private AgentMover _movement;
    [SerializeField] private AgentAnimations _AgentAnimation;

    private void Start() {
      _input.OnMouseClick += _movement.SetDestination;
      _input.OnDirectionInput += _movement.MoveInDirection; // Subscribe to the new event
      _movement.OnSpeedChanged += _AgentAnimation.SetSpeed;
      _AgentAnimation.SetSpeed(0);
    }
}
