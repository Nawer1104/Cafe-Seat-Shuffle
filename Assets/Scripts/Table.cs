using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    private Animator anim;

    private bool isClicked;

    public bool isCompleted;

    public GameObject vfxCompleted;
    private void Awake()
    {
        anim = GetComponent<Animator>();

        isClicked = false;

        isCompleted = false;
    }

    private void OnMouseDown()
    {
        if (isClicked) return;

        isClicked = true;

        GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].MoveCustomerToTable(this);
    }

    public void PlayAnim()
    {
        anim.SetTrigger("Sit");
        GetComponent<BoxCollider2D>().enabled = false;

        GameObject vfx = Instantiate(vfxCompleted, transform.position, Quaternion.identity) as GameObject;
        Destroy(vfx, 1f);

        isCompleted = true;

        GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].CheckTable();
    }
}
