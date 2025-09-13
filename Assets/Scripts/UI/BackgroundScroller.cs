using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Fait d�filer l'arri�re-plan
/// </summary>
public class BackgroundScroller : MonoBehaviour
{
    /// <summary>
    /// L'image
    /// </summary>
    [SerializeField] private RawImage _img;

    /// <summary>
    /// 
    /// La vitesse de d�filement
    /// </summary>
    [SerializeField] private Vector2 _speedXY = Vector2.one;

    void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + _speedXY * Time.deltaTime, _img.uvRect.size);
    }
}
