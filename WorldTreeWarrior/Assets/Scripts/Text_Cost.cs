using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text_Cost : MonoBehaviour
{
    TextMeshProUGUI textCost;

    // Start is called before the first frame update
    void Start()
    {
        textCost = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textCost.SetText(GameManager.gm.currentCost.ToString() + "/" + GameManager.gm.maxCost.ToString());
    }
}
