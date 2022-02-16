using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float followSpeed = 10f;
    public float lookSpeed = 5f;
    public Transform objectToFollow;
    public Vector3 offset;
 
    private void FixedUpdate()
    {
    
    moveToTarget();
        lookAtTarget();
    }
   
    void moveToTarget()
    {
        Vector3 targetPos = objectToFollow.position + objectToFollow.forward * offset.z + objectToFollow.right * offset.x + objectToFollow.up * offset.y;
        transform.position = Vector3.Lerp(transform.position,targetPos, followSpeed * Time.deltaTime);
    }
    void lookAtTarget()
    {
        Vector3 lookDirection = objectToFollow.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(lookDirection,Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation , rot , lookSpeed * Time.deltaTime);
    }

}
