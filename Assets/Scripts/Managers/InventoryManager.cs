using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gère les objets de la scène
/// </summary>
public class InventoryManager : MonoBehaviour
{
    public ReadOnlyCollection<ItemSO> Items
    {
        get => _items.AsReadOnly();
    }

    /// <summary>
    /// Le parent inactif du texte
    /// </summary>
    [field: SerializeField]
    private Transform ItemsParent { get; set; }

    /// <summary>
    /// La liste des objets de l'inventaire
    /// </summary>
    private List<ItemSO> _items;

    private void Start()
    {
        _items = new List<ItemSO>();
        ClearItemContainer();
        SetItemsIcons(Items);
    }

    private void ClearItemContainer()
    {
        foreach (Transform child in ItemsParent)
        {
            Image icon = child.GetChild(1).GetComponent<Image>();
            icon.sprite = null;
            icon.color = Color.clear;
        }
    }

    private void SetItemsIcons(ReadOnlyCollection<ItemSO> items)
    {
        for (int i = 0; i < items.Count; ++i)
        {
            ItemSO item = items[i];
            Image icon = ItemsParent.GetChild(i).GetChild(1).GetComponent<Image>();
            icon.sprite = item.Illustration;
            icon.color = Color.white;
        }
    }

    internal void Add(ItemSO item)
    {
        if (!_items.Contains(item))
        {
            _items.Add(item);
            ClearItemContainer();
            SetItemsIcons(Items);
        }
    }
}
