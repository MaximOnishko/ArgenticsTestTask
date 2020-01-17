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
            targetPoint = transform.position - new Vector3(_enemyData.player.transform.position.x, transform.position.y, _enemyData.player.transform.position.z);
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
                //enemyData.animator.SetTrigger("Shot");
                arrow.transform.position = transform.position + Vector3.up * 0.8f;
                Arrow arrowcs = arrow.GetComponent<Arrow>();
                Damaging damaging = arrow.GetComponent<Damaging>();
                //arrowcs.direction = (_enemyData.player.transform.position - transform.position).normalized;
                arrowcs.direction = transform.forward;
                //arrowcs.direction.y = 0;
                //arrowcs.direction.z = 0;

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
            Uturn();
        }
        private void Run()
        {
            Debug.Log("Run");
            _enemyData.animator.SetFloat("Speed", 1);
            _enemyData.characterController.Move(transform.forward * Time.deltaTime * _enemyData.speed);
            if (!swithState) StartCoroutine(SwithState(ArcherState.idle, Random.Range(5, 10)));
        }
        private void Uturn()
        {
            transform.Rotate(0, 180, 0);
        }
        private void Idle()
        {
            _enemyData.animator.SetFloat("Speed", 0);

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
            Debug.Log(i);
            if (i == 0)
                Uturn(); 

            _archerState = archerState;
            swithState = false;
        }
        
    }
}
