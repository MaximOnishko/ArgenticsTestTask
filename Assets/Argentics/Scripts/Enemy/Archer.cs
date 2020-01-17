using System.Collections;
using System.Linq;
using UnityEngine;

namespace Argentics._2D
{
    public class Archer : MonoBehaviour, IAttack,IMove
    {
        private Ray ray;
        private RaycastHit raycastHit;

        private bool attack;
        private float speed;

        private EnemyData _enemyData;
        private bool swithState;

        private Vector3 targetPoint;
        private Quaternion targetRotation;

        public enum ArcherState {run,idle}
        public ArcherState _archerState;

        private void Start()
        {
            _enemyData = GetComponent<EnemyData>();
            ray = new Ray(transform.position, transform.forward);
            _archerState = ArcherState.idle;
        }

        public void Attack()
        {
            targetPoint = transform.position - new Vector3(_enemyData.player.transform.position.x, transform.position.y, transform.position.z);
            targetRotation = Quaternion.LookRotation(-targetPoint, Vector3.up);
            transform.rotation = targetRotation;

            if (!attack)
            {
                attack = true;
                _enemyData.animator.SetFloat("Speed", 0);
                _enemyData.animator.SetTrigger("Shot");
                StartCoroutine(AttackDelay());
                StartCoroutine(SwithState(ArcherState.idle, 0));
            }           
        }
        public void AnimShotEnd()
        {
            var arrow = ArrowsList.Instance.arrows.FirstOrDefault(x => !x.activeInHierarchy);
            if (arrow != null)
            {
                arrow.transform.position = transform.position + Vector3.up * 0.8f;
                Arrow arrowcs = arrow.GetComponent<Arrow>();
                Damaging damaging = arrow.GetComponent<Damaging>();

                arrowcs.direction = transform.forward;


                arrowcs.speed = _enemyData.attackSpeed;
                damaging.damage = _enemyData.attackDamage;
                arrow.SetActive(true);
                arrowcs.StartCoroutine(arrowcs.DisableByTime());
            }
        }
        public void Move()
        {
            switch (_archerState)
            {
                case ArcherState.idle:
                    Idle();
                    break;
                case ArcherState.run:
                    Run();
                    break;
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (speed != 0)
                Uturn();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Wall")
                Uturn();
        }
        private void Run()
        {
            speed = 1;
            _enemyData.animator.SetFloat("Speed", speed);
            _enemyData.characterController.Move(transform.forward * Time.deltaTime * _enemyData.speed);
            if (!swithState) StartCoroutine(SwithState(ArcherState.idle, Random.Range(5, 10)));
        }
        private void Uturn()
        {
            if (attack)
                return;

            transform.Rotate(0, 180, 0);
        }
        private void Idle()
        {
            speed = 0;
            _enemyData.animator.SetFloat("Speed", speed);
            if (!swithState) StartCoroutine(SwithState(ArcherState.run, Random.Range(5, 10)));
        }
        IEnumerator AttackDelay()
        {
            yield return new WaitForSeconds(_enemyData.attackDelay);
            attack = false;
        }
        IEnumerator SwithState(ArcherState archerState,float delay)
        {
            swithState = true;
            yield return new WaitForSeconds(delay);
            var i = Random.Range(0, 2);
            if (i == 0)
                Uturn(); 

            _archerState = archerState;
            swithState = false;
        }
        
    }
}
