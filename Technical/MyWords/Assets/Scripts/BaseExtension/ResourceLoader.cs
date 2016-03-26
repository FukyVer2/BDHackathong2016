using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceLoader{

    // Use this for initialization
    public static Dictionary<string, Sprite> pictureLibrary = new Dictionary<string,Sprite>();
    public static Dictionary<string, Sprite> categoryLibrary = new Dictionary<string, Sprite>();
    public static Dictionary<string, Sprite> characterLibrary = new Dictionary<string,Sprite>();
	public static Dictionary<string, AudioClip> audioLibrary = new Dictionary<string, AudioClip>();

    public static void InitData()
    {
        //pictureLibrary = new Dictionary<string, Sprite>();
        //characterLibrary = new Dictionary<string, Sprite>();
		LoadSpriteFromFile("TexturePacker", ref pictureLibrary);
        LoadSpriteFromFile("Image/Category", ref categoryLibrary);
		LoadAudioFromFile ("Audio/Wav", ref audioLibrary);
		LoadAudioFromFile ("Audio/Sound", ref audioLibrary);

		//Debug.Log ("Count of image = " + pictureLibrary.Count);
        //("Image/Alphabet", ref characterLibrary);
    }

	public static void LoadAudioFromFile(string filePath, ref Dictionary<string, AudioClip> source)
	{
		if (!string.IsNullOrEmpty(filePath))
		{
			AudioClip[] audioClips = Resources.LoadAll<AudioClip>(filePath);
			foreach (var item in audioClips)
			{
				source.Add(item.name, item);
			}
		}
	}

    public static void LoadSpriteFromFile(string filePath, ref Dictionary<string, Sprite> source)
    {
        if (!string.IsNullOrEmpty(filePath))
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>(filePath);
            foreach (var item in sprites)
            {
			
				//Debug.Log("Image");
				if(!source.ContainsKey(item.name))
				{
					source.Add(item.name, item);
				}
                
            }
        }
    }

	public static AudioClip GetAudioClip(string audioName)
	{
		if (audioLibrary != null) {
			if(audioLibrary.ContainsKey(audioName)){
				return audioLibrary[audioName];
			}
		}
		return null;
	}

    public static Sprite GetCharacterSprite(string spriteName)
    {
        if (characterLibrary != null)
        {
            if (characterLibrary.ContainsKey(spriteName))
            {
                return characterLibrary[spriteName];
            }
        }
        return null;
    }

    public static Sprite GetPictureSprite(string spriteName)
    {
        if (pictureLibrary != null)
        {
            if (pictureLibrary.ContainsKey(spriteName))
            {
                return pictureLibrary[spriteName];
            }
        }
        return null;
    }

    public static Sprite GetCategorySprite(string spriteName)
    {
        if (categoryLibrary != null)
        {
            if (categoryLibrary.ContainsKey(spriteName))
            {
                return categoryLibrary[spriteName];
            }
        }
        return null;
    }
}
