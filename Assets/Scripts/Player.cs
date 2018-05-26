using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤークラス
/// </summary>
public class Player : MonoBehaviour {
	private GameManager GM;			// GameManagerオブジェクトをアクセスするため
	public GameObject playerBulletPrefab;
		
	public int playerNumber;		// 0: P1 (青) ; 1: P2 (赤)
	public float speed = .5f;

	private string controlAxisX;
	private string controlAxisY;

	private bool controllerEnabled = true;

	public int HP = 3;


	// Property
	public bool ControllerEnabled {
		get { return controllerEnabled; }
		set { controllerEnabled = value; }
	}

	void Start () {
		GM = GameObject.Find ("GameManager").GetComponent<GameManager> ();

		//コントロールをロードする
		switch (playerNumber) {
			case 0:
				controlAxisX = "Horizontal_P1";
				controlAxisY = "Vertical_P1";
				break;
			case 1:
				controlAxisX = "Horizontal_P2";
				controlAxisY = "Vertical_P2";
				break;
		}
	}

	void Update () {
		if (controllerEnabled) Move ();
	}

	// コントロールで動く
	void Move() {
		//　行動コントロール
		transform.Translate (Input.GetAxis (controlAxisX) * speed, Input.GetAxis (controlAxisY), 0);

		// 攻撃コントロール
		switch (playerNumber) {
		case 0 :
			if (Input.GetKeyDown(KeyCode.LeftShift)) FireBullet();
			break;
		case 1:
			if (Input.GetKeyDown(KeyCode.RightShift)) FireBullet();
			break;
		}

	}

	// 玉を撃つ
	void FireBullet() {
		// GMに玉の量を減る
		if (GM.ammo <= 0) {
			Debug.Log ("玉が足りない");
		} else {
			GM.ammo--;
		}
		// プレイヤーの玉プリファブの生成

		Debug.Log ("撃ている");
	}

	// トリガーとの衝突
	void OnTriggerEnter2D(Collider2D other) {
		//　敵、 敵の玉と
		if (other.tag == "Enemy") {
			HP--;
		}

		// 玉と
		switch (playerNumber) {
		case 0:
			if (other.tag == "Enemy_BlueBullet")
				// ＨＰ減る
			if (other.tag == "Enemy_RedBullet")
				// 弾丸壊す
			break;
		case 1:
			if (other.tag == "Enemy_RedBullet")
				// ＨＰ減る
			if (other.tag == "Enemy_BlueBullet")
				// 弾丸壊す
			break;
		}
	}

	// HPチェック
	public bool IsDead(){
		return (HP <= 0) ? true : false;
	}



}
