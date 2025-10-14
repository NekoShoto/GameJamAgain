using UnityEngine;
using UnityEngine.EventSystems;

public class Highlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject highlight;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("in" + this.name, this);
        
        if (this.CompareTag("InGrid") == true)
        {
            Debug.Log("it is what it is");
            highlight.transform.position = this.gameObject.transform.position;
            highlight.SetActive(true);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("out");
        highlight.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highlight.SetActive(false);  
    }
}
