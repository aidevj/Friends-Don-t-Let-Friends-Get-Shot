using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour {

	EnemyPatterns patterns;
	public int rnd_max = 3;
	public int rnd_min = 0;
	public int state = 0;
	public float diff = 0.3f;
	public int shotCtrl = 0;
	
	public int enemyLife = 2;

	// Use this for initialization
	void Start () {
		patterns = GetComponent<EnemyPatterns>();
	}
	
	// Update is called once per frame
	void Update () {
		shotCtrl++;
		if (enemyLife == 0){
			Destroy(this.gameObject);
		}
		
		if(shotCtrl == 100){
			//shot();
			shotCtrl = 0;
		}
		
		patterns.movePatterns(state);
		if (patterns.target.x-diff < transform.position.x && patterns.target.y-diff < transform.position.y
			&& patterns.target.x+diff > transform.position.x && patterns.target.y+diff > transform.position.y){
			
			state = Random.Range(0,3);			
		}
			
	}
	
	void OnTriggerEnter2D (Collider2D c){
		// delete bullet
		Destroy(c.gameObject);

		// life -1
		enemyLife--;
	}	
}
