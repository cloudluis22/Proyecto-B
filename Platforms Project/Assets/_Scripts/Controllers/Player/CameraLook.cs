using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class CameraLook : MonoBehaviour
{
    private CinemachineFreeLook _cinemachine;
    private PlayerControls _playerControls;

    [SerializeField]
    private float lookSpeed = 1f;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _cinemachine = GetComponent<CinemachineFreeLook>();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }
    
    void Update()
    {
        Vector2 delta = _playerControls.Land.Look.ReadValue<Vector2>();
        _cinemachine.m_XAxis.Value += delta.x * lookSpeed * 200 * Time.deltaTime;
        _cinemachine.m_YAxis.Value += delta.y * lookSpeed * Time.deltaTime;
        _cinemachine.m_YAxis.m_InvertInput = true;
    }
}
