using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class shop_first_test : MonoBehaviour
{
    [Test]
    public void does_shop_come_first()
    {
        SecretRoom SR1 = new SecretRoom();
        int IDcheck = SR1.SelectRoom();

        Assert.AreEqual(0, IDcheck);
    }

    [Test]
    public void after_shop_test()
    {
        SecretRoom SR2 = new SecretRoom();
        SR2.shop = true;
        int IDcheck = SR2.SelectRoom();

        Assert.AreNotEqual(0, IDcheck);
    }
}
