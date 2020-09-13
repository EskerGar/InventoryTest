using UnityEngine;

public class Picker : MonoBehaviour
{
    private const float MaxRayDistance = 100f;
    
    private LayerMask _pickUpLayer;
    private bool _isEquipped;
    private PickUp _pickUp;
    
    private void Start()
    {
       _pickUpLayer = LayerMask.GetMask(LayerMask.LayerToName(8));
    }
    
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        ClickingOnObject();
        
    }

    private void ClickingOnObject()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out var hit, MaxRayDistance, _pickUpLayer)) return;
        
        if(_pickUp == null)
            _pickUp = hit.transform.GetComponent<PickUp>();
        
        if(!_isEquipped)
        {
            _pickUp.Equip(gameObject);
            _isEquipped = true;
        }
        else
        {
            _pickUp.Drop();
            _isEquipped = false;
            _pickUp = null;
        } 
    }
    
}