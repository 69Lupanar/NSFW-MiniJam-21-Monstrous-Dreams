using UnityEngine;

/// <summary>
/// Start of the game
/// </summary>
public class GameStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.Instance.StopAll();
    }
}
