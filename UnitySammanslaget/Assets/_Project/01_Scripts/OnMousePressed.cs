using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMousePressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform imageTransform;

    public float zoomInTime = 3f;

    public float posX = 0f;
    public float posY = 450f;
    public float scaleX = 3f;
    public float scaleY = 3f;

    private bool mousePressed;
    private float pressedTime = 0;

    private void Update()
    {
        if (mousePressed && pressedTime < zoomInTime) {
            float newPosX = Mathf.SmoothStep(0, posX, pressedTime / zoomInTime);
            float newPosY = Mathf.SmoothStep(0, posY, pressedTime / zoomInTime);
            imageTransform.localPosition = new Vector3(newPosX, newPosY, 0);

            float newScaleX = Mathf.SmoothStep(1, scaleX, pressedTime / zoomInTime);
            float newScaleY = Mathf.SmoothStep(1, scaleY, pressedTime / zoomInTime);
            imageTransform.localScale = new Vector3(newScaleX, newScaleY, 1);

            pressedTime += Time.deltaTime;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("Pointer Down!");


        mousePressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("Pointer Up!");
        imageTransform.localPosition = new Vector3(0, 0, 0);
        imageTransform.localScale = new Vector3(1, 1, 1);
        pressedTime = 0;
        mousePressed = false;
    }
}