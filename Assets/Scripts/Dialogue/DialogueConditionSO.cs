using UnityEngine;

/// <summary>
/// Repr�sente une condition dans le dialogue
/// (objets r�cup�r�s, �v�nement d�bloqu�, etc...)
/// </summary>
[CreateAssetMenu(fileName = "DialogueConditionSO", menuName = "Scriptable Objects/DialogueConditionSO")]
public class DialogueConditionSO : DialogueNode
{
    /// <summary>
    /// Les tags de la condition. S'il n'y en a aucun, on l�ve une erreur.
    /// </summary>
    [field: SerializeField]
    public string[] Tags { get; private set; }

    /// <summary>
    /// Le prochain �tat � lire. Si la condition est fausse, le dialogue par d�faut est jou�. S'il n'y en a aucun, on l�ve une erreur.
    /// </summary>
    [field: SerializeField]
    public DialogueNode Next { get; private set; }

    /// <summary>
    /// L'�tat par d�faut � lire si la condition est fausse. S'il n'y en a aucun, on l�ve une erreur.
    /// </summary>
    [field: SerializeField]
    public DialogueNode Default { get; private set; }
}