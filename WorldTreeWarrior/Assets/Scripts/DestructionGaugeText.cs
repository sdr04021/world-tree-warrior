using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestructionGaugeText : MonoBehaviour
{
    TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.SetText(GameManager.gm.destructionGauge.ToString() + "/" + "100");
    }
}
