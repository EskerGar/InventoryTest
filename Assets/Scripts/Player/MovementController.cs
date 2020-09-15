using UnityEngine;

namespace Player
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float speed = 4;
    
        private Rigidbody _rigidbody;
        private const float FloorLevel = 3f;
    
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Move();

        }
    
        private void Move()
        {
            var playerPosition = transform.position;
            _rigidbody.velocity = transform.forward * (speed * Input.GetAxis("Vertical")) + transform.right * (speed * Input.GetAxis("Horizontal"));
            transform.position = new Vector3(playerPosition.x, FloorLevel, playerPosition.z);
        }
    }
}
