using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.InputEvent> InputAction = null;

    bool _pressed = false;

    public void OnUpdate()
    {
        //UI 이벤트시엔 이동이 안먹도록
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.anyKey != false && KeyAction != null)
            KeyAction.Invoke();

        if(InputAction != null)
        {
            if(Input.GetMouseButton(0))
            {
                InputAction.Invoke(Define.InputEvent.Press);
                _pressed = true;
            }
            else
            {
                if (_pressed)
                    InputAction.Invoke(Define.InputEvent.Click);

                _pressed = false;
            }
        }
    }

    public void Clear()
    {
        KeyAction = null;
        InputAction = null;
    }
}
