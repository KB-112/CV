using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DonotDestroyOnload : MonoBehaviour
{
    public List<GameObject> DontDestroy = new List<GameObject>();
    public string Edtag;

    public void Start()
    {
        ListOfObj();
       
        SceneChange.EDIntialPosition += A;
       
        
      
       
    }

    public void ListOfObj()
    {
        for (int i = 0; i < DontDestroy.Count; i++)
        {
            GameObject obj1 = Instantiate(DontDestroy[i]);

        

            DontDestroyOnLoad(obj1);
        }
    }

    public void A()

    {
      
        GameObject[] gameObjectsWithTag = GameObject.FindGameObjectsWithTag(Edtag);
      
        if (gameObjectsWithTag.Length > 0)
        {
            GameObject taggedObject = gameObjectsWithTag[0];

            taggedObject.transform.position = new Vector2(-7.7f, -4.6f);

        }
       
    }
    
   
}
