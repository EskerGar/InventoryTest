using UnityEngine;

public class Picker : MonoBehaviour
{
    private const float MaxRayDistance = 100f;
    
    private LayerMask _pickUpLayer;
    private ObjectBehaviour _objectBehaviour;
    
    private void Start()
    {
       _pickUpLayer = LayerMask.GetMask(LayerMask.LayerToName(8));
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            EquipObject();
        else if (Input.GetMouseButtonUp(0))
            DropObject();
        
        
    }

    private void DropObject()
    {
        if (_objectBehaviour == null) return;
        _objectBehaviour.Drop();
        _objectBehaviour = null;
    }

    private void EquipObject()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out var hit, MaxRayDistance, _pickUpLayer)) return;
        
        if(_objectBehaviour == null)
            _objectBehaviour = hit.transform.GetComponent<ObjectBehaviour>();
        
        _objectBehaviour.Equip(gameObject);
    }

}