using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class attack_change_test : MonoBehaviour
{
    [Test]
    public void set_attack_to_20_and_take_away_19()
    {
        Bosses B1 = new Bosses();
        B1.attackDamage = 20;
        int changeAttackDamge = 19;

        //int newDamage = B1.ChangeAttack(B1.attackDamage, changeAttackDamge);

        //Assert.AreEqual(1, newDamage);
    }
}
