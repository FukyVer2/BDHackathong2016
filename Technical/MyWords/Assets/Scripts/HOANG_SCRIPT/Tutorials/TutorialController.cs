using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TutorialController : MonoBehaviour {
	
	public const string hoithoai1 ="Đây là {0} gì nhỉ?";
	public const string hoithoai2 ="Cùng đoán tên của {0} này nào!!";
	public const string hoithoai3 ="Đưa hình ảnh của kí tự vào nhé!";

	public string[] listNameOfCategory;
	public Text txtHoiThoai;
	public GameObject tut;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	[ContextMenu("ShowText")]
	public void ShowText(int categoryID, int step)
	{
		CancelInvoke ();
		tut.SetActive (true);
		string ht = "";
		if (step == 1) {
			ht = String.Format (hoithoai1, listNameOfCategory [categoryID]);
		} else if (step == 2) {
			ht = String.Format (hoithoai2, listNameOfCategory [categoryID]);
		} else {
			ht = hoithoai3;
		}
		//string ht = String.Format (hoithoai1, "vật");
		txtHoiThoai.text = ht;
		Invoke ("HideTutorial", 10.0f);
	}

	public void HideTutorial()
	{
		tut.SetActive (false);
	}
}
