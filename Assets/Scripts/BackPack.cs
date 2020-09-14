using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class BackPack : MonoBehaviour
{
    [SerializeField] private UnityEvent onPut;
    [SerializeField] private UnityEvent onGetOut;
    
    private const int InventoryAmount = 3;
    private readonly ObjectBehaviour[] _inventory = new ObjectBehaviour[InventoryAmount];
    
    
    public ObjectBehaviour GetOutOfBackPack(int placeNumber)
    {
        if (placeNumber >= _inventory.Length) return null;
        var obj = _inventory[placeNumber];
        if(obj != null)
            onGetOut?.Invoke();
        return obj;
    }

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
