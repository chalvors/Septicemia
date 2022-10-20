using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 1;

    void Update()
    {
        transform.Translate(Vector2.up * maxSpeed * Time.deltaTime);
    }
}
