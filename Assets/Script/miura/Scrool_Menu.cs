using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrool_Menu : MonoBehaviour
{
	private float first_touch_y;
	private float now_touch_y;
	private float difference_y;
	private float upperlimit = 0f;
	private float lowerlimit = 0f;
	
	//upperlimitはUIが移動できるy座標の最大上限,lowerlimitはUIが移動できるy座標の最大下限。
	//最大限界値を決めておかないとUIはいくらでも移動できてしまうため
	[SerializeField] private RectTransform select_rect = null;
	[SerializeField] private RectTransform canvas_select_rect = null;

    // Start is called before the first frame update
    void Start()
    {
		upperlimit = select_rect.localPosition.y + 5f;
		lowerlimit = select_rect.sizeDelta.y - canvas_select_rect.sizeDelta.y;
		Debug.Log("上限:" + upperlimit);
		Debug.Log("下限:" + lowerlimit);
		Debug.Log(select_rect.localPosition.y);
	}

	// Update is called once per frame
	void Update()
    {
		Flick();
	}

	void Flick()
	{
		//最初にInput.GetKeyDownでfirst_touch_yとしてY軸の座標を取得
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			first_touch_y = Input.mousePosition.y;
		}

		//タッチしている間はnowYとしてY軸を取得して、first_touch_yとの差分difference_yを出す。
		if (Input.GetKey(KeyCode.Mouse0))
		{
			now_touch_y = Input.mousePosition.y;
			//nowyとfirst_touch_yの差を出す。
			difference_y = now_touch_y - first_touch_y;
			//スライドの振り幅を減らす。
			difference_y /= 30f;
			Debug.Log(select_rect.localPosition.y);
		}

		//徐々にスクロールスピードを落としたいのでdifference_yがマイナスの時には1.5f足していく。
		if (difference_y < -3f)
		{
			difference_y += 1.5f;
		}

		//徐々にスクロールスピードを落としたいのでdifference_yがプラスの時には1.5f引いていく。
		if (difference_y > 3f)
		{
			difference_y -= 1.5f;
		}

		//少しでも指をスライドしたらかなり動いてしまうので、指移動分difference_yが小さい時には移動させない。
		if (difference_y < 3 && difference_y > -3f)
		{
			difference_y = 0;
		}

		//永遠に画面がスライドできてしまうので範囲内ならスクロールさせる。
		if (select_rect.localPosition.y > upperlimit && select_rect.localPosition.y < lowerlimit)
		{
			select_rect.localPosition += new Vector3(0, difference_y, 0);
		}

		//スワイプをして指を動かしている間、スライドを止めるためにfirst_touch_yをnow_touch_yに近づけてdifferecYを小さくする。
		if (first_touch_y < now_touch_y)
		{
			first_touch_y += 4f;
		}
		if (first_touch_y > now_touch_y)
		{
			first_touch_y -= 4f;
		}

		//画面がスライドして行き過ぎた分を自動で戻す。
		if (select_rect.localPosition.y < upperlimit)
		{
			difference_y = 0;
			select_rect.localPosition += new Vector3(0, 2f, 0);
		}

		if (select_rect.localPosition.y > lowerlimit)
		{
			difference_y = 0;
			select_rect.localPosition += new Vector3(0, -2f, 0);
		}
	}
}
