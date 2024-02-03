using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public GameObject weaponTrigger;


    public bool attacking = false;
    public float timeToAttack = 0.25f;
    public float timer = 0f;
    private void Awake() {
      animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
          Attack();
        }

        if(attacking) {
          timer += Time.deltaTime;

          if(timer >= timeToAttack) {
            timer = 0;
            attacking = false;
            weaponTrigger.SetActive(attacking);
          }
        }
    }

    private void Attack() {
      attacking = true;
      // play an animation
      animator.SetTrigger("Attack");
      weaponTrigger.SetActive(attacking);

    }
}
