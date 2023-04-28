using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapControl_YN : MonoBehaviour
{
    public Transform grabpos;
    handState myhand;

    RaycastHit hits;
    LineRenderer lr;

    void Start()
    {
        myhand = handState.grabable;
        print("실행");
        lr = this.GetComponent<LineRenderer>();
    }

    void Update()
    {
        RayCheck();
    }
    void RayCheck()
    {
        print("광선 체크");
        if(Physics.Raycast(this.transform.position, this.transform.forward, out hits, 20f) == true)
        {
            print("광선 닿음");
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) == true)
            {
                print("트리거 누름");
                if (hits.transform.tag == "Nut" && myhand == handState.grabable)
                {
                    // 잡는 방법 설정 - 잡은 물체를 위치 시킬 좌표
                    hits.transform.SetParent(grabpos);
                    //잡았을 때 자식객체 물리 여부
                    hits.transform.GetComponent<Rigidbody>().isKinematic = true;
                    // 잡으면 상태 변경
                    myhand = handState.grabed;
                    print("상태 변경, 진동");
                    OVRInput.SetControllerVibration(1f, 1f, OVRInput.Controller.RTouch);
                }
            }
            else
            {
                if (myhand == handState.grabed)
                {
                    hits.transform.SetParent(null);
                }
                myhand = handState.grabable;
            }
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        print("충돌 인식");
        //부딪힌 객체 인식
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
        {
            print("트리거 누름");
            if (other.gameObject.tag == "Nut" && myhand == handState.grabable)
            {
                //잡을 수 있는 상태
                // 잡는 방법 설정 - 잡은 물체를 위치 시킬 좌표
                other.transform.SetParent(grabpos);
                //잡았을 때 자식객체 물리 여부
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                // 잡으면 상태 변경
                myhand = handState.grabed;
                print("상태 변경");
                OVRInput.SetControllerVibration(1f, 1f, OVRInput.Controller.RTouch);
            }
        }
        
    }*/
    public enum handState
    {
        grabable,
        grabed,
    }
}
