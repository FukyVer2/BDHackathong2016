using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CategoryController : MonoBehaviour {

	[HideInInspector]
	public LibraryController libraryCtr;
	BaseCategory baseCategory;
	public Image imgContent;
	public Text txtContent;
	bool isSelected;
	public GameObject gameObjSelected;

	public void UpdateContent(BaseCategory baseCategory)
	{
		this.baseCategory = baseCategory;
		this.txtContent.text = baseCategory.categoryContent;
		this.imgContent.sprite = ResourceLoader.GetCategorySprite(baseCategory.categoryPhoto.Trim());
		this.isSelected = false;
		gameObjSelected.SetActive (this.isSelected);
	}

	public void BntHandleClick()
	{
		if (this.isSelected) {
			this.isSelected = false;
			libraryCtr.RemoveCategory(baseCategory);

		} else {
			this.isSelected = true;
			libraryCtr.AddCategory(baseCategory);
		}

		gameObjSelected.SetActive (this.isSelected);
		SoundManager.Instance.PlaySoundWithType (AudioType.TOUCH);
	}
}
