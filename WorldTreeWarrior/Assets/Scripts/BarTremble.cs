using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarTremble : MonoBehaviour
{
    Vector2 initialPos;

    Transform DGaugeCurrent;
    Vector2 DGaugeCurrentPos;
    Transform DGaugeText;
    Vector2 DGaugeTextPos;
    Transform Icon2;
    Vector2 Icon2Pos;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.localPosition;
        DGaugeCurrent = GameObject.Find("DGauge_Current").GetComponent<Transform>();
        DGaugeCurrentPos = DGaugeCurrent.transform.localPosition;
        DGaugeText = GameObject.Find("DGaugeText").GetComponent<Transform>();
        DGaugeTextPos = DGaugeText.transform.localPosition;
        Icon2 = GameObject.Find("icon2").GetComponent<Transform>();
        Icon2Pos = Icon2.transform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.hpBarTremble)
        {
            Vector2 randC = Random.insideUnitCircle * 20.0f;
            transform.localPosition = initialPos + randC;
            DGaugeCurrent.localPosition = DGaugeCurrentPos + randC;
            DGaugeText.localPosition = DGaugeTextPos + randC;
            Icon2.localPosition = Icon2Pos + randC;
        }
        else
        {
            transform.localPosition = initialPos;
            DGaugeCurrent.localPosition = DGaugeCurrentPos;
            DGaugeText.localPosition = DGaugeTextPos;
            Icon2.localPosition = Icon2Pos;
        }
    }
}
