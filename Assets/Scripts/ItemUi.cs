using UnityEngine;
using UnityEngine.UI;

public class ItemUi : MonoBehaviour
{
    [SerializeField] private Text title;
    [SerializeField] private Text weight;
    [SerializeField] private Text id;
    [SerializeField] private Text type;

    public int ItemNumber { get; set; }

    private void Start()
    {
        CleanInfo();
    }

    public void ShowItem(ObjectConfigs configs, int newId)
    {
        SetInfo(
            configs.Title, 
            configs.Weight.ToString(), 
            "ID: " + newId, 
            configs.Type.ToString());
    }

    public void CleanInfo() => SetInfo(default, default, default, default);

    private void SetInfo(string title_, string weight_, string id_, string type_)
    {
        title.text = title_;
        weight.text = weight_;
        id.text = id_;
        type.text = type_;
    }
    
}
