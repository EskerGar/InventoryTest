using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class BackPack : MonoBehaviour
{
    [Serializable]
    private class GetOutEvent : UnityEvent<ObjectBehaviour> {}

    [SerializeField] private UnityEvent onPut;
    [SerializeField] private GetOutEvent onGetOut;
    
    public event Action<ObjectBehaviour[]> OnInventoryOpen;
    public event Action OnInventoryClose;
    
    private const int InventoryAmount = 3;
    private readonly ObjectBehaviour[] _inventory = new ObjectBehaviour[InventoryAmount];
    
    
    public void GetOutOfBackPack(int placeNumber)
    {
        if (placeNumber >= _inventory.Length) return;
        var obj = _inventory[placeNumber];
        _inventory[placeNumber] = null;
        if(obj == null) return;
        var randomPosition = Random.insideUnitCircle * 3;
        obj.GetComponent<ObjectBehaviour>().GetOut(transform.position + new Vector3(randomPosition.x, 0f, randomPosition.y));
        onGetOut?.Invoke(obj);
    }

    private void OpenInventory() => OnInventoryOpen?.Invoke(_inventory);

    private void CloseInventory() => OnInventoryClose?.Invoke();

    private void PutInBackPack(ObjectBehaviour obj, int count)
    {
        _inventory[count] = obj;
        onPut?.Invoke();
    }

    private void OnCollisionEnter(Collision other)
    {
        var objectBehaviour = other.transform.GetComponent<ObjectBehaviour>();
        if (objectBehaviour == null) return;
        var count = FindEmptySlot();
        if (count == -1 || CheckSameObject(objectBehaviour)) return;
        objectBehaviour.Put();
        PutInBackPack(objectBehaviour, count);

    }

    private void OnMouseDown() => OpenInventory();

    private void OnMouseUp() => CloseInventory();

    private int FindEmptySlot()
    {
        for (var i = 0; i < _inventory.Length; i++)
        {
            if (_inventory[i] == default)
                return i;
        }

        return -1;
    }

    private bool CheckSameObject(ObjectBehaviour newObj)
    {
        return _inventory.Any(obj => obj != null && newObj.Type.Equals(obj.Type));
    }
}
