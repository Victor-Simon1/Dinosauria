using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public CladeInfo cladeInfo;
    bool isChildrenHiden = false;
    public void OnClickButton()
    {
        foreach(GameObject child in cladeInfo.children)
        {
            child.GetComponentInChildren<ButtonBehavior>().OnClickButton();
            child.SetActive(isChildrenHiden);
            
        }
        isChildrenHiden = !isChildrenHiden;
    }
}
