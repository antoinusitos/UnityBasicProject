using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScalingWindow : MonoBehaviour
{
    private RectTransform _transform;
    private bool _selected = false;
    private Vector2 _offset = Vector2.zero;

    public RectTransform windowAttached;
    public bool isWidth = false;
    public bool isLeft = false;
    private float tempWidth;
    private float tempHeight;
    private Vector2 tempPos;

    private void Start()
    {
        _transform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Vector2 mousePos = Input.mousePosition;

        if (
            mousePos.x < _transform.position.x + _transform.rect.width / 2 &&
            mousePos.x > _transform.position.x - _transform.rect.width / 2 &&
            mousePos.y < _transform.position.y + _transform.rect.height / 2 &&
            mousePos.y > _transform.position.y - _transform.rect.height / 2 &&
            Input.GetMouseButtonDown(0)
        )
        {
            _selected = true;
            _offset = mousePos;
            tempWidth = windowAttached.rect.width;
            tempHeight = windowAttached.rect.height;
            tempPos = Vector2.zero;
        }

        if (_selected && Input.GetMouseButton(0))
        {
            if(!isWidth)
                ScaleHeight((_offset.y - mousePos.y) + tempHeight);
            else
            {
                ScaleWidth((_offset.x - mousePos.x) + tempWidth);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _selected = false;
        }
    }


    public void ScaleHeight(float size)
    {
        windowAttached.sizeDelta = new Vector2(windowAttached.rect.width, size);
    }

    public void ScaleWidth(float size)
    {
        if(isLeft)
            windowAttached.localPosition = tempPos - new Vector2((size / 2),0);
        else 
            windowAttached.localPosition = tempPos + new Vector2((size / 2),0);

        windowAttached.sizeDelta = new Vector2(size, windowAttached.rect.height);
        print(size);
    }
}
