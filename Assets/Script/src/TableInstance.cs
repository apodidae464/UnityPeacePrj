using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableInstance : MonoBehaviour
{
    public static TableInstance instance;
    public GameObject table;
    List<Vector3> tableList;

    public bool loadNextLevel;
    // Start is called before the first frame update
    void Start()
    {
        loadNextLevel = false;
        GameEvents.instance.instanceTable += addTable;
        GameEvents.instance.nextLevel += AlertNextLevel;
        Clear();
        InstanceTable();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameEvents.isStart)
            Clear();
        if(loadNextLevel)
        {
            InstanceTable();
            loadNextLevel = false;
        }
    }

    public void InstanceTable()
    {
        for (int i = 0; i < tableList.Count; i++)
        {
            Instantiate(table, tableList[i], transform.rotation);
        }
    }

    public void addTable(float x, float y)
    {
        tableList.Add(new Vector2(x, y));
    }

    public void AlertNextLevel()
    {
        loadNextLevel = true;
    }

    public void Clear()
    {
        if (tableList == null)
            tableList = new List<Vector3>();
        if(tableList.Count >0)
            tableList.Clear();
        tableList.Add(new Vector3(Consts.beginTablePos1_x, Consts.beginTablePos1_y, 0.8f));
        tableList.Add(new Vector3(Consts.beginTablePos2_x, Consts.beginTablePos2_y, 0.8f));
        tableList.Add(new Vector3(Consts.beginTablePos3_x, Consts.beginTablePos3_y, 0.8f));
    }

    private void OnDestroy()
    {
        GameEvents.instance.instanceTable -= addTable;
        GameEvents.instance.nextLevel -= AlertNextLevel;

    }
}
