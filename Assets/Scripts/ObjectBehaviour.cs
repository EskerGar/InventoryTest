using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(PickUp))]
public class ObjectBehaviour : MonoBehaviour
{
    [SerializeField] private ObjectConfigs configs;

    public ObjectConfigs.ObjectTypes Type { get; private set; }
    private PickUp _pickUp;
    

    private void Start()
    {
        GetComponent<Rigidbody>().mass = configs.Weight;
        _pickUp = GetComponent<PickUp>();
        gameObject.name = configs.Title;
        Type = configs.Type;
    }

    public void Put() => gameObject.SetActive(false);

    public void GetOut(GameObject picker)
    {
        gameObject.SetActive(true);
        _pickUp.Equip(picker);
    }
}
