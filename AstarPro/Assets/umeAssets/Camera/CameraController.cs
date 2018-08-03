using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    float speed;
    [SerializeField] Vector3 offset;
    [SerializeField]GameObject childCamera;
    [SerializeField]bool isFleeMode;
    private void Start()
    {
        childCamera.transform.localPosition = offset;
        childCamera.transform.LookAt(transform);
    }
    void Rot(float _speeed)
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up*_speeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.down*_speeed * Time.deltaTime);
        }
    }
    void UpDawn()
    {
        if(Input.GetKey(KeyCode.Space)){
            transform.Translate(Vector3.up*speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.LeftShift)){
            transform.Translate(Vector3.down*speed*Time.deltaTime);
        }
    }
    void ChangeOffSet()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            childCamera.transform.localPosition += Vector3.forward;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            childCamera.transform.localPosition += Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            childCamera.transform.localPosition += Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            childCamera.transform.localPosition += Vector3.back;
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            childCamera.transform.localPosition += Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            childCamera.transform.localPosition += Vector3.left;
        }
    }
    void FleeMove()
    {
        if (!isFleeMode) return;
        ChangeOffSet();
    }
    void Update () {
        KeyMove.MoveSixDirection(speed,transform);
        Rot(30.0f);
        FleeMove();
	}
}
