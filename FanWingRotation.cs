using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanWingRotation : MonoBehaviour
{
    List<GameObject> objectsToRotate = new List<GameObject>();
    public float rotationSpeeds;
    public string rotTag;

    private void Start()
    {
        EventsControllers.FanRot += FantRt;
        Debug.Log("No of Fans with RotTag: " + CountObjectsWithTag());
    }

    void FantRt()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(rotTag);

        for (int i = 0; i < objectsWithTag.Length; i++)
        {
            objectsWithTag[i].transform.Rotate(0, 0, rotationSpeeds * Time.deltaTime);
        }
    }

    int CountObjectsWithTag()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(rotTag);
        return objectsWithTag.Length;
    }



}
