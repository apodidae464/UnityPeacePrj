//using System.IO;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;

//[System.Serializable]
//public class TableElement
//{
//    public float x;
//    public float y;
//    public TableElement(float x_coord, float y_coord)
//    {
//        x = x_coord;
//        y = y_coord;
//    }
//}

//[System.Serializable]
//public class TableData
//{
//    public List<TableElement> tableList;
//}

//public class TableMaps : MonoBehaviour
//{
//    public static TableMaps instance;

//    TableData data;
//    public GameObject table;

//    private void Awake()
//    {
//    }

//    private void Start()
//    {
       
//        GameEvents.instance.instanceTable += UpdateTableList;
//        InstanceTable(Constaint.tableListPath);

//        DontDestroyOnLoad(gameObject);
//    }



//    public void InstanceTable(string path)
//    {
//        data = LoadTableList(path);
//        Vector3 pos = new Vector3();
//        for (int i = 0; i < data.tableList.Count; i++)
//        {
//            pos.x = data.tableList[i].x;
//            pos.y = data.tableList[i].y;
//            pos.z = 0.8f;
//            Instantiate(table, pos, transform.rotation);
//        }
//    }

//    public TableData LoadTableList(string path)
//    {
//        string jsonString = File.ReadAllText(path);
//        return JsonUtility.FromJson<TableData>(jsonString);
//    }

//    public void UpdateTableList(float x, float y)
//    {
//        data.tableList.Add(new TableElement(x, y));
//        File.WriteAllText(Constaint.tableListPath, JsonUtility.ToJson(data));
//    }

//    public void ClearTableList()
//    {
//        data.tableList.Clear();
//        data.tableList.Add(new TableElement(Constaint.beginTablePos1_x, Constaint.beginTablePos1_y));
//        data.tableList.Add(new TableElement(Constaint.beginTablePos2_x, Constaint.beginTablePos2_y));
//        data.tableList.Add(new TableElement(Constaint.beginTablePos3_x, Constaint.beginTablePos3_y));

//        File.WriteAllText(Constaint.tableListPath, JsonUtility.ToJson(data));

//    }

//    private void OnDestroy()
//    {
//        GameEvents.instance.instanceTable -= UpdateTableList;

//    }
//}

