using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの残機表示
/// </summary>
public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField]
    List<GameObject> healthImage = new List<GameObject>();

    /// <summary>
    /// ダメージを受けた際の関数
    /// </summary>
    /// <param name="hp"></param>
    public void OnDamage(int hp)
    {
        healthImage[hp].SetActive(false);
    }
}
