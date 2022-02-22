using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Space(5)]
    [Header("Move Player")]
    [SerializeField] private FloatingJoystick joystickPlayer;
    [SerializeField] private GameObject PathSnow;
    [SerializeField] private PlayerVariable _speedRotation;
    [SerializeField] private PlayerVariable _speedPlayer;

    public static event Action OnIceOver;    
    public static event Action OnGameOver;
    public static event Action OnGameRestart;

    private void Start()
    {
        PathSnow.SetActive(false);

        _speedPlayer.valueSpeed = 0;

        _speedRotation.valueSpeedRotation = 45;
    }

    void FixedUpdate()
    {
        PlayerMove();
        PlayerRotatio();
    }

    private void PlayerMove()
    {
        transform.position += transform.forward * _speedPlayer.valueSpeed * Time.deltaTime;
    }

    private void PlayerRotatio()
    {
        if (joystickPlayer.Horizontal != 0)
        {
            transform.rotation = Quaternion.Euler(0, joystickPlayer.Horizontal * _speedRotation.valueSpeedRotation, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ice ice))
        {
            ice.ExplodeWithDelay();
        }

        if (other.TryGetComponent(out StartIce startIce))
        {
            PathSnow.SetActive(true);

            this.gameObject.GetComponent<IceGeneration>().enabled = true;
        }

        if (other.TryGetComponent(out FinishIce finishIce))
        {
            OnIceOver?.Invoke();

            this.gameObject.GetComponent<IceGeneration>().enabled = false;
        }

        if (other.TryGetComponent(out FinishGame finishGame))
        {
            finishGame.ExplodeFinish();

            OnGameOver?.Invoke();

            _speedPlayer.valueSpeed = 0;

            _speedRotation.valueSpeedRotation = 0;

            transform.forward = new Vector3(0, 0, 0);
        }

        if (other.TryGetComponent(out CarRoad carRoad))
        {
            OnGameRestart?.Invoke();

            _speedPlayer.valueSpeed = 0;

            _speedRotation.valueSpeedRotation = 0;

            transform.forward = new Vector3(0, 0, 0);
        }
    }
}
