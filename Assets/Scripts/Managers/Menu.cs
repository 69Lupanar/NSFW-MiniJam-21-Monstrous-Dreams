using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private AudioClip _bgm;
    [SerializeField] private GameObject _quitBtn;
    [SerializeField] private SceneFader _sceneFader;

    void Start()
    {
#if !UNITY_EDITOR && !UNITY_STANDALONE
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
        _sceneFader.FadeOut(1f, _sceneFader.FadeOutGradient, () => SceneManager.LoadScene("GameScene"));
    }

    public void OnQuitBtnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
