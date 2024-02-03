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

    // public void Attack() {
    //   _animator.SetBool("Attack", true);
    //   Debug.Log("Is Attacking");
    // }

    public void EndAttack() {
      _animator.SetBool("Attack", false);
       Debug.Log("Attack Finished");
    }

    // public void StepEvent() {
    //   OnStep.Invoke();
    // }
}
