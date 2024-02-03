using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    private AgentAnimations _agentAnimation;

    public Transform attackTransform;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int playerDamage;

    private void Awake() {
      _agentAnimation = GetComponent<AgentAnimations>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
      if(timeBetweenAttack <= 0) {
        if(Input.GetKey(KeyCode.Space)) {
          // attack
          _agentAnimation.Attack();
          // all enemies inside a certain radius
          // deal damage
          // only focus on colliders inside LayerMask
          // 2D -> Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackTransform.position, attackRange, whatIsEnemy);
          // 3D Implimentation
          Collider[] enemiesToDamage = Physics.OverlapSphere(attackTransform.position, attackRange, whatIsEnemy);
          for (int i = 0; i < enemiesToDamage.Length; i++) {
            enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(playerDamage);

          }
        }
        // then we can attack
        timeBetweenAttack = startTimeBetweenAttack;
      } else {
        // gradually decrease value until it equals or is less than 0 at rate of Time.deltaTime
        timeBetweenAttack -= Time.deltaTime;

      }
    }

    private void OnDrawGizmosSelected() {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }

    // In many games, it's desirable for certain mechanics to be frame rate dependent to ensure consistent behavior across different systems with varying performance levels.
    // In your code, timeBetweenAttack is decreased by Time.deltaTime each frame. Time.deltaTime gives the time in seconds since the last frame,
    // so it's a smaller number for higher frame rates and a larger number for lower frame rates.
    // This means that timeBetweenAttack will decrease faster on a system with a lower frame rate and slower on a system with a higher frame rate.
    // However, because Time.deltaTime is based on real time, not frames, the actual "game time" it takes for timeBetweenAttack to reach 0 will be roughly the same
    // regardless of frame rate. This is important because it means your attack mechanic will behave consistently no matter the performance of the system running the game.
    // For example, if timeBetweenAttack is initially set to 2 seconds, it will take approximately 2 seconds of real time for it to reach 0,
    // whether the game is running at 30 frames per second or 60 frames per second.
}
