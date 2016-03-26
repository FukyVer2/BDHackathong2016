using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class FileLoader {

    public static List<List<string>> LoadDataFromFile(string _assetPath)
    {
        List<List<string>> _fileData = new List<List<string>>();
        TextAsset textAsset = (TextAsset)Resources.Load(_assetPath, typeof(TextAsset));

		//Resources.
        if (textAsset) {
#if UNITY_EDITOR
			Debug.Log ("Text Asset = " + textAsset.text);
#endif
			string[] temp = textAsset.text.Split ('\n');
			List<string> _objectData;
			for (int i = 1; i < temp.Length; i++) {
				string[] context = temp [i].Split ('\t');//\t
				//_objectData = null;
				_objectData = new List<string> (context);
				if (_objectData != null) {
					_fileData.Add (_objectData);
				}
			}

		} else {
#if UNITY_EDITOR
			Debug.Log("Can't load data");
#endif
		}
        return _fileData;
    }

	public static void WriteDataToFile(string assetPath, List<string> data)
	{
		assetPath = Application.dataPath + "/Resources/" + assetPath + ".txt";
		if (File.Exists (assetPath)) {
			string[] lines = new string[data.Count];
			data.CopyTo (lines);
#if UNITY_EDITOR
			Debug.Log ("Write All Data with size = " + lines.Length);
#endif
			File.WriteAllLines (assetPath, lines, System.Text.Encoding.UTF8);
//			foreach(string line in data)
//			{
//
//			}
		} else {
			Debug.Log("Write not exits " + assetPath);

		}

		Debug.Log ("Application Path = " + Application.dataPath + "     Asset path = " + Application.persistentDataPath);
	}
}
