using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<CardDisplay> cards = new List<CardDisplay>();
    public Transform canvas;
    public Transform[] transforms;

    private void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            int randomCard = Random.Range(0, cards.Count);
            Instantiate(cards[randomCard], transforms[i].position , Quaternion.identity , canvas);
        }
    }
}
