using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionXController : MonoBehaviour
{
    public bool Activate_OSC = true;
    public string address;
    public float rotX = 0;
    public bool reverse = true;
    public float rotOffset = 0;
    public float dampSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        OSC.instance.SetAddressHandler(address, OnReceiveRotX);
    }

    
    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation,Quaternion.Euler(new Vector3(-90, rotX, 0)),Time.deltaTime * dampSpeed);
        
    }

    void OnReceiveRotX(OscMessage message)
    {
        Debug.Log(message);
        if (reverse)
        {
            rotX = ((1-message.GetFloat(0)) * 360)+rotOffset;
        }
        else
        {
            rotX = (message.GetFloat(0) * 360) + rotOffset;
        }


    }
}
