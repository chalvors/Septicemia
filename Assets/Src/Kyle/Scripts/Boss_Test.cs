using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DecoratorPattern;


namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IBoss boss = new Boss();
            Console.WriteLine(boss.GetBossType());
            //Decorator Design Patter
        }
    }

    // base interface
    interface IBoss
    {
        string GetBossType();
    }
        


    // concrete implementation
    class Boss : IBoss
    {
        
        public string GetBossType()
        {
            return "This is a normal Boss";
        }
    }

    // base decorator
    class BossDecorator : IBoss
    {
        private IBoss _boss;

        public BossDecorator(IBoss boss)
        {
            _boss = boss;
        }
        public virtual string GetBossType()
        {
            return _boss.GetBossType();
        }
    }

    //concret decorators
    class AttackDecorator : BossDecorator
    {
        public AttackDecorator(IBoss boss) : base(boss) { }

        public override string GetBossType()
        {
            string type = base.GetBossType();
            type += "\r\n with a better attack";
            return type;
        }
    }

    class RangedAttackDecorator : BossDecorator
    {
        public RangedAttackDecorator(IBoss boss) : base(boss) { }

        public override string GetBossType()
        {
            string type = base.GetBossType();
            type += "\r\n  and with a new ranged attack";
            return type;
        }
    }
}

public class Boss_Test : MonoBehaviour
{




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
