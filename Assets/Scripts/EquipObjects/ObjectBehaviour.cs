using UnityEngine;
using static EquipObjects.IdPool;

namespace EquipObjects
{
    [RequireComponent(typeof(Rigidbody))]
    public class ObjectBehaviour : MonoBehaviour
    {
        [SerializeField] private ObjectConfigs configs;

        public ObjectTypes Type { get; private set; }
        public int ID { get; private set; }
        public ObjectConfigs GetConfigs => configs;
    
        private Rigidbody _rigidbody;
        private Collider _collider;
        private Transform _transform;
        private MeshRenderer _meshRenderer;

        private const int PickUpLayer = 8;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _meshRenderer = GetComponent<MeshRenderer>();
            _rigidbody.mass = configs.Weight;
            _collider = GetComponent<Collider>();
            _transform = transform;
            gameObject.name = configs.Title;
            Type = configs.Type;
            ID = GetNewId();
        }

        public void Put() 
        {
            StopSpeed();
            gameObject.layer = default;
        }

        public void GetOut(Vector3 newPosition)
        {
            _meshRenderer.enabled = true;
            gameObject.layer = PickUpLayer;
            gameObject.transform.position = newPosition;
            Drop();
        }
    
        public void Equip(GameObject picker)
        {
            StopSpeed();
            _transform.parent = picker.transform;
            _transform.position = picker.transform.position;
        }

        public void Drop()
        {
            _rigidbody.useGravity = true;
            _collider.isTrigger = false;
            _transform.parent = null;
        }

        private void StopSpeed()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero; 
            _rigidbody.useGravity = false;
            _collider.isTrigger = true;
        }
    }
}
