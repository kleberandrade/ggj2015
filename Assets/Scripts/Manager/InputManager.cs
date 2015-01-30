using UnityEngine;
using System.Collections;

public enum PlayerType
{
    Shaman = 0,
    Warrior
}

public enum PlayerId
{
    PlayerOne = 1,
    PlayerTwo
}

[AddComponentMenu("Scripts/Manager/InputManager")]
public class InputManager : MonoBehaviour 
{

    public PlayerType playerType;
    [Range(0f, 10.0f)]
    public int strength;
    private PlayerId playerId;

    void Start()
    {
        if (PlayerPrefs.HasKey(playerType.ToString()))
            playerId = (PlayerId)PlayerPrefs.GetInt(playerType.ToString());
        else
            playerId = (PlayerId)((int)playerType + 1);
    }

    void Update()
    {

    }

    public string GetAxis(string axis)
    {
        return string.Format("{0}{1}", axis, GetId());
    }

    public int GetId()
    {
        return (int)playerId;
    }

    public bool GetButtonDown(string name)
    {
        return true;
    }
}
