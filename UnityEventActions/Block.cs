using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
	private float hitTimer = 0f;
	private float hitCooldown = 0.1f;
	public int hitsToBreak;
	public int points = 10;

	public GameObject blockText;
	public List<Color> colors;
	public List<SpriteRenderer> spriteRenderers;
	public int colorIndex = 0;
}
