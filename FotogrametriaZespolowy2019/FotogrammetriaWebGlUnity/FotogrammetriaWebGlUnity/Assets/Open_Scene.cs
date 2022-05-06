using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Open_Scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void open_Comarch()
    {
        Debug.Log("Opening Comarch Scene");
        SceneManager.LoadScene("Assets/Scenes/ComarchScene.Unity", LoadSceneMode.Single);
    }

    public void open_Lidl()
    {
        Debug.Log("Opening Lidl Scene");
        SceneManager.LoadScene("Assets/Scenes/LidlScene.Unity", LoadSceneMode.Single);
    }

    public void open_Blok()
    {
        Debug.Log("Opening Blok Scene");
        SceneManager.LoadScene("Assets/Scenes/BlokScene.Unity", LoadSceneMode.Single);
    }

    public void open_Pomnik()
    {
        Debug.Log("Opening Pomnik Scene");
        SceneManager.LoadScene("Assets/Scenes/PomnikScene.Unity", LoadSceneMode.Single);
    }

}
