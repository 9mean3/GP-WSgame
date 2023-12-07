using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    public InputReader InputReader => inputReader;

    public Rigidbody RigidbodyCompo { get; private set; }
    public PlayerStateMachine StateMachine { get; private set; }

    [SerializeField] private Transform camPos;

    [SerializeField] private float mouseSpeed;
    [SerializeField] private float moveSpeed;

    private float camRot;

    private void Awake()
    {
        RigidbodyCompo = GetComponent<Rigidbody>();
        StateMachine = new PlayerStateMachine();

        foreach (PlayerStateEnum stateEnum in Enum.GetValues(typeof(PlayerStateEnum)))
        {
            string typeName = $"Player{stateEnum.ToString()}State";
            try
            {
                Type type = Type.GetType(typeName);
                PlayerState instance = Activator.CreateInstance(type) as PlayerState;
                StateMachine.AddState(stateEnum, instance);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }

    private void Update()
    {
        CamRot();
    }

    private void CamRot()
    {
        float inputX = InputReader.Look.x * mouseSpeed * Time.deltaTime;
        float inputY = InputReader.Look.y * mouseSpeed * Time.deltaTime;
        camRot += inputY;
        camRot = Mathf.Clamp(camRot, -85, 85);

        //camPos.Rotate(new Vector2( -InputReader.Look.y, 0));
        camPos.localEulerAngles = new Vector3(-camRot, 0f, 0f);
        transform.Rotate(new Vector2(0, InputReader.Look.x));
    }

    public void SetVelocity(float x, float y, float z)
    {
        RigidbodyCompo.velocity = new Vector3(x, y, z);
    }

    public void StopImmediately(bool withYAxis)
    {
        if (!withYAxis)
            RigidbodyCompo.velocity = Vector3.zero;
        else
            RigidbodyCompo.velocity = new Vector3(0, RigidbodyCompo.velocity.y, 0);
    }
}
