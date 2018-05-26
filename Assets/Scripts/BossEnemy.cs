using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour {

	EnemyPatterns patterns;
	public int rnd_max = 3;
	public int rnd_min = 0;
	public int state = 0;
	public float diff = 0.3f;

	// Use this for initialization
	void Start () {
		patterns = GetComponent<EnemyPatterns>();
	}
	
	// Update is called once per frame
	void Update () {
		
		patterns.movePatterns(state);
		if (patterns.target.x-diff < transform.position.x && patterns.target.y-diff < transform.position.y
			&& patterns.target.x+diff > transform.position.x && patterns.target.y+diff > transform.position.y){
			
			state = Random.Range(0,3);			
		}
			
	}
}
