using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrool_Menu : MonoBehaviour
{
	// 制限を掛けたいオブジェクトのrecttransform
	[SerializeField] private RectTransform select_rect = null;
	// タッチの始点
	private float first_touch_y = 0f;
	// タッチの終点
	private float now_touch_y = 0f;
	// タッチの始点と終点の移動距離
	private float swing_dist_y = 0f;
	// 下にスワイプした時の移動限界
	private float max_limit = 0f;
	// 上にスワイプした時の移動限界
	private float min_limit = 0f;
	// スワイプした時の移動距離を小さくする為の変数
	private float swing_width = 10f;
	// スワイプ受付最大移動距離
	private float swing_dist_max = 3f;
	// スワイプ受付最小移動距離
	private float swing_dist_min = -3f;

	// Start is called before the first frame update
	void Start()
    {
		max_limit = select_rect.sizeDelta.y;
		min_limit = select_rect.localPosition.y;

		Debug.Log(select_rect.localPosition.y);
		Debug.Log(select_rect.sizeDelta.y);
	}

	// Update is called once per frame
	void Update()
    {
		Flick();
	}

	void Flick()
	{
		// 最初にInput.GetKeyDownでfirst_touch_yとしてY軸の座標を取得
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			first_touch_y = Input.mousePosition.y;
		}

		// タッチしている間はnowYとしてY軸を取得して、first_touch_yとの差分swing_dist_yを出す。
		if (Input.GetKey(KeyCode.Mouse0))
		{
			now_touch_y = Input.mousePosition.y;
			// nowyとfirst_touch_yの差を出す。
			swing_dist_y = now_touch_y - first_touch_y;
			// スライドの振り幅を減らす。
			swing_dist_y /= swing_width;
		}

		// 徐々にスクロールスピードを落としたいのでswing_dist_yがマイナスの時には1.5f足していく。
		if (swing_dist_y < swing_dist_min)
		{
			swing_dist_y += 1.5f;
		}

		// 徐々にスクロールスピードを落としたいのでswing_dist_yがプラスの時には1.5f引いていく。
		if (swing_dist_y > swing_dist_max)
		{
			swing_dist_y -= 1.5f;
		}

		// 少しでも指をスライドしたらかなり動いてしまうので、指移動分swing_dist_yが小さい時には移動させない。
		if (swing_dist_y < swing_dist_max && swing_dist_y > swing_dist_min)
		{
			swing_dist_y = 0;
		}

		// 永遠に画面がスライドできてしまうので範囲内ならスクロールさせる。
		if (select_rect.localPosition.y <= max_limit && select_rect.localPosition.y >= min_limit)
		{
			select_rect.localPosition += new Vector3(0, swing_dist_y, 0);
		}

		// スワイプをして指を動かしている間、スライドを止めるためにfirst_touch_yをnow_touch_yに近づけてdifferecYを小さくする。
		if (first_touch_y < now_touch_y)
		{
			first_touch_y += 4f;
		}
		if (first_touch_y > now_touch_y)
		{
			first_touch_y -= 4f;
		}

		// 画面がスライドして行き過ぎた分を自動で戻す。
		if (select_rect.localPosition.y >= max_limit)
		{
			swing_dist_y = 0;
			select_rect.localPosition = new Vector3(select_rect.localPosition.x, max_limit, select_rect.localPosition.z);
		}

		if (select_rect.localPosition.y <= min_limit)
		{
			swing_dist_y = 0;
			select_rect.localPosition = new Vector3(select_rect.localPosition.x, min_limit, select_rect.localPosition.z);
		}
	}
}
