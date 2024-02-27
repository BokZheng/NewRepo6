using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemymovement : movement
{
    private int randommovement;

    public Transform Target;
    protected override void HandleInput()
    {
        if (Target == null)
        {
            Target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (Target == null)
            return;

        Vector2 targetdirection = Target.position - transform.position;
        targetdirection = targetdirection.normalized;

        inputDirection = targetdirection;

    }
    // Start is called before the first frame update
  
}
