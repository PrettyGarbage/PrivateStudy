using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 10.0f;
    [SerializeField] float _rotationSpeed = 20.0f;

    
    Vector3 _destPos = Vector3.zero;

    Define.PlayerState _state = Define.PlayerState.Idle;


    void Start()
    {
        Managers.Input.InputAction -= OnMouseClicked;
        Managers.Input.InputAction += OnMouseClicked;

        //Managers.UI.ShowSceneUI<UI_Inven>();
    }

    void UpdateDie()
    {
      
    }

    void UpdateMoving()
    {
        Vector3 dir = _destPos - transform.position; //방향 벡터 구하기
        if (dir.magnitude < 0.1f) //벡터의 뺄셈은 완전하게 0이 나오기 힘듦.
        {
            _state = Define.PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude); //값에 대한 보정
            transform.position += dir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), _rotationSpeed * Time.deltaTime);
        }

        //임시로 애니메이션 여기다가 붙여넣음.
        Animator anim = GetComponent<Animator>();
        anim.SetFloat(Constant.ANIM_SPEED, _speed);
    }

    void UpdateIdle()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetFloat(Constant.ANIM_SPEED, 0);
    }

    void Update()
    {
        switch(_state)
        {
            case Define.PlayerState.Die:
                UpdateDie();
                break;
            case Define.PlayerState.Moving:
                UpdateMoving();
                break;
            case Define.PlayerState.Idle:
                UpdateIdle();
                break;
        }
    }

    #region Callback
    void OnMouseClicked(Define.InputEvent evt)
    {
        if (_state == Define.PlayerState.Die)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100f, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, 1 << 7))
        {
            _destPos =  hit.point;
            _state = Define.PlayerState.Moving;
        }
    }

    void OnKeyboard()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            transform.position += Vector3.forward * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            transform.position += Vector3.back * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }
    }
    #endregion


}
