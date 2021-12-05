using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPanel : MonoBehaviour
{
    private GameObject player;
    private hero health;
    public Sprite[] sprites = new Sprite[6];

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        health = player.GetComponent<hero>();
    }

    private void Update()
    {
        GetComponent<Image>().sprite = sprites[health.health];
    }
}
