using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleInteractiveObject : Interactive
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interaction(PlayerCameraController player)
    {
        Debug.Log("Object Interacted");
        Renderer rend = GetComponent<Renderer>();
        if (rend.material.color == Color.red)
        {
            rend.material.SetColor("_Color", Color.white);
        }else
        rend.material.SetColor("_Color", Color.red);
    }

    public override void outOfRange(PlayerCameraController player)
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.white);
    }
}
