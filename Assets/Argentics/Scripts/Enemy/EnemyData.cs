using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Argentics._2D
{
    public class EnemyData : MonoBehaviour ,IEnemy
    {
        public enum EnemyType { archer }
        public EnemyType enemyType;

        [SerializeField] private float _speed;
        [SerializeField] private int _attackDamage;
        [SerializeField] private float _attackDistance;
        [SerializeField] private float _attackSpeed;
        [SerializeField] private float _attackDelay;

        public float speed => _speed;
        public int attackDamage => _attackDamage;
        public GameObject player { get; private set; }
        public float distanceToPlayer
        { get
            { return Vector3.Distance(gameObject.transform.position, player.transform.position); }
        }
        public float attackDistance => _attackDistance;
        public float attackSpeed => _attackSpeed;
        public float attackDelay => _attackDelay;
        
        public GameObject[] moveToPoints;
        private int currentPoint;
        [HideInInspector] public CharacterController characterController;
        [HideInInspector] public NavMeshAgent navMeshAgent;
        [HideInInspector] public Animator animator;

        private void Awake()
        {
            currentPoint = 0;
            characterController = GetComponent<CharacterController>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.speed = speed;
            animator = GetComponent<Animator>();
            player = GameObject.FindGameObjectWithTag("Player");

            switch (enemyType)
            {
                case EnemyData.EnemyType.archer:
                    if (GetComponent<Archer>() == null)
                        gameObject.AddComponent<Archer>();
                    break;
            }
        }
        public GameObject GetCurrentPoint(Vector3 archerPos)
        {
            if (Vector3.Distance(archerPos, moveToPoints[currentPoint].transform.position) < 0.4f)
            {
                currentPoint++;
                Debug.Log(currentPoint);
                if (currentPoint == moveToPoints.Length)
                    currentPoint = 0;
            }
            Debug.Log(moveToPoints[currentPoint]);
            return moveToPoints[currentPoint];
        }
    }
}
