using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // private var
    [SerializeField] GameObject _player = null;

    [Header("Set Value")]
    [SerializeField] Define.CameraMode _mode = Define.CameraMode.QuarterView;
    [SerializeField] Vector3 _delta = new Vector3(0f, 6.0f, -5.0f); //���ͺ� �⺻
    [SerializeField] float _wallDepth = 0.8f;
    [SerializeField] float _correctionY = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        if(_mode == Define.CameraMode.QuarterView)
        {
            RaycastHit hit;
            if(Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, 1 << 7))
            {
                float dist = (hit.point - _player.transform.position).magnitude * _wallDepth;
                transform.position = PositionCorrection(_player.transform.position) + _delta.normalized * dist;
            }
            else
            {
                transform.position = _player.transform.position + _delta;
                transform.LookAt(_player.transform);
            }
        }
    }

    /// <summary>
    /// player�� ���������� ������ y���� �ٴ��� �ٶ󺸱� ������ �����������.
    /// </summary>
    Vector3 PositionCorrection(Vector3 pos)
    {
        return new Vector3(pos.x, Mathf.Max(pos.y, _correctionY), pos.z);
    }

    public void SetQuaterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuarterView;
        _delta = delta;
    }
}
