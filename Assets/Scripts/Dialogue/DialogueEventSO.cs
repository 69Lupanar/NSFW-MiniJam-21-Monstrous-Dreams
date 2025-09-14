using UnityEngine;

/// <summary>
/// Représente un signal envoyé au GameManager
/// pour indique que le joueur a atteint un certain point de progression
/// </summary>
[CreateAssetMenu(fileName = "DialogueEventSO", menuName = "Scriptable Objects/DialogueEventSO")]
public class DialogueEventSO : DialogueNode
{
    /// <summary>
    /// Les tags de l'événement. S'il n'y en a aucun, on lève une erreur.
    /// </summary>
    [field: SerializeField]
    public string[] Tags { get; private set; }

    /// <summary>
    /// Le prochain état à lire. S'il n'y en a aucun, on lève une erreur.
    /// </summary>
    [field: SerializeField]
    public DialogueNode Next { get; private set; }
}
