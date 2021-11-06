using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public int destructionGauge = 100;
    public int maxDestructionGauge = 100;
    public int maxCost = 20;
    public int currentCost = 20;

    List<int> resurrectionDeck = new List<int>();
    int resurrectionUsed;
    List<int> corruptionDeck = new List<int>();
    int corruptionUsed;

    List<int> myResurrection = new List<int>();
    List<int> myCorruption = new List<int>();

    private void Awake()
    {
        gm = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeDeckLIst(resurrectionDeck, ref resurrectionUsed);
        InitializeDeckLIst(corruptionDeck, ref corruptionUsed);

        PickCard(resurrectionDeck, myResurrection, ref resurrectionUsed);
        PickCard(resurrectionDeck, myResurrection, ref resurrectionUsed);
        PickCard(corruptionDeck, myCorruption, ref corruptionUsed);
        PickCard(corruptionDeck, myCorruption, ref corruptionUsed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitializeDeckLIst(List<int> deck, ref int used)
    {
        deck.Clear();
        for (int i = 0; i < 10; i++)
            deck.Add(i);
        used = 0;
    }

    void PickCard(List<int> deck, List<int> myCards, ref int used)
    {
        int pick = Random.Range(0, 10 - used);
        myCards.Add(deck[pick]);
        deck[pick] = deck[9 - used];
        used++;
    }

    
}
