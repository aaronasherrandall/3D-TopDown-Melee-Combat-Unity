using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 3;

    public ParticleSystem hitEffect;
    public GameObject hitEffectSpawnPoint;


    private void OnTriggerEnter(Collider collider) {
      if(collider.GetComponent<Health>() != null) {
        Health health = collider.GetComponent<Health>();
        health.TakeDamage(damage);
        StartCoroutine(PlayHitEffect());
      }
    }

    IEnumerator PlayHitEffect() {
      // Instantiate hitEffect
      ParticleSystem effect = Instantiate(hitEffect, hitEffectSpawnPoint.transform.position, Quaternion.identity);
      effect.transform.parent = hitEffectSpawnPoint.transform;
      //yield return new WaitForSeconds(hitEffect.main.duration);

      // Get the ParticleSystem component
      ParticleSystem ps = effect.GetComponent<ParticleSystem>();

      // Wait for the particle system to finish playing, then destroy the GameObject
      Destroy(effect, ps.main.duration);

      yield return null; // Add this line to ensure all code paths return a value
    }
}
