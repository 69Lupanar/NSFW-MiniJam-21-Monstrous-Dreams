using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Start of the game
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Variables Unity

    /// <summary>
    /// La node de départ
    /// </summary>
    [field: SerializeField]
    private DialogueNode StartNode { get; set; }

    /// <summary>
    /// La prefab du texte
    /// </summary>
    [field: SerializeField]
    private GameObject DialogueTextPrefab { get; set; }

    /// <summary>
    /// La prefab du bouton
    /// </summary>
    [field: SerializeField]
    private GameObject DialogueBtnPrefab { get; set; }

    /// <summary>
    /// Son de ramassage d'objet
    /// </summary>
    [field: SerializeField]
    private AudioClip ItemPickupAudioClip { get; set; }

    /// <summary>
    /// Le SceneFader
    /// </summary>
    [field: SerializeField]
    private SceneFader _sceneFader { get; set; }

    /// <summary>
    /// L'inventaire
    /// </summary>
    [field: SerializeField]
    private InventoryManager InventoryManager { get; set; }

    /// <summary>
    /// Le parent actif du texte
    /// </summary>
    [field: SerializeField]
    private Transform ActiveDialogueTextParent { get; set; }

    /// <summary>
    /// Le parent inactif du texte
    /// </summary>
    [field: SerializeField]
    private Transform InactiveDialogueTextParent { get; set; }

    /// <summary>
    /// Le parent actif du texte
    /// </summary>
    [field: SerializeField]
    private Transform ActiveDialogueChoiceParent { get; set; }

    /// <summary>
    /// Le parent inactif du texte
    /// </summary>
    [field: SerializeField]
    private Transform InactiveDialogueChoiceParent { get; set; }

    /// <summary>
    /// L'image contenant l'illustration
    /// </summary>
    [field: SerializeField]
    private Image IllustrationImg { get; set; }

    /// <summary>
    /// Les tags des événements déclenchés au cours de la partie
    /// </summary>
    private List<string> _eventTags;

    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _eventTags = new List<string>();

        if (StartNode != null)
        {
            EvaluateNode(StartNode);
        }
    }

    /// <summary>
    /// Détermine le type de la node
    /// et exécute la fonction appropriée
    /// </summary>
    /// <param name="node">La node</param>
    private void EvaluateNode(DialogueNode node)
    {
        switch (node)
        {
            case DialogueStateSO state:
                EvaluateState(state);
                break;

            case DialogueConditionSO condition:
                EvaluateCondition(condition);
                break;

            case DialogueEventSO @event:
                EvaluateEvent(@event);
                break;
        }
    }

    #region DialogueState

    /// <summary>
    /// Evalue la node
    /// </summary>
    /// <param name="state">La node</param>
    private void EvaluateState(DialogueStateSO state)
    {
        if (state.Texts != null && state.Texts.Length > 0)
        {
            ClearTextContainer();
            AddToTextContainer(state.Texts);
        }

        if (state.Illustration != null)
        {
            IllustrationImg.sprite = state.Illustration;
        }

        if (state.Bgm != null && !AudioManager.Instance.IsPlaying(state.Bgm))
        {
            AudioManager.Instance.StopAll();
            AudioManager.Instance.Play(state.Bgm);
        }

        if (state.SFX != null)
        {
            AudioManager.Instance.PlayIfNotPlaying(state.SFX);
        }

        if (state.Item != null)
        {
            InventoryManager.Add(state.Item);
            AudioManager.Instance.Play(ItemPickupAudioClip);
        }

        ClearBranchContainer();
        AddToBranchContainer(state.Branches);
    }

    private void ClearTextContainer()
    {
        while (ActiveDialogueTextParent.childCount > 0)
        {
            Transform first = ActiveDialogueTextParent.GetChild(0);
            first.SetParent(InactiveDialogueTextParent);
        }
    }

    private void AddToTextContainer(DialogueText[] texts)
    {
        foreach (DialogueText text in texts)
        {
            Transform child;

            if (InactiveDialogueTextParent.childCount > 0)
            {
                child = InactiveDialogueTextParent.GetChild(0);
                child.SetParent(ActiveDialogueTextParent);
            }
            else
            {
                child = Instantiate(DialogueTextPrefab, ActiveDialogueTextParent).transform;
            }

            TextMeshProUGUI tmp = child.GetComponent<TextMeshProUGUI>();
            tmp.alignment = text.TextAlignment;
            tmp.text = text.Text;
            tmp.SetVerticesDirty();
        }
    }

    private void ClearBranchContainer()
    {
        while (ActiveDialogueChoiceParent.childCount > 0)
        {
            Transform first = ActiveDialogueChoiceParent.GetChild(0);
            first.SetParent(InactiveDialogueChoiceParent);
            first.GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

    private void AddToBranchContainer(DialogueBranch[] branches)
    {
        if (branches != null && branches.Length > 0)
        {
            // Si on a des branches, on crée un bouton de choix pour chacun

            foreach (DialogueBranch branch in branches)
            {
                Transform child;

                if (InactiveDialogueChoiceParent.childCount > 0)
                {
                    child = InactiveDialogueChoiceParent.GetChild(0);
                    child.SetParent(ActiveDialogueChoiceParent);
                }
                else
                {
                    child = Instantiate(DialogueBtnPrefab, ActiveDialogueChoiceParent).transform;
                }

                TextMeshProUGUI tmp = child.GetComponent<TextMeshProUGUI>();
                Button btn = child.GetComponent<Button>();

                void OnClick()
                {
                    EvaluateNode(branch.Next);
                }

                tmp.text = branch.Text;
                btn.onClick.AddListener(OnClick);
            }
        }
        else
        {
            // S'il n'y a aucun choix, on crée un bouton pour revenir au menu
            Transform child;

            if (InactiveDialogueChoiceParent.childCount > 0)
            {
                child = InactiveDialogueChoiceParent.GetChild(0);
                child.SetParent(ActiveDialogueChoiceParent);
            }
            else
            {
                child = Instantiate(DialogueBtnPrefab, ActiveDialogueChoiceParent).transform;
            }

            TextMeshProUGUI tmp = child.GetComponent<TextMeshProUGUI>();
            Button btn = child.GetComponent<Button>();

            void OnClick()
            {
                _sceneFader.FadeOut(1f, _sceneFader.FadeOutGradient, () => SceneManager.LoadScene("MenuScene"));
            }

            tmp.text = "- Return to Menu";
            btn.onClick.AddListener(OnClick);
        }
    }

    #endregion

    #region DialogueCondition

    /// <summary>
    /// Evalue la node
    /// </summary>
    /// <param name="condition">La node</param>
    private void EvaluateCondition(DialogueConditionSO condition)
    {
        if (condition.Tags == null ^ condition.Tags.Length == 0)
        {
            print($"Erreur : Aucune condition n'est assignée dans le DialogueConditionSO \"{condition.name}\".");
            return;
        }

        if (condition.Next == null)
        {
            print($"Erreur : Aucun dialogue suivant n'est assigné dans le DialogueConditionSO \"{condition.name}\".");
            return;
        }

        if (condition.Default == null)
        {
            print($"Erreur : Aucun dialogue par défaut n'est assigné dans le DialogueConditionSO \"{condition.name}\".");
            return;
        }

        if (AllConditionsAreTrue(condition.Tags))
        {
            EvaluateNode(condition.Next);
        }
        else
        {
            EvaluateNode(condition.Default);
        }

    }

    private bool AllConditionsAreTrue(string[] tags)
    {
        for (int i = 0; i < tags.Length; ++i)
        {
            if (!_eventTags.Contains(tags[i]))
            {
                return false;
            }
        }

        return true;
    }

    #endregion

    #region DialogueEvent

    /// <summary>
    /// Evalue la node
    /// </summary>
    /// <param name="@event">La node</param>
    private void EvaluateEvent(DialogueEventSO @event)
    {
        if (@event.Tags == null ^ @event.Tags.Length == 0)
        {
            print($"Erreur : Aucun tag n'est assigné dans le DialogueEventSO \"{@event.name}\".");
            return;
        }

        if (@event.Next == null)
        {
            print($"Erreur : Aucun dialogue suivant n'est assigné dans le DialogueEventSO \"{@event.name}\".");
            return;
        }

        for (int i = 0; i < @event.Tags.Length; ++i)
        {
            if (!_eventTags.Contains(@event.Tags[i]))
            {
                _eventTags.Add(@event.Tags[i]);
            }
        }

        EvaluateNode(@event.Next);
    }

    #endregion
}
