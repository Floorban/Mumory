using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class AnimMovement : MonoBehaviour
{
    public Health health;
    PlayerInput playerInput;
    CharacterController characterController;
    Animator animator;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    bool isMovementPressed;
    float rotationFactorPerFrame = 3.5f;

    void Awake()
    {
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        playerInput.CharacterControls.Move.started += onMovementInput;
        playerInput.CharacterControls.Move.canceled += onMovementInput;
        playerInput.CharacterControls.Move.performed += onMovementInput;

        Health health = GetComponent<Health>();
    }

    void onMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    void handleRotation()
    {
        Vector3 positionToLookAt;

        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;

        Quaternion currentRotation = transform.rotation;

        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }
    }

    void handleAnimation()
    {
        bool walking = animator.GetBool("walking");

        if (isMovementPressed && !walking)
        {
            animator.SetBool("walking", true);
        }
        else if (!isMovementPressed && walking)
        {
            animator.SetBool("walking", false);
        }

        
    }
    void handleAnimationSad()
    {
        bool Sadwalk = animator.GetBool("Sanity");

        if (isMovementPressed && !Sadwalk)
        {
            animator.SetBool("Sanity", true);
        }
        else if (!isMovementPressed && Sadwalk)
        {
            animator.SetBool("Sanity", false);
        }
    }
    void Update()
    {
        if (health.health <= 50)
        {
        handleAnimationSad();
        }
        handleAnimation();
        handleRotation();
        characterController.Move(currentMovement * Time.deltaTime * 3.5f);
    }

    void OnEnable()
    {
        playerInput.CharacterControls.Enable();
    }

    void OnDisable()
    {
        playerInput.CharacterControls.Disable();
    }
}
