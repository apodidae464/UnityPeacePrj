using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpite : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite[] list;
    // Start is called before the first frame update
    void Start()
    {
        int temp = Random.Range(0, list.Length);
        spriteRenderer.sprite = list[temp];
    }

    private void OnEnable()
    {
        int temp = Random.Range(0, list.Length);
        spriteRenderer.sprite = list[temp];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
