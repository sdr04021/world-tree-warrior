using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTurnEnd : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(turnEndClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void turnEndClick()
    {
 
    }
}
