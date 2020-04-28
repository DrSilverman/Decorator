using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public delegate void Buttons();
    public static event Buttons JumpDown;
    public static event Buttons JumpUp;

    public static event Buttons MapDown;
    public static event Buttons MapUp;

    public static event Buttons AttackDown;
    public static event Buttons AttackUp;

    public static event Buttons DashDown;

    public static event Buttons Submit;
    public static event Buttons Cancel;

    public delegate void Axes(float value);
    public static event Axes Horizontal;
    public static event Axes Vertical;

    public delegate void Setting();
    public static event Setting Reset;

    private static bool _blockInput = false;
    public static bool Blockinput
    {

        get
        {

            return _blockInput;

        }
        set
        {

            _blockInput = value;

        }

    }

    private bool _mapDown = false;
    private bool _dashDown = false;

    public static void ResetPlayer()
    {

        Reset?.Invoke();

    }
    
    void Update()
    {

        if (!_blockInput)
        {

            if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                
                    JumpDown?.Invoke();

            }

            if (Input.GetKeyUp(KeyCode.Joystick1Button0) || Input.GetKeyUp(KeyCode.Joystick1Button1))
            {
                
                    JumpUp?.Invoke();

            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button4) || Input.GetAxis("Dash") < 0.5)
            {
                
                    MapDown?.Invoke();

                _mapDown = true;

            }

            if (Input.GetKeyUp(KeyCode.Joystick1Button4) || (Input.GetAxis("Dash") == 0 && _mapDown))
            {
                
                    MapUp?.Invoke();

                _mapDown = false;

            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.Joystick1Button3))
            {
                
                    AttackDown?.Invoke();

            }

            if (Input.GetKeyUp(KeyCode.Joystick1Button2) || Input.GetKeyUp(KeyCode.Joystick1Button3))
            {
                    AttackUp?.Invoke();

            }

            if (Input.GetAxis("Dash") > 0.5 || Input.GetKeyDown(KeyCode.Joystick1Button5))
                    DashDown?.Invoke();


        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {

            Submit?.Invoke();

        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {

            Cancel?.Invoke();

        }
    }

    private void FixedUpdate()
    {

        if (!_blockInput)
            Horizontal?.Invoke(Input.GetAxis("Horizontal"));

        if (!_blockInput)
            Vertical?.Invoke(Input.GetAxis("Vertical"));

    }

}
