using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;
    public Transform itemsParent;
     Inventory inventory;
    public GameObject inventoryUI;
    public Button closeInventory;

    InventorySlot[] slots;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance found! ;)");
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }
    private void Start()
    {
        inventory = Inventory.instance;
        inventory.OnItemChangedCallback += UpdateUI;
        
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        Button btn = closeInventory.GetComponent<Button>();
        btn.onClick.AddListener(Toggle);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
        
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");
        for(int i=0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);

            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    public void Toggle()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
}
