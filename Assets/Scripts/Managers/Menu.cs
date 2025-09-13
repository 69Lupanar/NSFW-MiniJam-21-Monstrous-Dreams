using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private AudioClip _bgm;
    [SerializeField] private GameObject _quitBtn;

    void Start()
    {
#if !UNITY_EDITOR_WIN && !UNITY_STANDALONE_WIN
        _quitBtn.SetActive(false);
#endif
        if (!AudioManager.Instance.IsPlaying(_bgm))
        {
            AudioManager.Instance.StopAll();
            AudioManager.Instance.PlayIfNotPlaying(_bgm);
        }
    }

    public void OnStartBtnClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnQuitBtnClick()
    {
        Application.Quit();
    }
}
