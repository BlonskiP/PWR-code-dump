using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private string mouseXInputName, mouseYInputName;

    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform playerBody;
    public GameObject textMessage;
    public GameObject background;
    public Interactive focus;
    public Camera camera;
    private float xAxisClamp;
    private void Awake()
    {
        camera = GetComponent<Camera>();
        LockCursor();
        xAxisClamp = 0.0f;
        background.SetActive(false);
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    void Update()
    {
        CameraRotation();
        CheckInteractiveObjects();
        InteractWithTarget();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if(xAxisClamp>90.0f) {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if(xAxisClamp< -90.0f) 
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left* mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
    private void CheckInteractiveObjects()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit))
        {
            Interactive interactiveObject = hit.collider.GetComponent<Interactive>();
            if(interactiveObject != null && interactiveObject.InteractionRange>hit.distance)
            {
                SetTarget(interactiveObject);
                Debug.Log("New InteractiveTarget");
            }
           
                

        }
        if (focus != null)
        {
            float distance = Vector3.Distance(transform.position, focus.transform.position);
            if (focus.InteractionRange < distance)
            {
                focus.outOfRange(this);
                focus = null;
            };
        }

    }

    private void SetTarget(Interactive interactiveObject)
    {
        focus = interactiveObject;
    }
    public void InteractWithTarget()
    {
        if(Input.GetButtonDown("Interact"))
        {
            if(focus!=null)
            {
                focus.Interact(this);
            }
        }
    }
}
