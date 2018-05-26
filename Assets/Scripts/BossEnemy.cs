using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Bossを制御するクラス
/// </summary>
public class BossEnemy : MonoBehaviour {

	EnemyPatterns patterns;
	EnemyBulletManager EBM;
	public int rnd_max = 3;
	public int rnd_min = 0;
	public int state = 0;
	public float diff = 0.3f;
	public int shotCtrl = 0;
	
	public int LifeMax = 10;

	public int enemyLife = 10;
	GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
	
	// Use this for initialization
	void Start () {	
		patterns = GetComponent<EnemyPatterns>();
		EBM = GetComponent<EnemyBulletManager>();
	}
	
	// Update is called once per frame
	void Update () {
		shotCtrl++;
		if (enemyLife == 0){
			Destroy(this.gameObject);
		}
		
		if(shotCtrl == 30){
			shotCtrl = 0;
			if(enemyLife < LifeMax * 0.3 ){
				EBM.scatterShot((EnemyBulletManager.BulletColor)Random.Range(0,1), player[Random.Range(0,1)].transform.position, 6);
			}else if(enemyLife < LifeMax * 0.5 ){
			    EBM.circleShot((EnemyBulletManager.BulletColor)Random.Range(0,1), 36);
			}else if(enemyLife < LifeMax * 0.8 ){
			    EBM.WayShot((EnemyBulletManager.BulletColor)Random.Range(0,1), player[Random.Range(0,1)].transform.position, 3, 10);
			}else{
				EBM.aimShot((EnemyBulletManager.BulletColor)Random.Range(0,1), player[Random.Range(0,1)].transform.position);
			}
		}
		
		patterns.movePatterns(state);
		if (patterns.target.x-diff < transform.position.x && patterns.target.y-diff < transform.position.y
			&& patterns.target.x+diff > transform.position.x && patterns.target.y+diff > transform.position.y){
			
			state = Random.Range(0,3);			
		}
			
	}
	
	void OnTriggerEnter2D (Collider2D bullet){
		// delete bullet
		if (bullet.gameObject.tag == "Player_BlueBullet" || bullet.gameObject.tag == "Player_RedBullet"){
			Destroy(bullet.gameObject);
			// life -1
			enemyLife--;
		}
	}	
}
