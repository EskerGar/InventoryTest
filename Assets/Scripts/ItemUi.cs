﻿using UnityEngine;
using UnityEngine.UI;

public class ItemUi : MonoBehaviour
{
    [SerializeField] private Text title;
    [SerializeField] private Text weight;
    [SerializeField] private Text id;
    [SerializeField] private Text type;

    private void Start()
    {
        title.text = default;
        weight.text = default;
        id.text = default;
        type.text = default;
    }

    public void ShowItem(ObjectConfigs configs, int newId)
    {
        title.text = configs.Title;
        weight.text = configs.Weight.ToString();
        id.text = "ID: " + newId;
        type.text = configs.Type.ToString();
    }
}