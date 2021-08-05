using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRun : StateMachineBehaviour
{
    public float speed = 2.5f; // Speed variable
    public float range = 11f; // Range variable

    Transform player; // Player transform
    Rigidbody2D rb; // Rigidbody
    Boss boss; // Instance of the Boss script
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(GameObject.FindGameObjectWithTag("Player")) // If there is a player
        {
            player = GameObject.FindGameObjectWithTag("Player").transform; // Set the player transform
        }
        
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (player != null) // If there is a player
        {
            boss.TurnToTarget(); // Boss turns to the target
            Vector2 target = new Vector2(player.position.x, player.position.y); // The target's position
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime); // Calculate the new position
            rb.MovePosition(newPos); // Boss moves towards the target

            if (Vector2.Distance(player.position, rb.position) <= range)  // If the boss is in range
            {
                animator.SetTrigger("Attack"); // Trigger the attack
            }
        } 
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack"); // Reset the attack trigger
    }


}
