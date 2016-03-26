using UnityEngine;
using System.Collections;
using System;
using System.Text;

[System.Serializable]
public class BaseWord
{
    public int categoryID; //Thong so chi ID cua parent
    public int wordID; //Thong so chi ID cua Child
    public string wordContent; //Thong so chi noi dung cua word
    public string wordPhoto; //Thong so chi duong dan anh cua word
	public string wordSound; // Ten am thanh cua tu
	public int countChar;	// so ki tu cua tu
	public float timeFinish; // thoi gian it nhat hoan thanh tu nay.
	public int countFinish; // so lan hoan thanh tu nay finish
	public int countLose; // so lan that bai tu nay

	public string ConvertToString()
	{
		//StringBuilder builder = new StringBuilder ();
		return String.Format ("{0}\t{1}\t{2}\t {3}\t{4}\t{5}\t{6}\t{7}", wordID, categoryID,
		                      wordContent, wordPhoto, wordSound, countChar, countFinish, countLose).ToString ();
	}
}
