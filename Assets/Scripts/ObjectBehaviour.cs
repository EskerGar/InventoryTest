using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    [SerializeField] private ObjectConfigs configs;

    private ObjectConfigs.ObjectTypes _type;

    private void Start()
    {
        GetComponent<Rigidbody>().mass = configs.Weight;
        gameObject.name = configs.Title;
        _type = configs.Type;
    }
}
