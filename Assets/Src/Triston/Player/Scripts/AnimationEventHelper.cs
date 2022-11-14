using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/*
 * triggers player events to run functions from animations
 */
public class AnimationEventHelper : MonoBehaviour
{
    public UnityEvent OnAttackPerformed;

    public void TriggerAttack()
    {
        //invokes the player attack function
        OnAttackPerformed?.Invoke(); 
    }
}
