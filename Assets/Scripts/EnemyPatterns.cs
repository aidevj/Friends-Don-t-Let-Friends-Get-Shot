using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyPatterns : MonoBehaviour {

	public Vector2 target = new Vector2(0,0);	
	public Vector2 v = new Vector2();
	public float time = 1.0f;
	public Vector2 velocity;

	// Use this for initialization
	void Start () {
//		superenemy = GetComponent<superEnemy>();
	}
	
	public void movePatterns(int state){
		// move right-up
		if(state == 0){
			target.x = 3;
			target.y = 3;
			transform.position = Vector2.SmoothDamp(transform.position,target,ref velocity,time,100,Time.deltaTime);
		}
		// move left-up
		if(state == 1){
			target.x = -3;
			target.y = 3;
			transform.position = Vector2.SmoothDamp(transform.position,target,ref velocity,time,100,Time.deltaTime);
		}
		// move left-down
		if(state == 2){
			target.x = -3;
			target.y = -3;
			transform.position = Vector2.SmoothDamp(transform.position,target,ref velocity,time,100,Time.deltaTime);
		}
		// move right-down
		if(state == 3){
			target.x = 3;
			target.y = -3;
			transform.position = Vector2.SmoothDamp(transform.position,target,ref velocity,time,100,Time.deltaTime);
		}
	}
}
