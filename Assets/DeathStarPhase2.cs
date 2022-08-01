using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStarPhase2 : StateMachineBehaviour
{
    private GunController gunc;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gunc = animator.GetComponent<GunController>();
       gunc.inventory.Find(x => x.name == "LaserGun")._isActive = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       gunc.OnFire();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
