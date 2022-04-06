using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopItemDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
	
	
	private ShopItem Item;
	
	public static Canvas canvas;
	
	private RectTransform rt;
	private CanvasGroup cq;
	private Image img;
	
	private Vector3 originPos;
	private bool drag;
	
	private void Initialize(ShopItem item)
	{
		Item = item;
	}
	
	private void Awake()
	{
		rt = GetComponent<RectTransform>();
		cg = GetComponent<CanvasGroup>();
		
		img = GetComponent<Image>();
		originPos = rt.anchoredPosition;
	}

    public void OnBeginDrag(PointerEventData eventData)
	{
		drag = true;
		cg.blocksRaycasts = false;
		img.maskable = true;
	}
	
	public void OnDrag(PointerEventData eventdata)
	{
		rt.anchoredPosition += eventData.delta / canvas.scaleFactor;
	}
	
	public void OnEndDrag(PointerEventData eventdata)
	{
		drag = false;
		cg.blocksRaycasts = true;
		img.maskable = true;
		rt.anchoredPosition = originPos;
	}
	
	public void OnTriggerEnter2D(Collider2D other)
	{
		ShopManager.current.ShopButton_Click;
		
		Color c = img.color;
		c.a = 0f;
		img color = c;
		
		Vector3 position = new Vector3(transform.position.x, transform.position.y);
		position = Camera.main.ScreenToWorldPoint(position);
		
		BuildingSystem.current.InitializeWithObject(Item.Prefab, positon); 
	}
	
	private void OnEnable()
	{
		drag = false;
		cg.blocksRaycasts = true;
		img.maskable = true;
		rt.anchoredPosition = originPos;
		
		Color c = img.color;
		c.a = 1f;
		img color = c;
	}
}
