using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using Debug = System.Diagnostics.Debug;

namespace Enemies
{
    public interface IEnemy
    {
        string GetDetails();
    }

    public class BaseEnemy : IEnemy
    {
        public string GetDetails() => "Melee attacks";
    }

    public abstract class EnemyTypes : IEnemy
    {
        private readonly IEnemy _enemy;

        public EnemyTypes (IEnemy enemy)
        {
            _enemy = enemy;
        }

        public virtual string GetDetails() => _enemy.GetDetails();
    }

    public class RifleEnemy : EnemyTypes
    {
        public RifleEnemy(IEnemy enemy) : base(enemy)
        {

        }
        public override string GetDetails() => "Rifle attacks";
    }

    public class PistolEnemy : EnemyTypes
    {
        public PistolEnemy(IEnemy enemy) : base(enemy)
        {

        }
        public override string GetDetails() => "Pistol attacks";
    }

    public class TankEnemy : EnemyTypes
    {
        public TankEnemy(IEnemy enemy) : base(enemy)
        {

        }
        public override string GetDetails() => base.GetDetails() + " and more health";
    }

    public class EnemyCreator
    {
        public static void UpgradeEnemy()
        {
            var basicEnemy = new BaseEnemy();
            EnemyTypes upgraded = new RifleEnemy(basicEnemy);

            Debug.WriteLine($"Enemy: '{upgraded.GetDetails()}'");
        }
    }
}

/*
 * 
 * 
 * instantiate a new enemy
 * script to override the base stats
 * make your new enemy getcomponents of the base enemy
 * base enemy stats must be protected
 * you can create a temporary enemy
 * override function to change enemy into temp enemy
 * 
 * 
 * 
 */