using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class AgentAnimations : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private string _movementSpeed = "MovementSpeed";

    //public UnityEvent OnStep;

    public void SetSpeed(float speed) {
      _animator.SetFloat(_movementSpeed, speed);
    }

    // public void StepEvent() {
    //   OnStep.Invoke();
    // }
}
