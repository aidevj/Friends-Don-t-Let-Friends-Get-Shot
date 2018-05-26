using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	public float speed = 10f;

	void Start () {}

	void Update () {
		// 上に向かって動く
		transform.Translate(0, speed * Time.deltaTime, 0);
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}

	// 玉は敵と衝突すれば、敵のスクリプトに玉を壊せます
	// Destroy the bullet in the enemy class when it collides with the enemy
}
