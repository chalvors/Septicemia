using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace EnemyDecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnemy enemy = new Enemy();
            IEnemy enemyDecorator = new EnemyDecorator(enemy);
            IEnemy attackDecorator = new AttackDecorator(enemyDecorator);
            IEnemy moveDecorator = new MoveDecorator(attackDecorator);
            IEnemy healthDecorator = new HealthDecorator(moveDecorator);
            Debug.Log("Got here **************************");
            System.Diagnostics.Debug.WriteLine(healthDecorator.GetEnemyType());
        }
    }
    interface IEnemy
    {
        string GetEnemyType();
    }

    // Concrete Implementation
    class Enemy : IEnemy
    {
        public string GetEnemyType()
        {
            return "This is a normal enemy";
        }
    }

    // Base Decorator
    class EnemyDecorator : IEnemy
    {
        private IEnemy _enemy;

        public EnemyDecorator(IEnemy enemy)
        {
            _enemy = enemy;
        }

        public virtual string GetEnemyType()
        {
            return _enemy.GetEnemyType();
        }
    }

    // Concrete Decorators
    class AttackDecorator : EnemyDecorator
    {
        public AttackDecorator(IEnemy enemy) : base(enemy) { }

        public override string GetEnemyType()
        {
            string type = base.GetEnemyType();
            type += " with a different base attack";
            return type;
        }
    }

    class MoveDecorator : EnemyDecorator
    {
        public MoveDecorator(IEnemy enemy) : base(enemy) { }

        public override string GetEnemyType()
        {
            string type = base.GetEnemyType();
            type += " with a different stopping distance";
            return type;
        }
    }

    class HealthDecorator : EnemyDecorator
    {
        public HealthDecorator(IEnemy enemy) : base(enemy) { }

        public override string GetEnemyType()
        {
            string type = base.GetEnemyType();
            type += " with a larger healthbar";
            return type;
        }
    }
}
