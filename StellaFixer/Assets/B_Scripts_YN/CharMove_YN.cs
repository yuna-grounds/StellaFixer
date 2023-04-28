using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharMove_YN : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        // Thumbstick Left : 플레이어 이동
        Vector2 dir_L = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
        this.transform.Translate(Vector3.forward * Time.deltaTime * 3f * dir_L.y);

        // Tumbstick_Right : 플레이어 회전
        Vector2 dir_R = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
        this.transform.Rotate(Vector3.up * Time.deltaTime * 90f * dir_R.x);

    }
}
