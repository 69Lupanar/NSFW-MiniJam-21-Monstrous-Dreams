using System;
using TMPro;
using UnityEngine;

/// <summary>
/// Décrit l'état du dialogue à un instant donné
/// (réplique affichée, illustration, choix, audio, etc...)
/// </summary>
[CreateAssetMenu(fileName = "DialogueStateSO", menuName = "Scriptable Objects/DialogueStateSO")]
public class DialogueStateSO : DialogueNode
{
    /// <summary>
    /// Le texte à afficher. Si vide, on ne change pas le texte actif.
    /// </summary>
    [field: SerializeField]
    public DialogueText[] Texts { get; private set; }

    /// <summary>
    /// L'illustration à afficher. Si vide, on ne change pas l'illustration active.
    /// </summary>
    [field: SerializeField]
    public Sprite Illustration { get; private set; }

    /// <summary>
    /// La musique à jouer. Si vide, on ne change pas la musique active.
    /// </summary>
    [field: SerializeField]
    public AudioClip Bgm { get; private set; }

    /// <summary>
    /// L'objet débloqué s'il y en a un
    /// </summary>
    [field: SerializeField]
    public ItemSO Item { get; private set; }

    /// <summary>
    /// Représente les choix suivant cet état.
    /// Mettre un seul choix pour représenter un dialogue linéaire.
    /// S'il n'y a aucun choix, le dialogue est terminé.
    /// </summary>
    [field: SerializeField]
    public DialogueBranch[] Branches { get; private set; }
}

/// <summary>
/// Représente un choix dans un dialogue.
/// Mettre un seul choix pour représenter un dialogue linéaire.
/// S'il n'y a aucun choix, le dialogue est terminé.
/// </summary>
[Serializable]
public class DialogueText
{
    /// <summary>
    /// Le texte du choix à afficher
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
/// Représente un choix dans un dialogue.
/// Mettre un seul choix pour représenter un dialogue linéaire.
/// S'il n'y a aucun choix, le dialogue est terminé.
/// </summary>
[Serializable]
public class DialogueBranch
{
    /// <summary>
    /// Le texte du choix à afficher
    /// </summary>
    [field: SerializeField]
    public string Text { get; private set; }

    /// <summary>
    /// Le prochain état à lire. S'il n'y en a aucun, le dialogue est terminé.
    /// </summary>
    [field: SerializeField]
    public DialogueNode Next { get; private set; }
}