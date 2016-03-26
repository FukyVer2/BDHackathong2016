using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIGridLayout : MonoSingleton<UIGridLayout> {

    public Padding padding;
    public float space;
    public float percentDiv;
    public float percentSpace;
    //
    private float maxHeightChild;
    private float maxWidthChild;
    private float minHeightChild;
    private float minWidthChild;
    //
    public RectTransform parentTransform;
    public float parentWidth;
    public float parentHeight;
    //
    public List<UITileLayout> childLayout;
    public int childIdIndex; //Cuc nao to hien tai
    //
    void Start()
    {
        SetSizeOfParent();
        childIdIndex = 0;
        //childLayout = new List<UITileLayout>();
    }

    public void InitLayout()
    {

    }

    public void CalParentSize()
    {
        parentTransform = gameObject.GetComponent<RectTransform>();
        Vector2 parentSize = parentTransform.rect.size;
        parentHeight = parentSize.y;
    }

    public void CalChildSize()
    {
        CalParentSize();
        maxHeightChild = parentHeight - padding.top - padding.bottom;
        maxWidthChild = maxHeightChild;
        //Tinh toan size cua cuc nho
        minHeightChild = maxHeightChild / percentDiv;
        minWidthChild = minHeightChild;
        //
        space = (maxWidthChild - minWidthChild) * percentSpace;
    }
    ///*Left*/ rectTransform.offsetMin.x;
    ///*Right*/ rectTransform.offsetMax.x;
    ///*Top*/ rectTransform.offsetMax.y;
    ///*Bottom*/ rectTransform.offsetMin.y;
    public void SetSizeOfParent()
    {
        CalChildSize();
        padding.left = parentTransform.rect.width / 2 - minWidthChild / 2 - space;
        padding.right = padding.left;
        if (childLayout.Count > 2)
        {
            parentWidth = padding.left + padding.right + (childLayout.Count + 1) * space + (childLayout.Count) * minWidthChild;
        }
        else
        {
            parentWidth = padding.left + padding.right + space / 2 + (childLayout.Count + percentDiv - 1) * minWidthChild;
        }
        //RectTransformExtensions.SetSize(parentTransform, new Vector2(parentWidth, parentHeight));
        parentTransform.offsetMax = parentTransform.offsetMax + new Vector2(parentWidth - parentTransform.rect.width, 0);
        //Debug.Log(parentTransform.offsetMax.x);
        //Debug.Log(parentTransform.offsetMax.y);
        //Debug.Log(parentTransform.offsetMin.x);
        //Debug.Log(parentTransform.offsetMin.y);
        SetSizeOfChild();
    }

    public void SetSizeOfChild()
    {
        foreach (var child in childLayout)
        {
            if (child.childID == childIdIndex)
            {
                child.isMaxSize = true;
            }
            else
            {
                child.isMaxSize = false;
            }
            //
            if (child.isMaxSize)
            {
                child.SetChildSize = new Vector2(maxWidthChild, maxHeightChild);
            }
            else
            {
                child.SetChildSize = new Vector2(minWidthChild, minHeightChild);
            }
            child.SetChildPosition = new Vector3(padding.left + minWidthChild * (child.childID + 0.5f) + (child.childID + 1) * space, child.SetChildPosition.y);
        }
    }

    public float childLeft;
    public float childRight;
    public void ScaleChildOnDrag()
    {
        UITileLayout child = childLayout.Find(x => x.childID == childIdIndex);
        childRight = child.SetChildPosition.x + maxWidthChild / 2 + parentTransform.anchoredPosition.x - parentWidth / 2;
        childLeft = child.SetChildPosition.x - maxWidthChild / 2 + parentTransform.anchoredPosition.x - parentWidth / 2;
        if (childLeft > 0 && Mathf.Abs(childRight) > Mathf.Abs(childLeft))
        {
            Debug.Log("Cuc trai: " + (float)(4 * childLeft) / (3 * space));
            if (childIdIndex != 0)
            {
                UITileLayout child1 = childLayout.Find(x => x.childID == (childIdIndex - 1));
                float childWidth = maxWidthChild * (1 - (float)(2 * percentSpace* childLeft) / ((2*percentSpace - 1) * space));
                float childWidth1 = minWidthChild * (1 + (float)(2 * percentSpace * childLeft) / ((2 * percentSpace - 1) * space));
                childWidth = (childWidth > minWidthChild) ? childWidth : minWidthChild;
                childWidth1 = (childWidth1 < maxWidthChild) ? childWidth1 : maxWidthChild;
                child1.SetChildSize = new Vector2(childWidth1, childWidth1);
                child.SetChildSize = new Vector2(childWidth, childWidth);
                Debug.Log("Cuc trai to");
            }
        }
        else if (childRight < 0 && Mathf.Abs(childRight) < Mathf.Abs(childLeft))
        {
            Debug.Log("Cuc phai: " + (parentTransform.anchoredPosition.x - childLeft));
            if (childIdIndex != childLayout.Count - 1)
            {
                UITileLayout child1 = childLayout.Find(x => x.childID == (childIdIndex + 1));
                float childWidth = maxWidthChild * (1 - (float)(2 * percentSpace * Mathf.Abs(childRight)) / ((2 * percentSpace - 1) * space));
                float childWidth1 = minWidthChild * (1 + (float)(2 * percentSpace * Mathf.Abs(childRight)) / ((2 * percentSpace - 1) * space));
                childWidth = (childWidth > minWidthChild) ? childWidth : minWidthChild;
                childWidth1 = (childWidth1 < maxWidthChild) ? childWidth1 : maxWidthChild;
                child1.SetChildSize = new Vector2(childWidth1, childWidth1);
                child.SetChildSize = new Vector2(childWidth, childWidth);
                Debug.Log("Cuc phai to");
            }
        }
    }

    //
    public bool isChange = false;
    public Vector2 positionChange;
    public void ResizeOfParent()
    {
        float parentW = parentTransform.rect.width + parentTransform.offsetMin.x - parentTransform.offsetMax.x;
        int childIndex = childIdIndex;
        float anchorSpaceMin = Mathf.Abs(childLayout.Find(x => x.childID == childIdIndex).SetChildPosition.x + parentTransform.anchoredPosition.x - parentWidth / 2);
        foreach (var child in childLayout)
        {
            if (Mathf.Abs((child.SetChildPosition.x + parentTransform.anchoredPosition.x - parentWidth / 2)) < anchorSpaceMin)
            {
                anchorSpaceMin = Mathf.Abs((child.SetChildPosition.x + parentTransform.anchoredPosition.x - parentWidth / 2));
                childIndex = child.childID;
            }
        }
        if(childIndex != childIdIndex)
        {
            childIdIndex = childIndex;
            SetSizeOfChild();
        }
        //isChange = true;
        anchorSpaceMin = childLayout.Find(x => x.childID == childIdIndex).SetChildPosition.x + parentTransform.anchoredPosition.x - parentWidth / 2;
        //positionChange = new Vector2(parentTransform.anchoredPosition.x - anchorSpaceMin, parentTransform.anchoredPosition.y);
        parentTransform.anchoredPosition = new Vector2(parentTransform.anchoredPosition.x - anchorSpaceMin, parentTransform.anchoredPosition.y);

    }

    void Update()
    {
        //if (isChange)
        //{
        //    Vector2 position;
        //    Vector2 velocity = new Vector2(0.2f, 0.2f);
        //    for (int axis = 0; axis < 2; axis++)
        //    {
        //        // Apply spring physics if movement is elastic and content has an offset from the view.
        //        float speed = velocity[axis];
        //        position.x = Mathf.SmoothDamp(parentTransform.anchoredPosition[axis], positionChange[axis], ref speed, 0.5f, Mathf.Infinity, Time.unscaledDeltaTime);
        //        velocity[axis] = speed;
        //    }
        //}
        //if ((int)parentTransform.anchoredPosition.x == (int)positionChange.x)
        //{
        //    isChange = false;
        //}
    }
}

[System.Serializable]
public class Padding
{
    public float left;
    public float right;
    public float top;
    public float bottom;
}
