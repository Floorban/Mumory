using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 move; 

    Animator animator;

    //public HUD Hud;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
   
    void Start()
    {
       animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        movePlayer();
    }

    public void movePlayer()
    {
        if (move.sqrMagnitude > 0.1f){
            Vector3 movement = new Vector3(move.x, 0f, move.y);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);

            transform.Translate(movement * speed * Time.deltaTime, Space.World);

            animator.SetBool("isWalking", true);
        }
    
    }
}
