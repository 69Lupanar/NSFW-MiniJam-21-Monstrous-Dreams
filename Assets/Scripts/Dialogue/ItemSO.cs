using UnityEngine;

/// <summary>
/// Repr�sente un objet collectable pouvant �tre affich� dans l'inventaire.
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
    /// L'ic�ne de l'objet
    /// </summary>
    [field: SerializeField]
    public Sprite Illustration { get; private set; }

}
