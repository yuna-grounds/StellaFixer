using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl_YN : MonoBehaviour
{
    public Transform inputpos;
    InputState inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = InputState.empty;
    }

    void Update()
    {
    }

    // �浹 ����
    private void OnTriggerEnter(Collider other)
    {
        OVRInput.SetControllerVibration(1f, 1f, OVRInput.Controller.RTouch);

        // �浹�� ��ü�� tag = "Nut", inventory = InputState.empty�� ��,
        if (other.gameObject.tag == "Nut" && inventory == InputState.empty)
        {
            other.transform.SetParent(inputpos);
            other.transform.position = inputpos.transform.position;
            inventory = InputState.full;
            OVRInput.SetControllerVibration(1f, 1f, OVRInput.Controller.RTouch);
        }
    }

    public enum InputState
    {
        empty,
        full,
    }
}
