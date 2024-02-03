using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
  private Animator animator;

  private void Awake() {
    animator = GetComponent<Animator>();
  }

  public void TakeDamageAnimation() {
    animator.SetBool("GettingHit", true);
  }

  public void IdleAnimation() {
    animator.SetBool("GettingHit", false);
  }

}
