using System.Collections.Generic;
using UnityEngine;

public class BackPackUi : MonoBehaviour
{ 
    [SerializeField] private BackPack backPack;
    [SerializeField] private List<ItemUi> itemUis;

    private Camera _camera;
    private LayerMask _itemLayer;
    
    private void Start()
    {
        _camera = Camera.main;
        _itemLayer = LayerMask.GetMask(LayerMask.LayerToName(9));
        gameObject.SetActive(false);
        backPack.OnInventoryOpen += OpenInventory;
        backPack.OnInventoryClose += CloseInventory;
        SetItemNumbers();
    }

    private void SetItemNumbers()
    {
        for (var i = 0; i < itemUis.Count; i++)
        {
            itemUis[i].ItemNumber = i;
        }
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
        var itemNumber = GetSpotItem();
        if (itemNumber != -1)
        {
            backPack.GetOutOfBackPack(itemNumber);
            CleanItemInfo(itemNumber);
        }
        gameObject.SetActive(false);
    }

    private void CleanItemInfo(int itemNumber) => itemUis[itemNumber].CleanInfo();

    private int GetSpotItem()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out var hit, 5f, _itemLayer)) return -1;
        return  hit.transform.GetComponent<ItemUi>().ItemNumber;
    }

    private void OnDestroy()
    {
        backPack.OnInventoryOpen -= OpenInventory;
        backPack.OnInventoryClose -= CloseInventory;
    }
}