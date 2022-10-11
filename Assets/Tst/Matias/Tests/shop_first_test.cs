using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class shop_first_test : MonoBehaviour
{
    [Test]
    public void shop_first_test()
    {
        SecretRoom SR1 = new SecretRoom();
        int IDcheck = SR1.SelectRoom();

        Assert.AreEqual(0, IDcheck);
    }

    [Test]
    public void after_shop_test()
    {
        SecretRoom SR2 = new SecretRoom();
        SR2.Shop = true;
        int IDcheck = SR2.SelectRoom();

        Assert.AreNotEqual(0, IDcheck);
    }
}
