using UnityEngine;

/// <summary>
/// Représente une condition dans le dialogue
/// (objets récupérés, événement débloqué, etc...)
/// </summary>
[CreateAssetMenu(fileName = "DialogueConditionSO", menuName = "Scriptable Objects/DialogueConditionSO")]
public class DialogueConditionSO : DialogueNode
{
    /// <summary>
    /// Les tags de la condition. S'il n'y en a aucun, on lève une erreur.
    /// </summary>
    [field: SerializeField]
    public string[] Tags { get; private set; }

    /// <summary>
    /// Le prochain état à lire. Si la condition est fausse, le dialogue par défaut est joué. S'il n'y en a aucun, on lève une erreur.
    /// </summary>
    [field: SerializeField]
    public DialogueNode Next { get; private set; }

    /// <summary>
    /// L'état par défaut à lire si la condition est fausse. S'il n'y en a aucun, on lève une erreur.
    /// </summary>
    [field: SerializeField]
    public DialogueNode Default { get; private set; }
}