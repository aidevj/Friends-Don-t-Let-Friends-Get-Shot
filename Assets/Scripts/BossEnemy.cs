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
	
	public int shotpar = 0;
	GameObject[] player;
	
	// Use this for initialization
	void Start () {	
		patterns = GetComponent<EnemyPatterns>();
		EBM = GetComponent<EnemyBulletManager>();
		player = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		shotCtrl++;
		if (enemyLife == 0){
			Destroy(this.gameObject);
		}
		
		if(shotCtrl == 30){
			shotCtrl = 0;
			shotpar = Random.Range(0,3);

			if(shotpar == 0){
				EBM.scatterShot( BulletColor.Blue, player[Random.Range(0,1)].transform.position, 6);
			}else if( shotpar == 1){
			    EBM.circleShot(BulletColor.Red, 36);
			}else if(shotpar == 2){
			    EBM.WayShot(BulletColor.Blue, player[Random.Range(0,1)].transform.position, 3, 10);
			}else if(shotpar == 3){
				EBM.aimShot(BulletColor.Red, player[Random.Range(0,1)].transform.position);
			}
			
			/*			
			if(shotpar == 0){
				EBM.scatterShot((EnemyBulletManager.BulletColor)Random.Range(0,1), player[Random.Range(0,1)].transform.position, 6);
			}else if( shotpar == 1){
			    EBM.circleShot((EnemyBulletManager.BulletColor)Random.Range(0,1), 36);
			}else if(shotpar == 2){
			    EBM.WayShot((EnemyBulletManager.BulletColor)Random.Range(0,1), player[Random.Range(0,1)].transform.position, 3, 10);
			}else if(shotpar == 3){
				EBM.aimShot((EnemyBulletManager.BulletColor)Random.Range(0,1), player[Random.Range(0,1)].transform.position);
			}
			*/
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
