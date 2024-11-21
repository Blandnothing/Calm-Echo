using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CanWalkMap:MonoBehaviour
{
	[SerializeField]
	private int left,right,up,under;
	private Dictionary<Vector2Int,bool> WalkableDic;
	public List<Tilemap> maps;

	public static CanWalkMap instance;
	private bool PIsWalkable(Vector2Int position)
	{  
		foreach (Tilemap tilemap in maps)
		{
			TileBase tile = tilemap.GetTile((Vector3Int)position);
			if (!object.ReferenceEquals(tile,null))
			{
				return false;
                
			}
		}
		return true;
	}
	private void Awake()
	{
		instance = this;
		WalkableDic = new();
		for (int i = left; i <= right; i++)
		{
			for (int j = under; j <= up; j++)
			{
				WalkableDic[new Vector2Int(i,j)] = PIsWalkable(new Vector2Int(i,j));
			}
		}
	}
	public bool IsWalkable(Vector2Int position)
	{
		return WalkableDic[position];
	}
}
