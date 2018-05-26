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
    public enum BulletType
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
    /// <param name="bt">発射したい弾の色</param>
    /// <param name="target">ターゲット</param>
    public void aimBullet(BulletType bt, Vector3 target)
    {
        var direction =  target - transform.position;
        GameObject obj = null;
        switch (bt) {
            case BulletType.Red:
                obj = Instantiate(redBulletPref);
                break;
            case BulletType.Blue:
                obj = Instantiate(redBulletPref);
                break;
        }

        // 弾の方向を渡す
        obj.GetComponent<EnemyBullet>().initBullet(direction);
    }
}
