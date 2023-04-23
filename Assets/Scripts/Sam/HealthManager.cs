using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartTimeExocist
{
    public class HealthManager : MonoBehaviour
    {
        public delegate void Damage();
        public event Damage OnTakeDamage;

        public delegate void Death();
        public event Death OnDeath;

        public float CurrentHealth { get { return m_currentHealth; } }
        public float MaxHealth { get { return maxHealth; } }

        [SerializeField] private float maxHealth = 100.0f;
        [SerializeField] private DamageType damageType;


        private float m_currentHealth;

        private enum DamageType
        {
            Health,
            Scale,
        }

        private void Start()
        {
            m_currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            switch(damageType)
            {
                case DamageType.Health:
                    HealthDamage(damage);
                    break;
                case DamageType.Scale:
                    ScaleDamage(damage);
                    break;
                default:
                    break;
            }
        }

        private void HealthDamage(float damage)
        {
            m_currentHealth -= damage;

            if (OnTakeDamage != null) OnTakeDamage();

            if (m_currentHealth <= 0)
            {
                if (OnDeath != null) OnDeath();
            }
        }

        private void ScaleDamage(float reduceAmount)
        {
            transform.localScale -= new Vector3(reduceAmount, reduceAmount, 1.0f);

            if (OnTakeDamage != null) OnTakeDamage();

            if(transform.localScale.x <= 0.25f && transform.localScale.x <= 0.25f)
            {
                if (OnDeath != null) OnDeath();
            }
        }
    }
}

