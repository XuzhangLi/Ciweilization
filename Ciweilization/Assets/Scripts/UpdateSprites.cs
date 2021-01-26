using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprites : MonoBehaviour
{

    public Sprite cardFace;
    public Sprite cardBack;
    private SpriteRenderer spriteRenderer;
    private Selectable selectable;
    private Ciweilization ciweilization;

    // Start is called before the first frame update
    void Start()
    {
        ciweilization = FindObjectOfType<Ciweilization>();

        List<string> deck1 = Ciweilization.GenerateDeck("1", 12);
        List<string> deck2 = Ciweilization.GenerateDeck("2", 9);
        List<string> deck3 = Ciweilization.GenerateDeck("3", 6);
        List<string> deck4 = Ciweilization.GenerateDeck("4", 3);
        List<string> deckHeroes = ciweilization.deckHeroesCopy;

        int i = 0;
        foreach (string card in deck1)
        {
            if (this.name == card)
            {
                cardFace = ciweilization.cardFaces1[i % 4];
                break;
            }
            i++;
        }

        i = 0;
        foreach (string card in deck2)
        {
            if (this.name == card)
            {
                cardFace = ciweilization.cardFaces2[i % 4];
                break;
            }
            i++;
        }

        i = 0;
        foreach (string card in deck3)
        {
            if (this.name == card)
            {
                cardFace = ciweilization.cardFaces3[i % 4];
                break;
            }
            i++;
        }

        i = 0;
        foreach (string card in deck4)
        {
            if (this.name == card)
            {
                cardFace = ciweilization.cardFaces4[i % 4];
                break;
            }
            i++;
        }

        i = 0;
        foreach (string card in deckHeroes)
        {
            if (this.name == card)
            {
                cardFace = ciweilization.cardFacesHeroes[i];
                break;
            }
            i++;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        selectable = GetComponent<Selectable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selectable.faceUp == true)
        {
            spriteRenderer.sprite = cardFace;
        }
        else
        {
            spriteRenderer.sprite = cardBack;
        }
    }
}
