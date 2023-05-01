using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Teleport_YN : MonoBehaviour
{
    RaycastHit hits;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        DoorTeleport();
    }

    public void DoorTeleport()
    {

        //������ ����� ��
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hits, 20f) == true)
        {
            //Ʈ���� ��ư�� �����ٸ�
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) == true &&
                hits.transform.CompareTag("Door"))
            {
                SceneManager.LoadScene("2_SpaceScene_YN");
                OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
            }

        }

    }
}
