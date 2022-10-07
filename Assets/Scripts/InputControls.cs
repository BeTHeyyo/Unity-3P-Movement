using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputControls : MonoBehaviour
{
    ProjectKonechnaya controls;
    [HideInInspector] public Vector2 movement;
    [HideInInspector] public Vector2 look;
    [HideInInspector] public bool jump;
    [HideInInspector] public bool run;
    [HideInInspector] public bool walk;

    private void Awake()
    {
        controls = new ProjectKonechnaya();
        controls.Player.Jump.performed += ctx => jump = ctx.ReadValueAsButton();
        controls.Player.Jump.canceled += ctx => jump = ctx.ReadValueAsButton();
        controls.Player.Run.performed += ctx => run = ctx.ReadValueAsButton();
        controls.Player.Run.canceled += ctx => run = ctx.ReadValueAsButton();
        controls.Player.Move.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => movement = ctx.ReadValue<Vector2>();
        controls.Player.Walk.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.Player.Walk.canceled += ctx => movement = ctx.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        if (controls != null)
            controls.Enable();
    }

    private void OnDisable()
    {
        if (controls != null)
            controls.Disable();
    }

    private void Update()
    {

    }

}
