using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStarPhase1 : StateMachineBehaviour
{
    private GunController gunc;
    private Transform player;

    private Vector2 a;
    private Vector2 b;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       GameObject.FindWithTag("Barrier").GetComponent<Collider2D>().enabled = true;
       gunc = animator.GetComponent<GunController>();
       player = GameObject.FindWithTag("Player").transform;
       Debug.Log("k");
       //gunc.SetAllActive();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //PlayerCast();
       gunc.OnFire();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // void LocatePlayer(Animator animator)
    // {
    //     Collider2D hit = Physics2D.OverlapCircle(animator.transform.position, 20, LayerMask.GetMask("Player"));
    //     if (hit)
    //     {
    //         Debug.Log("k");
    //         animator.SetTrigger("Phase1");
    //     }
    // }

    // void PlayerCast()
    // {
    //     Collider2D hit = Physics2D.OverlapCircle(player.position, 8, LayerMask.GetMask("Weapon"));
    //     if (hit)
    //     {
    //         hit.GetComponent<Weapon>()._isActive = true;
    //     }
    // }
}
