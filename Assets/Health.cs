using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int totalHealth = 9;

    public void TakeDamage(int damage) {
      totalHealth -= damage;
    }
}
