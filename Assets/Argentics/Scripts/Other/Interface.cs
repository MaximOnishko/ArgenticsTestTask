using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Argentics._2D
{
    public interface IDying
    {
        int health { get; set; }
        void TakeDamage(int decreaseCount = 1);
        void Healing(int increaseCount = 1);
    }
    public interface IEnemy
    {
        float speed { get;}
        int attackDamage { get;}
        GameObject player { get;}
        float distanceToPlayer { get; }
        float attackDistance { get; }
    }
    public interface IMove
    {
        void Move();
    }
    public interface IAttack
    {
        void Attack();
    }
}


