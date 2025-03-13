using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ButtonSelect : MonoBehaviour
{   
    public int buttonIndex;
    public string buttonModel;
    public void buttonSelected()
    {
        PlayerPrefs.SetString("PlayerModel",buttonModel);
        print(PlayerPrefs.GetString("PlayerModel"));
    }
}