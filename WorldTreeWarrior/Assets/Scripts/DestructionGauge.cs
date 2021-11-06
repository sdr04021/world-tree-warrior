using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestructionGauge : MonoBehaviour
{
    Image currentGauge;

    // Start is called before the first frame update
    void Start()
    {
        currentGauge = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        currentGauge.fillAmount = (float)GameManager.gm.destructionGauge / 100;
    }
}
