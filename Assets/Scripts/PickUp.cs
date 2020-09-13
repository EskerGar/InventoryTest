using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Collider _collider;
    private Transform _transform;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _transform = transform;
    }

    public void Equip(GameObject picker)
    { 
        _rigidbody.useGravity = false;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _collider.isTrigger = true;
        _transform.parent = picker.transform;
        _transform.position = picker.transform.position;
    }

    public void Drop()
    {
        _rigidbody.useGravity = true;
        _collider.isTrigger = false;
        _transform.parent = null;
    }
}
