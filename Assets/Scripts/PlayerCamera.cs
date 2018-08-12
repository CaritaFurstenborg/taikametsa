using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Odiana
{
	public class PlayerCamera : MonoBehaviour
	{
		private int playerId;
		private Transform player;
		private float xMax, xMin, yMax, yMin;

		void Awake ()
		{
			player = FindObjectOfType<Player>().transform;
			Vector3 minTile = new Vector3(-15.5f, -37.5f, 0f);
			Vector3 maxTile = new Vector3(29, 7, 0);
			SetLimits(minTile, maxTile);
		}

		void LateUpdate()
		{
			transform.position = new Vector3(Mathf.Clamp(player.position.x, xMin, xMax), Mathf.Clamp(player.position.y, yMin, yMax), -10f);
		}

		private void SetLimits(Vector3 minTile, Vector3 maxTile)
		{
			Camera cam = Camera.main;
			
			float height = 2f * cam.orthographicSize;
			float width = height * cam.aspect;

			xMin = minTile.x + width / 2;
			xMax = maxTile.x - width / 2;
			yMax = maxTile.y - height / 2;
			yMin = minTile.y + height / 2; 
		}
	}
}