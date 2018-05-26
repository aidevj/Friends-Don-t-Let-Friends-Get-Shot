using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneUI : MonoBehaviour
{
    [SerializeField]
    GameObject hpSlider;

    BossEnemy boss;

    void Start()
    {
        boss = GameObject.FindWithTag("Enemy").GetComponent<BossEnemy>();
        hpSlider.GetComponent<Slider>().maxValue = boss.enemyLife;
    }

    void Update()
    {
        hpSlider.GetComponent<Slider>().value = boss.enemyLife;
    }
}
