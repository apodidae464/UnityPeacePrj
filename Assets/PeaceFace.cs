using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeaceFace : MonoBehaviour
{

    [SerializeField] Image img;
    [SerializeField] Sprite[] array;
    
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.instance.peaceFace += ChangePeaceFace;
    }

    // Update is called once per frame
    public void ChangePeaceFace(int id)
    {
        if(id < array.Length)
        {
            img.sprite = array[id];
        }
    }
}
