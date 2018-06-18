using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Npc.Ally;
using Npc.Enemy;


public class CombatManager : MonoBehaviour
{
    public float lifeBar;
    int lifes = 3;
    float maxLife = 100;
    float minLife = 0;
    public Sprite[] Heart;
    public Image[] HeartsUI;
    Text textZombie;
    public Slider sliderLife;
    public Text textLife;
    float distZombie;
    Text zombie;
    GameObject player;
    public Text GameOver;

    private void Start()
    {
        lifeBar = maxLife;
        for (int i = 0; i< HeartsUI.Length; i++)
        {
            print(i);
            HeartsUI[i].sprite = Heart[1];
        }
       
    }

    void Damage(float damage)
    {
        lifeBar -= damage;
    }

    void LifeReguler()
    {
        if (lifeBar <= 0)
        {
            if (lifes < 0)
            {
                GameOver.gameObject.SetActive(true);
                Time.timeScale = 0.0f;
                return;
            }

            lifeBar = minLife;
            lifes = lifes - 1;
            lifeBar = maxLife;
            HeartsUI[lifes].sprite = Heart[0];
        }
    
        if (lifeBar > 99)
        {
            lifeBar = maxLife;
        }
        sliderLife.value = lifeBar;
        textLife.text = (int)lifeBar + "%";
    }

    private void Update()
    {
        LifeReguler();
        foreach (GameObject go in GameManager.npcList)
        {
            if (go.GetComponent<Player>())
            {
                player = go;
            }

            if (go.GetComponent<Zombie>())
            {
                distZombie = Vector3.Distance(player.transform.position, go.transform.position);
                if (distZombie < 5)
                {
                    if (distZombie < 2)
                    {
                        Damage(10*Time.deltaTime);
                    }
                }
            }
        }
    }
}
