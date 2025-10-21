using NUnit.Framework.Interfaces;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class Highlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject highlightObj;
    public ItemData itemData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("in" + this.name, this);
        GameObject highlightObj = GameObject.FindWithTag("Highlight");
        RectTransform rt = gameObject.GetComponent<RectTransform>();
        RectTransform rtH = highlightObj.gameObject.GetComponent<RectTransform>();

        rtH.sizeDelta = rt.sizeDelta;

        if (this.CompareTag("InGrid") == true)
        {
            Debug.Log("it is what it is");

            highlightObj.transform.position = this.gameObject.transform.position;
            highlightObj.SetActive(true);
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("out");
        GameObject highlightObj = GameObject.FindWithTag("Highlight");
        highlightObj.transform.position = new Vector2(-100, 0);
    }
}
