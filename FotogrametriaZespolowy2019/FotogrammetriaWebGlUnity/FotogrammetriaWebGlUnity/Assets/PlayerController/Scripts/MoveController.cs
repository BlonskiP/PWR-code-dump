using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveController : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;

    private CharacterController charController;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerExit();
    }
    private void PlayerMovement()
    {
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed * Time.deltaTime;
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed * Time.deltaTime;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);

    }

    private void PlayerExit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Opening Menu from player");
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Assets/Scenes/Menu.Unity", LoadSceneMode.Single);
        }
    }
}
