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

    void Start()
    {
        //aimShot(BulletColor.Red, Vector2.down);
        //WayShot(BulletColor.Red, Vector2.down, 4);
        scatterShot(BulletColor.Red, Vector2.up, 20);
    }

    void Update()
    {
        
    }

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
        var obj       = createBullet(bc);
        
        // 弾の方向を渡す
        obj.GetComponent<EnemyBullet>().initBullet(direction.normalized);
    }

    /// <summary>
    /// 多方向弾
    /// </summary>
    /// <param name="bc">弾の色</param>
    /// <param name="target">ターゲット</param>
    /// <param name="wayNum">発射数</param>
    /// <param name="changeAngle">隣の弾との角度差</param>
    public void WayShot(BulletColor bc, Vector3 target, int wayNum = 3, int changeAngle = 10)
    {
        var direction  = target - transform.position;
        var baseAngle  = Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
        var startAngle = 0.0f;

        // 偶数の時
        if (wayNum % 2 == 0) {
            startAngle = baseAngle + wayNum / 2 * changeAngle - changeAngle / 2;
        }
        // 奇数の時
        else {
            startAngle = baseAngle + wayNum / 2 * changeAngle;
        }

        // changeAngle度ずつwayNum数発射
        for (int i = 0; i < wayNum; ++i, startAngle -= changeAngle) {
            float x = Mathf.Cos(startAngle * Mathf.PI / 180.0f);
            float y = Mathf.Sin(startAngle * Mathf.PI / 180.0f);
            var obj = createBullet(bc);
            obj.GetComponent<EnemyBullet>().initBullet(new Vector2(x, y).normalized);
        }
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

    /// <summary>
    /// ばらまき弾
    /// </summary>
    /// <param name="bc">弾の色</param>
    /// <param name="target">ターゲット</param>
    /// <param name="shotNum">発射数</param>
    public void scatterShot(BulletColor bc, Vector3 target, int shotNum)
    {
        var direction = target - transform.position;
        var baseAngle = Mathf.Atan2(direction.y, direction.x);

        StartCoroutine(scatterCoroutine(bc, shotNum, baseAngle));
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
                return Instantiate(redBulletPref, transform);
            case BulletColor.Blue:
                return Instantiate(blueBulletPref, transform);
            default:
                return null;
        }
    }

    /// <summary>
    /// ばらまき弾
    /// </summary>
    /// <param name="bc"></param>
    /// <param name="shotNum"></param>
    /// <param name="baseAngle"></param>
    /// <returns></returns>
    IEnumerator scatterCoroutine(BulletColor bc, int shotNum, float baseAngle)
    {
        for (int i = 0; i < shotNum; ++i) {
            var angle = baseAngle + Random.Range(0.0f, 1500.0f) / 1000.0f - 0.75f;
            var x = Mathf.Cos(angle);
            var y = Mathf.Sin(angle);
            var obj = createBullet(bc);
            obj.GetComponent<EnemyBullet>().initBullet(new Vector2(x, y).normalized);
            yield return new WaitForSeconds(0.1f);
        }

    }
}
