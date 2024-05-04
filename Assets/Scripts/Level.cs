using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level : MonoBehaviour
{
    public List<Table> tables;

    public List<Customer> customers;

    public void MoveCustomerToTable(Table table)
    {
        int indexOfTable = tables.IndexOf(table);
        customers[indexOfTable].transform.DOMove(table.transform.position, 1f).OnComplete(() => {
            customers[indexOfTable].gameObject.SetActive(false);
            table.PlayAnim();
        });
    }

    public void CheckTable()
    {
        foreach(Table table in tables)
        {
            if (!table.isCompleted)
                return;
        }

        GameManager.Instance.CheckLevelUp();
    }

    public static List<GameObject> GetAllChilds(GameObject Go)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < Go.transform.childCount; i++)
        {
            list.Add(Go.transform.GetChild(i).gameObject);
        }
        return list;
    }
}
