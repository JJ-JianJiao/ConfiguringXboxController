//https://www.youtube.com/watch?v=p-3S73MaDP8
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class Cude : MonoBehaviour
{
    InputMaster controls;

    Vector2 move;
    Vector2 rotate;

    private void Awake()
    {
        controls = new InputMaster();

        controls.Player.Attack.performed += ctx => Grow();
        controls.Player.Jump.performed += ctx => TurnSmall();

        controls.Player.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();

        controls.Player.Movement.canceled += ctx => move = Vector2.zero;

        controls.Player.Rotate.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        controls.Player.Rotate.canceled += ctx => rotate = Vector2.zero;
    }

    private void Update()
    {
        Vector2 m = new Vector2(-move.x, move.y) * Time.deltaTime;
        transform.Translate(m, Space.World);

        Vector2 v = new Vector2(-rotate.y, -rotate.x) * 100 * Time.deltaTime;
        transform.Rotate(new Vector3(v.x, v.y, 0));
    }


    private void FixedUpdate()
    {
        //var gamePad = Gamepad.current;
        //if (gamePad == null) return;

        //move =  gamePad.leftStick.ReadValue();
        //Vector2 m = new Vector2(-move.x, move.y) * Time.deltaTime;
        //transform.Translate(m, Space.World);

        //rotate = gamePad.rightStick.ReadValue();

        //Vector2 v = new Vector2(-rotate.y, -rotate.x) * 100 * Time.deltaTime;
        //transform.Rotate(new Vector3(v.x, v.y, 0));

        ////if (gamePad.buttonEast.isPressed) {
        //if (gamePad.buttonEast.IsPressed()) {
        //    TurnSmall();
        //}
        ////if (gamePad.buttonSouth.isPressed) {
        //if (gamePad.buttonSouth.IsPressed()) {
        //        Grow();
        //}
    }

    void Grow() {
        transform.localScale *= 1.1f;
    }

    void TurnSmall() {
        transform.localScale /= 1.1f;
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }
}
