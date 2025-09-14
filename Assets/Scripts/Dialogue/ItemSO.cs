using UnityEngine;

/// <summary>
/// Représente un objet collectable pouvant être affiché dans l'inventaire.
/// </summary>
[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    /// <summary>
    /// Le nom de l'objet
    /// </summary>
    [field: SerializeField]
    public string ItemName { get; private set; }

    /// <summary>
    /// L'icône de l'objet
    /// </summary>
    [field: SerializeField]
    public Sprite Illustration { get; private set; }

}
