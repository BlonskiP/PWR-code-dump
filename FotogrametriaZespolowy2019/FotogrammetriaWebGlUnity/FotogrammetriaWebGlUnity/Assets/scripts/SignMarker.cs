using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignMarker : Interactive
{
    public string information = "temp";
    protected override void Interaction(PlayerCameraController player)
    {
        if (!player.background.activeSelf)
        {
            player.background.SetActive(true);
            InputField message = player.textMessage.GetComponent<InputField>();
            message.lineType = InputField.LineType.MultiLineNewline;
            message.text = information;
           
        }
        else
            player.background.SetActive(false);
        
    }

    public override void outOfRange(PlayerCameraController player)
    {
        player.background.SetActive(false);

    }
}
