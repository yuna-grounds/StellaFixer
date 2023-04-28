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

    // 충돌 감지
    private void OnTriggerEnter(Collider other)
    {
        OVRInput.SetControllerVibration(1f, 1f, OVRInput.Controller.RTouch);

        // 충돌된 물체가 tag = "Nut", inventory = InputState.empty일 때,
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
