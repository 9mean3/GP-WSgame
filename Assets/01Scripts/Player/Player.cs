using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    public InputReader InputReader => inputReader;

    public CharacterController CharacterControllerCompo { get; private set; }
    public PlayerStateMachine StateMachine { get; private set; }

    [SerializeField] private Transform camPos;

    [SerializeField] private float mouseSpeed;
    [SerializeField] private float moveSpeed;

    private float camRot;

    private void Start()
    {
        CharacterControllerCompo = GetComponent<CharacterController>();
        StateMachine = new PlayerStateMachine();

        foreach (PlayerStateEnum stateEnum in Enum.GetValues(typeof(PlayerStateEnum)))
        {
            string typeName = stateEnum.ToString();
            try
            {
                Type type = Type.GetType($"Player{typeName}State");
                PlayerState instance = Activator.CreateInstance(type, this, StateMachine) as PlayerState;
                StateMachine.AddState(stateEnum, instance);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        StateMachine.Initialize(PlayerStateEnum.Idle, this);
    }

    bool isShooting = false;
    private void Update()
    {
        StateMachine.CurrentState.Update();

        CamRot();
    }

    private void CamRot()
    {
        float inputX = InputReader.Look.x * mouseSpeed * Time.deltaTime;
        float inputY = InputReader.Look.y * mouseSpeed * Time.deltaTime;
        camRot += inputY;
        camRot = Mathf.Clamp(camRot, -85, 85);

        camPos.localEulerAngles = new Vector3(-camRot, 0f, 0f);
        transform.Rotate(new Vector2(0, inputX));
    }

    public void SetVelocity(Vector3 dir)
    {
        dir = dir.x * transform.right + dir.z * transform.forward;
        CharacterControllerCompo.Move(dir * moveSpeed * Time.deltaTime);
    }

    public void StopImmediately()
    {
        CharacterControllerCompo.Move(Vector3.zero);
    }
}
