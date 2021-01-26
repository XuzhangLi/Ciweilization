using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    private Player player;

    private int energy;
    public int numOfEnergies = 6;

    public Image[] energies;
    public Sprite fullEnergy;
    public Sprite emptyEnergy;

    private void Start()
    {
        player = GetComponent<Player>();
        energy = player.moves;
    }
    void Update()
    {
        energy = player.moves;

        if (energy > numOfEnergies)
        {
            energy = numOfEnergies;
        }

        for (int i = 0; i < energies.Length; i++)
        {
            if (i < energy)
            {
                energies[i].sprite = fullEnergy;
            }
            else
            {
                energies[i].sprite = emptyEnergy;
            }


            if (i < numOfEnergies)
            {
                energies[i].enabled = true;
            }
            else
            {
                energies[i].enabled = false;
            }
        }
    }


    // Start is called before the first frame update

}
