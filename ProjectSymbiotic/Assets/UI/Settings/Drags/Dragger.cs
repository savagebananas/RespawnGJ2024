using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Dragger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    private float lb, rb;
    public RectTransform rectTransform;
    private RectTransform rc;
    private bool isMouseOver = false;
    public Canvas canvas;
    public float offset;
    public TMP_Text tt;
    public int maxx;
    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
    }
    private void GetBorder()
    {
        float width = rectTransform.sizeDelta.x;
        lb = -(width * rectTransform.pivot.x);
        rb = (width * (1 - rectTransform.pivot.x));
    }
    void Start()
    {
        rc=GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        GetBorder();
        if (isMouseOver && Input.GetMouseButton(0) && canvas != null)
        {
            Debug.Log(lb + "  " + rb);
            Vector2 mousePosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out mousePosition);

            // Calculate the distance on the x-axis between the mouse and the dragger
            mousePosition.y += offset;

            float distance = Mathf.Abs(mousePosition.x - rc.anchoredPosition.x);
            if (distance <= 60) // 25 units threshold
            {
                if (mousePosition.x < lb)
                {
                    rc.anchoredPosition = new Vector2(lb, rc.anchoredPosition.y);
                    tt.text = "0";
                }
                else if (mousePosition.x > rb)
                {
                    rc.anchoredPosition = new Vector2(rb, rc.anchoredPosition.y);
                    tt.text = maxx.ToString();
                }
                else
                {
                    rc.anchoredPosition = new Vector2(mousePosition.x, rc.anchoredPosition.y);
                    tt.text = ((int)(maxx*(mousePosition.x - lb)/(rb-lb))).ToString();
                }
            }
        }
    }
}
