using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages scene loading & transitions between scenes
/// </summary>
public class SceneFader : MonoBehaviour
{
    #region Variables 

    /// <summary>
    /// The gradient colors used for transitions
    /// </summary>
    public Gradient FadeInGradient => this._fadeInGradient;
    public Gradient FadeOutGradient => this._fadeOutGradient;

    /// <summary>
    /// The image used for transitions
    /// </summary>
    [SerializeField] private Image _fadeImg;

    /// <summary>
    /// The gradient colors used for transitions
    /// </summary>
    [SerializeField] private Gradient _fadeInGradient, _fadeOutGradient;

    #endregion

    #region Unity

    private void Start()
    {
        FadeIn(1f, _fadeInGradient);
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Makes the scene appear slowly
    /// </summary>
    public void FadeIn(float fadeDuration, Gradient colorGradient)
    {
        _fadeImg.DOGradientColor(colorGradient, fadeDuration);
        _fadeImg.color = new Color(_fadeImg.color.r, _fadeImg.color.g, _fadeImg.color.b, 1f);
        _fadeImg.DOFade(0f, fadeDuration);
    }

    /// <summary>
    /// Makes the scene disappear slowly
    /// </summary>
    public void FadeOut(float fadeDuration, Gradient colorGradient, Action onFadeCompleteCallback)
    {
        _fadeImg.DOGradientColor(colorGradient, fadeDuration).OnComplete(() => onFadeCompleteCallback?.Invoke());
        _fadeImg.color = new Color(_fadeImg.color.r, _fadeImg.color.g, _fadeImg.color.b, 0f);
        _fadeImg.DOFade(1f, fadeDuration);
    }

    #endregion
}
