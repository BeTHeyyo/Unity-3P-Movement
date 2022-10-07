using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    InputControls inputControls;
    Animator m_Animator;

    public float runSpeed = 4f;
    float currentSpeed;
    float desiredSpeed;
    float speed;

    public float decelaration = 20f;
    public float acceleration = 20f;

    private void Start()
    {
        inputControls = GetComponent<InputControls>();
        m_Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Debug.Log(inputControls.movement);
        Move(inputControls.movement);
    }

    public void Move(Vector2 movementVector)
    {
        bool isMoving = Mathf.Approximately(movementVector.magnitude, 0);

        currentSpeed = runSpeed;
        desiredSpeed = movementVector.magnitude * currentSpeed;

        float accel = isMoving ? acceleration : decelaration;
        speed = Mathf.MoveTowards(speed, desiredSpeed, accel * Time.deltaTime);
        m_Animator.SetFloat("Velocity", speed);
    }
}
