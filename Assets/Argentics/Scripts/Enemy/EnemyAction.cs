using System.Collections;
using System.Linq;
using UnityEngine;

namespace Argentics._2D
{
    [RequireComponent(typeof(EnemyData))]
    public class EnemyAction : MonoCached
    {
        private bool playerDie = false;
        private IMove _IMove;
        private IAttack _IAttack;
        private IEnemy _IEnemy;

        private void Start()
        {
            PlatformerCharacter.EDeath += PlatformerCharacter_EDeath;

            _IMove = GetComponent<IMove>();
            _IAttack = GetComponent<IAttack>();
            _IEnemy = GetComponent<IEnemy>();
        }

        private void PlatformerCharacter_EDeath(object sender, System.EventArgs e)
        {
            playerDie = true;
        }

        public override  void OnTick()
        {
            if (playerDie)
                return;

            if (_IEnemy.distanceToPlayer < _IEnemy.attackDistance)
                _IAttack.Attack();
            else
                _IMove.Move();
        }
    }
}
