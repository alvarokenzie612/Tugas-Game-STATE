using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    // Item Data
    public string itemName;
    public int itemQuantity;
    public Sprite itemIcon;
    public bool isFull;

    // Item Slot
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;
    [SerializeField] private int MaxStackSize = 99;

    //slot management
    [SerializeField] public GameObject selectedPanel;

    public bool isItemSelected;
    public InventoryManager inventoryManager;

    public void Start()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
    }
    
    
   public void AddItem(ItemDetails item)
    {
        itemName = item.ItemName;
        //itemQuantity = item.Quantity;
        itemIcon = item.ItemIcon;
        isFull = true;
        AddQuantity(item.Quantity);

        // quantityText.text = itemQuantity.ToString();
        // quantityText.enabled = true;
        // itemImage.sprite = itemIcon;
    }

    public bool CanStackWith(string otherItemName)
    {
        return !isFull && itemName == otherItemName;
    }

    public void AddQuantity(int amount)
    {
        itemQuantity += amount;
        isFull = itemQuantity >= MaxStackSize;

        quantityText.text = itemQuantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemIcon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            RightClick();
        }

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            LeftClick();
        }
    }

    public void RightClick()
    {
        Debug.Log("Right Clicked on item: " + itemName);
        
    }

    public void LeftClick()
    {
        inventoryManager.DeselectAllSlots();
        selectedPanel.SetActive(true);
        isItemSelected = true;
        Debug.Log("Left Clicked on item: " + itemName);
    }

}
