using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartTimeExocist
{
    public class GhostAIBase : MonoBehaviour
    {
        [Header("Basic Info")]
        [SerializeField] private string enemyName = "Enemy Base";

        [Header("Movement")]
        [SerializeField] private float startMovementTimer = 2.5f;
        [SerializeField, Range(0.5f, 10.0f)] private float walkRange = 5.0f;

        [Header("Health & Damage")]
        [SerializeField, Range(0.5f, 10.0f)] private float attackRange = 5.0f;
        [SerializeField] private float startAttackTimer = 1.0f;
        [SerializeField] private float playerDamage = 15.0f;

        [Header("Debug")]
        [SerializeField] private bool debug = true;

        protected virtual void OnStart()
        {

        }

        protected virtual void OnIdle()
        {

        }

        protected virtual void OnAttack()
        {

        }

        protected virtual void OnTakeDamage()
        {
        }

        protected virtual void OnDeath()
        {

        }

        protected virtual void OnMove()
        {

        }

        //---------Private----------------------------//

        #region Private 

        private enum EEnemyState
        {
            None = 0,
            Idle = 1,
            Move = 2,
            Attack = 3,
            Damage = 4
        }

        private EEnemyState m_enemyStates = EEnemyState.Move;
        private Transform m_player;

        private HealthManager m_healthManager;

        private float m_currentMovementTimer;
        private float m_currentAttackTimer;
        private Vector2 m_pos;


        private void Awake()
        {
            m_healthManager = GetComponent<HealthManager>();

            if (m_healthManager == null)
            {
                Debug.LogError("Health Manager is Null: Assign it in the inspector");
            }
        }

        private void OnEnable()
        {
            m_healthManager.OnTakeDamage += OnTakeDamage;
            m_healthManager.OnDeath += OnDeath;
        }

        private void OnDisable()
        {
            m_healthManager.OnTakeDamage -= OnTakeDamage;
            m_healthManager.OnDeath -= OnDeath;
        }

        private void Start()
        {
            m_player = FindObjectOfType<TouchInput>().transform;

            if (m_player == null)
            {
                Debug.LogError("Player is Null: Cannot find player");
            }

            m_currentMovementTimer = startMovementTimer;
            m_currentAttackTimer = startAttackTimer;

            OnStart();
        }

        private void Update()
        {
            switch (m_enemyStates)
            {
                case EEnemyState.Idle:
                    IdleState();
                    break;
                case EEnemyState.Move:
                    MoveState();
                    break;
                case EEnemyState.Attack:
                    AttackState();
                    break;
                case EEnemyState.Damage:
                    break;
            }
        }

        private void IdleState()
        {
            OnIdle();
        }

        private void MoveState()
        {
            if (m_player == null)
            {
                return;
            }

            //Attacking Based on random chance

            OnMove();
        }

        private void AttackState()
        {
            if (m_player == null)
            {
                return;
            }
            
            if (m_currentAttackTimer <= 0)
            {
                m_player.GetComponent<HealthManager>().TakeDamage(playerDamage);
                m_currentAttackTimer = startAttackTimer;
            }
            else
            {
                m_currentAttackTimer -= Time.deltaTime;
            }

            OnAttack();
        }

        void OnDrawGizmos()
        {
            if (debug)
            {
                Gizmos.DrawWireSphere(transform.position, walkRange);
                Gizmos.DrawWireSphere(transform.position, attackRange);
                Gizmos.DrawWireCube(transform.position, m_pos);
            }
        }
    }
    #endregion
}


