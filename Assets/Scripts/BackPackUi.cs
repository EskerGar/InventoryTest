using System.Collections.Generic;
using UnityEngine;

public class BackPackUi : MonoBehaviour
{ 
    [SerializeField] private BackPack backPack;
    [SerializeField] private List<ItemUi> itemUis;

    private void Start()
    {
        gameObject.SetActive(false);
        backPack.OnInventoryOpen += OpenInventory;
        backPack.OnInventoryClose += CloseInventory;
    }

    private void OpenInventory(ObjectBehaviour[] inventory)
    {
        Cursor.lockState = CursorLockMode.Confined;
        gameObject.SetActive(true);
        for (var i = 0; i < inventory.Length; i++)
        {
            var obj = inventory[i];
            if (obj == null) continue;
            var configs = obj.GetConfigs;
            itemUis[i].ShowItem(configs, obj.ID);
        }
    }

    private void CloseInventory()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        backPack.OnInventoryOpen -= OpenInventory;
        backPack.OnInventoryClose -= CloseInventory;
    }
}