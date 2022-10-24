using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlayerCollision : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D characterCollider;
    [SerializeField]
    private BoxCollider2D characterBlockerCollider;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(characterCollider, characterBlockerCollider, true);
    }
}
