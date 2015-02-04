using UnityEngine;
using System.Collections;

public enum PlayerType
{
    Kimaro = 1,
    Yeti
}

public enum PlayerControl
{
    PlayerOne = 1,
    PlayerTwo
}

[AddComponentMenu("Scripts/Manager/PlayerInput")]
public class PlayerInput : MonoBehaviour 
{
    public PlayerType playerType;

    private PlayerControl playerControl;

    [Range(0f, 10.0f)]
    public int strength;

    void Awake()
    {
        if (PlayerPrefs.HasKey(playerType.ToString()))
            playerControl = (PlayerControl)PlayerPrefs.GetInt(playerType.ToString());
        else
            playerControl = (PlayerControl)((int)playerType);
    }

    public int GetControlNumber
    {
        get 
        {
            return (int)playerControl;
        }
    }
}
