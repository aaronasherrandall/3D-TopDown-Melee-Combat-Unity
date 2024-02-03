using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;

    private Animator animator;

    private void Awake() {
      animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage) {
      health -= damage;
      Debug.Log("Damage Taked!");
    }
}
