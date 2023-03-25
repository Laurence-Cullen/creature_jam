using UnityEngine;

public class Dying : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Print
        Debug.Log("OnStateEnter Dying");

        // Call Freeze method on the creature
        animator.GetComponent<Creature>().Kill();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Prefab to instantiate
        var preFab = animator.GetComponent<Creature>().corpsePrefab;

        // Destroy the game object
        Destroy(animator.gameObject);

        // Stop the animation
        animator.enabled = false;

        // Destroy the animator
        // Destroy(animator);

        // Instantiate corpsePrefab at the position of the creature
        Instantiate(preFab, animator.transform.position, Quaternion.identity);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}