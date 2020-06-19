using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TileBuilder : MonoBehaviour
{
    public Map map;
    public GameObject brushPrefab;
    public AudioSource audioSource;
    public AudioClip placementSound;
    public AudioClip invalidSound;

    public IBrush brush;
    private InputMaster controls;

    private bool isDrawing = false;

    private void Awake()
    {
        controls = new InputMaster();
    }

    private void OnEnable()
    {
        controls.TileBuilder.Draw.performed += OnDraw;
        controls.TileBuilder.ClearBrush.performed += OnClearBrush;
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
        controls.TileBuilder.Draw.performed -= OnDraw;
        controls.TileBuilder.ClearBrush.performed -= OnClearBrush;
    }

    void Update()
    {
        Vector3Int? coordinate = map.MouseToCoordinateInt();

        if (coordinate != null && brush != null)
        {
            brush.DrawPreview(map, coordinate.GetValueOrDefault(), brushPrefab);
        }
    }

    public void DrawBegin()
    {
        if (Game.IsPointerOverUIObject()) return;

        Vector3Int? coordinate = map.MouseToCoordinateInt();

        if (coordinate != null && brush != null)
        {
            brush.DrawBegin(map, coordinate.GetValueOrDefault(), brushPrefab);
            isDrawing = true;
        }
    }

    public void DrawEnd()
    {
        if (Game.IsPointerOverUIObject()) return;

        Vector3Int? coordinate = map.MouseToCoordinateInt();

        if (coordinate != null && brush != null)
        {
            bool drew = brush.DrawEnd(map, coordinate.GetValueOrDefault(), brushPrefab);
            if (drew)
            {
                audioSource.PlayOneShot(placementSound);
                ClearBrush();
            }
            else
            {
                audioSource.PlayOneShot(invalidSound);
            }
            isDrawing = false;
        }
    }
    
    public void SetBrush(GameObject brushPrefab)
    {
        IBrush brush = brushPrefab.GetComponent(typeof(IBrush)) as IBrush;
        if (brush != null) {
            this.brush = brush;
        }
        else
        {
            Debug.LogWarning("Could not assign brush. The brush must implement IBrush interface...");
        }

        ITileAttachment tileAttachment = brushPrefab.GetComponent(typeof(ITileAttachment)) as ITileAttachment;
        if (tileAttachment != null)
        {
            this.brushPrefab = brushPrefab;
        }
        else {
            Debug.LogWarning("Could not assign brush. The brush must implement ITileAttachment interface...");
        }
    }

    public void ClearBrush()
    {
        brushPrefab = null;
        if (brush != null)
        {
            brush.Reset();
            brush = null;
        }
    }

    public void OnDraw(InputAction.CallbackContext ctx)
    {
        if (!isDrawing) {
            DrawBegin();
        } else
        {
            DrawEnd();
        }
    }

    public void OnClearBrush(InputAction.CallbackContext ctx)
    {
        if (Game.IsPointerOverUIObject()) return;
        ClearBrush();
    }
}
