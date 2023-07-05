using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<CardDisplay> cards = new List<CardDisplay>();
    public Transform canvas;
    public Transform[] transforms;
    public List<CardDisplay> currentCards = new List<CardDisplay>();

    private void Start()
    {
        //for (int i = 0; i < 7; i++)
        //{
        //    int randomCard = Random.Range(0, cards.Count);
        //   currentCards.Add(Instantiate(cards[randomCard], transforms[i].position , Quaternion.identity , canvas));
        //}
    }

    public void NewGame()
    {
        foreach (var item in currentCards)
        {
            Destroy(item.gameObject);
        }
        currentCards.Clear();

        for (int i = 0; i < 7; i++)
        {
            int randomCard = Random.Range(0, cards.Count);
            currentCards.Add(Instantiate(cards[randomCard], transforms[i].position, Quaternion.identity, canvas));
        }
    }

    public void LoadCards(List<string> idList)
    {
        foreach (var item in currentCards)
        {
            Destroy(item.gameObject);
        }
        currentCards.Clear();

        for (int i = 0; i < idList.Count; i++)
        {
            foreach (var card in cards)
            {
                if (card.card.ID == idList[i])
                {
                    currentCards.Add(Instantiate(card, transforms[i].position, Quaternion.identity, canvas));
                }
            }
        }
    }

}
