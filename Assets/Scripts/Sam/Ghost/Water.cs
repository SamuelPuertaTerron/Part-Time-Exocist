using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartTimeExocist
{
    public class Water : GhostAIBase
    {
        protected override string GetEnemyName() {
            return "Mr Frozen";
        }
        protected override void OnTakeDamage()
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.0f);

            transform.position = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0.0f);
        }

        protected override void OnDeath()
        {
            transform.localScale = Vector3.one;
            Destroy(gameObject, 1.2f);
        }
    }
}


