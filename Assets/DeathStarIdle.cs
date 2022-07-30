using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStarIdle : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       CheckPlayerEnter(animator);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    void CheckPlayerEnter(Animator animator)
    {
        Collider2D hit = Physics2D.OverlapCircle(animator.transform.position, 20, LayerMask.GetMask("Player"));
        if (hit)
        {
            Debug.Log("k");
            animator.SetTrigger("Phase1");
        }
    }

}
