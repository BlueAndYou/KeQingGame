using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PropUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI propNumberText;
    [SerializeField]
    private Prop prop;

    private Button button;

    private void Start()
    {
        propNumberText.text = prop.GetNumber().ToString();
        button = GetComponent<Button>();
        button.onClick.AddListener(SelectedProp);
        prop.OnPropUse += Prop_OnPropUse;
    }

    private void Prop_OnPropUse(object sender, System.EventArgs e)
    {
        UpdateNumber();
    }

    public void UpdateNumber() 
    {
        propNumberText.text = prop.GetNumber().ToString();
    }
    public void SelectedProp() 
    {
        PropContentUI.Instance.Show();
        PropContentUI.Instance.UpdateContent(prop);
    }
}
