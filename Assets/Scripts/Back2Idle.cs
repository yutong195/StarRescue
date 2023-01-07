using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back2Idle : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isHit", false);
    }
}
