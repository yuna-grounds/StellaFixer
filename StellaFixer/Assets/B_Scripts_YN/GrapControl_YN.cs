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
        print("����");
        lr = this.GetComponent<LineRenderer>();
    }

    void Update()
    {
        RayCheck();
    }
    void RayCheck()
    {
        print("���� üũ");
        if(Physics.Raycast(this.transform.position, this.transform.forward, out hits, 20f) == true)
        {
            print("���� ����");
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) == true)
            {
                print("Ʈ���� ����");
                if (hits.transform.tag == "Nut" && myhand == handState.grabable)
                {
                    // ��� ��� ���� - ���� ��ü�� ��ġ ��ų ��ǥ
                    hits.transform.SetParent(grabpos);
                    //����� �� �ڽİ�ü ���� ����
                    hits.transform.GetComponent<Rigidbody>().isKinematic = true;
                    // ������ ���� ����
                    myhand = handState.grabed;
                    print("���� ����, ����");
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
        print("�浹 �ν�");
        //�ε��� ��ü �ν�
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
        {
            print("Ʈ���� ����");
            if (other.gameObject.tag == "Nut" && myhand == handState.grabable)
            {
                //���� �� �ִ� ����
                // ��� ��� ���� - ���� ��ü�� ��ġ ��ų ��ǥ
                other.transform.SetParent(grabpos);
                //����� �� �ڽİ�ü ���� ����
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                // ������ ���� ����
                myhand = handState.grabed;
                print("���� ����");
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