using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _icon;

    public string Name => _name.text;

    public ItemView(string name, Image icon)
    {
        _name.text = name;
        _icon = icon;
    }
}
