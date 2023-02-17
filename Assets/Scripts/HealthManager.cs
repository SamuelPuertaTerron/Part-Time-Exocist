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

        private float m_currentHealth;

        private void Start()
        {
            m_currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            m_currentHealth -= damage;

            if(OnTakeDamage != null) OnTakeDamage();

            if(m_currentHealth <= 0)
            {
                if(OnDeath != null) OnDeath();
            }
        }
    }
}

