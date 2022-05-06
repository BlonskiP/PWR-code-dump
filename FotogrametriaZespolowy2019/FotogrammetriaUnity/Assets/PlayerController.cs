using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    string cameraX = "X";
    string cameraY = "Y";

    string forward = "Horizontal";
    string vertical = "Vertical";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float playerForward = Input.GetAxis(forward);
        float playerHorizontal = Input.GetAxis(vertical);

        transform.Translate(playerForward, 0, playerHorizontal);

        Vector3 cameraRot = transform.rotation.eulerAngles;
        cameraRot.x -= Input.GetAxis(cameraY);
        cameraRot.z = 0;
        cameraRot.y += Input.GetAxis(cameraX);

        transform.rotation = Quaternion.Euler(cameraRot);
    }
}
