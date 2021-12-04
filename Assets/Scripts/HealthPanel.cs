using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPanel : MonoBehaviour
{
    private GameObject player;
    private Stats stats;
    public Sprite[] sprites = new Sprite[6];

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        stats = player.GetComponent<Stats>();
    }

    private void Update()
    {
        GetComponent<Image>().sprite = sprites[stats.health];
    }
}
