using UnityEngine;
using System.Collections;
using Vuforia;
using System.Collections.Generic;

public class ManagerTargetAsset : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	[ContextMenu("Get Trackables")]
	void GetAllTrackble()
	{
        // tobi

        ObjectTracker ot = TrackerManager.Instance.GetTracker<ObjectTracker>();
        IEnumerable<DataSet> dataSet = ot.GetDataSets();
        foreach (DataSet data in dataSet)
        {
            //Debug.Log(data.);
            IEnumerable<Trackable> trackables = data.GetTrackables();
            foreach (Trackable tr in trackables)
            {
                Debug.Log(tr.Name);
            }
        }
	}

	[ContextMenu("Disall Imgs")]
	public void DisableImgTargetInChilds()
	{
		ChangeComponentImageTargetInChils(false);
	}

	[ContextMenu("Enable Imgs")]
	public void EnableImgTargetInChilds()
	{
		ChangeComponentImageTargetInChils(true);
	}
	void ChangeComponentImageTargetInChils(bool isActive)
	{
        // tobi dong

        ImageTargetAbstractBehaviour[] compImgTargets = transform.GetComponentsInChildren<ImageTargetBehaviour>();
        foreach (ImageTargetAbstractBehaviour compImgTarget in compImgTargets)
        {
            //Debug.Log("Change CompImgTarget");
            compImgTarget.enabled = isActive;
        }



//		int childCount = transform.childCount;
//		for (int i = 0; i < childCount; i++) {
//			transform.GetChild(i).GetComponent<ImageTargetBehaviour>().enabled = isActive;
//		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
