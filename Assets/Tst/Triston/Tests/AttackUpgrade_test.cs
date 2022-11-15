using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AttackUpgrade_Test
{
    // A Test behaves as an ordinary method
    [Test]
    public void Upgrade_Attack_Stat_Once()
    {
        TestPlayer P1 = new();
        P1.decorateDamage();
        int attack = P1.stats.getDamage();
        Assert.AreEqual(15, attack);
    }

    [Test]
    public void Upgrade_Attack_Stat_Twice()
    {
        TestPlayer P1 = new();
        P1.decorateDamage();
        P1.decorateDamage();
        int attack = P1.stats.getDamage();
        Assert.AreEqual(20, attack);
    }

    [Test]
    public void Upgrade_Attack_Stat_ThreeTimes()
    {
        TestPlayer P1 = new();
        P1.decorateDamage();
        P1.decorateDamage();
        P1.decorateDamage();
        int attack = P1.stats.getDamage();
        Assert.AreEqual(25, attack);
    }
}
