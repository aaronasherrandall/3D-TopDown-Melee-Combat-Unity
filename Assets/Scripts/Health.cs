using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int totalHealth = 9;
    EnemyAnimations enemyAnimations;

    public bool gettingHit = false;

    public float enemyHitAnimationTime;

    public AnimationClip animationClip;

    private void Awake()
    {
      enemyAnimations = GetComponent<EnemyAnimations>();
      enemyHitAnimationTime = animationClip.length;
    }
    public float timer = 0f;

    private void Update() {
      if(gettingHit) {
          timer += Time.deltaTime;

          if(timer >= enemyHitAnimationTime) {
            timer = 0;
            gettingHit = false;
            enemyAnimations.IdleAnimation();
          }
        }
    }


    public void TakeDamage(int damage) {
      gettingHit = true;
      totalHealth -= damage;
      enemyAnimations.TakeDamageAnimation();
    }
}
