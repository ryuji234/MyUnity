using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static partial class GF
{
    public static GameObject FindChildObj(this GameObject targetObj_, string objName_)
    {
        GameObject searchResult = default;
        GameObject searchTarget = default;
        for (int i = 0; i < targetObj_.transform.childCount; i++)
        {
            searchTarget = targetObj_.transform.GetChild(i).gameObject;
            if (searchTarget.name.Equals(objName_))
            {
                searchResult = searchTarget;
                return searchResult;
            }
            else
            {
                searchResult = FindChildObj(searchTarget, objName_);
            }
        }       //loop

        return searchResult;
    }           // FindChildobj()
    //! �ؽ�Ʈ�޽����� ������ ������Ʈ�� 
    public static GameObject GetRootobj(string objName_)
    {
        Scene activeScene_ = GetActiveScene();
        GameObject[] rootObjs_ = activeScene_.GetRootGameObjects();
        GameObject targetObj_ = default;
        foreach (GameObject rootobj in rootObjs_)
        {
            if (rootobj.name.Equals(objName_))
            {
                targetObj_ = rootobj;
                return targetObj_;
            }
            else { continue; }
        }       //loop

        return targetObj_;
    }
    public static Scene GetActiveScene()
    {
        Scene activeScene_ = SceneManager.GetActiveScene();
        return activeScene_;
    }       //�÷����ϴ� ���� ã�´�.
}

    

