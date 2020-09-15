using UnityEngine;

namespace EquipObjects
{
    [CreateAssetMenu(menuName = "Configs/ObjectConfig", fileName = "ObjectConfig")]
    public class ObjectConfigs : ScriptableObject
    {
        [SerializeField] private float weight;
        [SerializeField] private string title;
        [SerializeField] private ObjectTypes types;

        public float Weight => weight;
        public string Title => title;
        public ObjectTypes Type => types;
    }
    public enum ObjectTypes
    {
        FirstType,
        SecondType,
        ThirdType
    }
}