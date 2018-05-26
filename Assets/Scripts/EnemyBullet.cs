using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EnemyBulletクラス
/// </summary>
public class EnemyBullet : MonoBehaviour
{
    /// <summary>
    /// 速さ
    /// </summary>
    float speed = 1.0f;

    /// <summary>
    /// 弾の向き
    /// </summary>
    Vector3 direction = Vector2.down;

    void Start()
    {

    }

    void Update()
    {
        // 移動
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // プレイヤーの弾が「赤」で自分が「青」
        if (other.gameObject.tag == "Player_RedBullet" && gameObject.tag == "Enemy_BlueBullet") {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        // プレイヤーの弾が「青」で自分が「赤」
        else if (other.gameObject.tag == "Player_BlueBullet" && gameObject.tag == "Enemy_RedBullet") {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    // ----------------------------------------------------------------------------------------------------------
    // public関数
    // ----------------------------------------------------------------------------------------------------------
    /// <summary>
    /// 弾の初期化
    /// </summary>
    /// <param name="_direction">発射方向</param>
    public void initBullet(Vector2 _direction)
    {
        direction = _direction;
    }
}
