using UnityEngine;

/// <summary>
/// Repr�sente un signal envoy� au GameManager
/// pour indique que le joueur a atteint un certain point de progression
/// </summary>
[CreateAssetMenu(fileName = "DialogueEventSO", menuName = "Scriptable Objects/DialogueEventSO")]
public class DialogueEventSO : DialogueNode
{
    /// <summary>
    /// Les tags de l'�v�nement. S'il n'y en a aucun, on l�ve une erreur.
    /// </summary>
    [field: SerializeField]
    public string[] Tags { get; private set; }

    /// <summary>
    /// Le prochain �tat � lire. S'il n'y en a aucun, on l�ve une erreur.
    /// </summary>
    [field: SerializeField]
    public DialogueNode Next { get; private set; }
}
