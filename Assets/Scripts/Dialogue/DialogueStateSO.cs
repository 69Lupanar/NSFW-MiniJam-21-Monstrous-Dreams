using System;
using TMPro;
using UnityEngine;

/// <summary>
/// D�crit l'�tat du dialogue � un instant donn�
/// (r�plique affich�e, illustration, choix, audio, etc...)
/// </summary>
[CreateAssetMenu(fileName = "DialogueStateSO", menuName = "Scriptable Objects/DialogueStateSO")]
public class DialogueStateSO : DialogueNode
{
    /// <summary>
    /// Le texte � afficher. Si vide, on ne change pas le texte actif.
    /// </summary>
    [field: SerializeField]
    public DialogueText[] Texts { get; private set; }

    /// <summary>
    /// L'illustration � afficher. Si vide, on ne change pas l'illustration active.
    /// </summary>
    [field: SerializeField]
    public Sprite Illustration { get; private set; }

    /// <summary>
    /// La musique � jouer. Si vide, on ne change pas la musique active.
    /// </summary>
    [field: SerializeField]
    public AudioClip Bgm { get; private set; }

    /// <summary>
    /// L'objet d�bloqu� s'il y en a un
    /// </summary>
    [field: SerializeField]
    public ItemSO Item { get; private set; }

    /// <summary>
    /// Repr�sente les choix suivant cet �tat.
    /// Mettre un seul choix pour repr�senter un dialogue lin�aire.
    /// S'il n'y a aucun choix, le dialogue est termin�.
    /// </summary>
    [field: SerializeField]
    public DialogueBranch[] Branches { get; private set; }
}

/// <summary>
/// Repr�sente un choix dans un dialogue.
/// Mettre un seul choix pour repr�senter un dialogue lin�aire.
/// S'il n'y a aucun choix, le dialogue est termin�.
/// </summary>
[Serializable]
public class DialogueText
{
    /// <summary>
    /// Le texte du choix � afficher
    /// </summary>
    [field: SerializeField, TextArea(3, 100)]
    public string Text { get; private set; }

    /// <summary>
    /// L'alignement du texte
    /// </summary>
    [field: SerializeField]
    public TextAlignmentOptions TextAlignment { get; private set; }
}

/// <summary>
/// Repr�sente un choix dans un dialogue.
/// Mettre un seul choix pour repr�senter un dialogue lin�aire.
/// S'il n'y a aucun choix, le dialogue est termin�.
/// </summary>
[Serializable]
public class DialogueBranch
{
    /// <summary>
    /// Le texte du choix � afficher
    /// </summary>
    [field: SerializeField]
    public string Text { get; private set; }

    /// <summary>
    /// Le prochain �tat � lire. S'il n'y en a aucun, le dialogue est termin�.
    /// </summary>
    [field: SerializeField]
    public DialogueNode Next { get; private set; }
}