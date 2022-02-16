using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerWheelCollider : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float steerAngel;
    private bool isBreaking;

    public float maxSteeringAngle = 20f;
    public float breakForce = 0f;
    public float motorforce = 230;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider RareLeftWheelCollider;
    public WheelCollider RareRightWheelCollider;

    public Transform frontLeftWheel;
    public Transform frontRightWheel;
    public Transform RareLeftWheel;
    public Transform RareRightWheel;

    Rigidbody rb;


    public bool bool_isforword;
    public bool bool_isbackword;
    public bool bool_isleft;
    public bool bool_isright;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        getInput();
        handelSteering();
        handelMotor();
        updateWheels();
    }
    void getInput()
    {
        //horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");

        #region Horizontal
        if(!bool_isleft&& !bool_isright)
        {
            horizontalInput = 0;
        }
        else
        {
            if (!bool_isright)
            {
                horizontalInput = 1;
            }
            else
            {
                horizontalInput = -1;
            }
        }
        #endregion
        #region Vertical
        if (!bool_isforword && !bool_isbackword)
        {
            verticalInput = 0;
        }
         else
        {
            if (!bool_isbackword)
            {
                verticalInput = 1;
            }
            else
            {
                verticalInput = -1;
            }
        }
        #endregion


        //isBreaking = Input.GetKey(KeyCode.Space);
    }
    void handelMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorforce;
        frontRightWheelCollider.motorTorque = verticalInput * motorforce;

        breakForce = isBreaking ? 3000f : 0f;
        frontLeftWheelCollider.brakeTorque = breakForce;
        frontRightWheelCollider.brakeTorque = breakForce;
        RareLeftWheelCollider.brakeTorque = breakForce;
        RareRightWheelCollider.brakeTorque = breakForce;
    }
    void handelSteering()
    {
        steerAngel = maxSteeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = steerAngel;
        frontRightWheelCollider.steerAngle = steerAngel;
    }
    void updateWheels()
    {
        UpdateWheelPos                                     (frontLeftWheelCollider, frontLeftWheel);
        UpdateWheelPos(frontRightWheelCollider, frontRightWheel);
        UpdateWheelPos(RareLeftWheelCollider, RareLeftWheel);
        UpdateWheelPos(RareRightWheelCollider, RareRightWheel);
    }
    void UpdateWheelPos(WheelCollider wheelcollider, Transform trans)
    {
        // Debug.Log("print");

        Vector3 pos;
        Quaternion rot;
        wheelcollider.GetWorldPose(out pos, out rot);
        trans.position = pos;
        trans.rotation = rot;

    }
  

    #region Car movement input
    public void Onclick_Forword(bool tempCondition)
    {
        bool_isforword = tempCondition;
    }
    public void Onclick_backword(bool tempCondition)
    {
        bool_isbackword = tempCondition;
    }
    public void Onclick_Left(bool tempCondition)
    {
        bool_isleft = tempCondition;
    }
    public void Onclick_right(bool tempCondition)
    {
        bool_isright = tempCondition;
    }
    public void Onclick_Break(bool tempCodition)
    {
        isBreaking = tempCodition;
    }
    #endregion
}
