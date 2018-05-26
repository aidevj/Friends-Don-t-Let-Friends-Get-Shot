using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EnemyBulletを管理するクラス
/// </summary>
public class EnemyBulletManager : MonoBehaviour
{
    /// <summary>
    /// 敵の弾の種類
    /// </summary>
    public enum BulletColor
    {
        Red = 0,
        Blue,
    }

    /// <summary>
    /// 赤弾のPrefab
    /// </summary>
    [SerializeField]
    GameObject redBulletPref;

    /// <summary>
    /// 赤弾のPrefab
    /// </summary>
    [SerializeField]
    GameObject blueBulletPref;


    // ----------------------------------------------------------------------------------------------------------
    // public関数
    // ----------------------------------------------------------------------------------------------------------

    /// <summary>
    /// targetに向けて弾を発射
    /// </summary>
    /// <param name="bc">発射したい弾の色</param>
    /// <param name="target">ターゲット</param>
    public void aimShot(BulletColor bc, Vector3 target)
    {
        var direction =  target - transform.position;
        GameObject obj = createBullet(bc);
        
        // 弾の方向を渡す
        obj.GetComponent<EnemyBullet>().initBullet(direction.normalized);
    }

    /// <summary>
    /// 円形に弾を発射
    /// </summary>
    /// <param name="bc">弾の色</param>
    /// <param name="partitions">分割数</param>
    public void circleShot(BulletColor bc, int partitions = 18)
    {
        for (int i = 0; i < partitions; ++i) {
            float rot = 360.0f / partitions * i;
            float x = Mathf.Cos(rot * Mathf.PI / 180.0f);
            float y = Mathf.Sin(rot * Mathf.PI / 180.0f);
            var obj = createBullet(bc);
            obj.GetComponent<EnemyBullet>().initBullet(new Vector2(x, y).normalized);
        }
    }

    // ----------------------------------------------------------------------------------------------------------
    // private関数
    // ----------------------------------------------------------------------------------------------------------

    /// <summary>
    /// 引数で指定された色の弾を生成
    /// </summary>
    /// <param name="bc">弾の色</param>
    /// <returns>生成された弾</returns>
    GameObject createBullet(BulletColor bc)
    {
        switch (bc) {
            case BulletColor.Red:
                return Instantiate(redBulletPref);
            case BulletColor.Blue:
                return Instantiate(blueBulletPref);
            default:
                return null;
        }
    }
}
