using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DeathStarPhase1 : StateMachineBehaviour
{
    private GunController gunc;
    private Transform player;
    private CinemachineVirtualCamera vcam;
    private float count;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       GameObject.FindWithTag("Barrier").GetComponent<Collider2D>().enabled = true;
       animator.GetComponentInChildren(typeof(Canvas)).gameObject.GetComponent<Canvas>().enabled = true;
       gunc = animator.GetComponent<GunController>();
       player = GameObject.FindWithTag("Player").transform;
       count = gunc.inventory.Count;
       
       vcam = GameObject.FindWithTag("VCam").GetComponent<CinemachineVirtualCamera>();
       vcam.m_Lens.OrthographicSize = 10;
       GameObject.FindWithTag("Background").transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
       //gunc.SetAllActive();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       gunc.OnFire();
       if (animator.GetComponent<Health>().GetCurrentHealth() <= (animator.GetComponent<Health>().GetMaxHealth() / 2))
       {
            animator.SetTrigger("Phase2");
       }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
