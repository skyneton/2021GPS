using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthPoint : MonoBehaviour
{
	private Text hpText;
	private float playerHP;
	private Player player;
    // Start is called before the first frame update
    void Start()
    {
		hpText = GetComponent<Text>();
        player = FindObjectOfType<Player>();
		playerHP = player.getHP();
        hpText.text = "HP : " + (Mathf.Floor(player.getHP() * 100) / 100);
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "HP : " + (Mathf.Floor(player.getHP() * 100) / 100);
    }
}
