using UnityEngine;
using static IdPool;
using static ObjectConfigs;

[RequireComponent(typeof(Rigidbody), typeof(PickUp))]
public class ObjectBehaviour : MonoBehaviour
{
    [SerializeField] private ObjectConfigs configs;

    public ObjectTypes Type { get; private set; }
    public int ID { get; private set; }
    public ObjectConfigs GetConfigs => configs;
    
    private PickUp _pickUp;

    private void Start()
    {
        GetComponent<Rigidbody>().mass = configs.Weight;
        _pickUp = GetComponent<PickUp>();
        gameObject.name = configs.Title;
        Type = configs.Type;
        ID = GetNewId();
    }

    public void Put() => gameObject.SetActive(false);

    public void GetOut(GameObject picker)
    {
        gameObject.SetActive(true);
        _pickUp.Equip(picker);
    }
}
