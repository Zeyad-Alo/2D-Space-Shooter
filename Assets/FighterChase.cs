using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterChase : StateMachineBehaviour
{
    private Transform player;
    [SerializeField] public float ChaseSpeed;
    [SerializeField] public float StopChaseTimer;
    private float timer = 0;
    [SerializeField] public float ExitDetectRadius;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.up = player.position - animator.transform.position;
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, player.position, ChaseSpeed * Time.deltaTime);
        
        StopChase(animator);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    void StopChase(Animator animator)
    {
        Collider2D hit = Physics2D.OverlapCircle(animator.transform.position, ExitDetectRadius, LayerMask.GetMask("Player"));
        if (!hit)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
        }

        if (timer >= StopChaseTimer)
        {
            timer = 0;
            animator.SetBool("Chase", false);
        }

        Debug.Log(timer);
    }
}
