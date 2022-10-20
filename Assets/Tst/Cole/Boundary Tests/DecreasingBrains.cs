using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
public class DecreasingBrains : MonoBehaviour
{
    [Test]
    public void set_brains_to_50_decrease_by_50() {
        HUD h1 = new HUD();
        h1.num_brains = 50;
        h1.purchase(50);

        Assert.AreEqual(0, h1.num_brains);
    }

    [Test]
    public void set_brains_to_50_decrease_by_51() {
        HUD h1 = new HUD();
        h1.num_brains = 50;
        h1.purchase(51);

        Assert.AreEqual(50, h1.num_brains);
    }
}
