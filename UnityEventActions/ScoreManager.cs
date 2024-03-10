using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
	public static ScoreManager Instance { get; private set; }
	public Text ScoreText;
	public Text BlockText;

	private int Score = 0;
	public int Level = 1;
	public int Killcount = 0;
	public int CorruptedBlocks = 0;

	public int CurrentStage = 1;


	private void OnEnable() //ADD SUBSCRIBE & UNSUBSCRIBE
	{
		Events.OnBlockDestroyed += BlockDestroyed;
		Events.OnLeveLUp += LevelUp;
	}

	private void OnDisable()
	{
		Events.OnBlockDestroyed -= BlockDestroyed;
		Events.OnLeveLUp -= LevelUp;
	}

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void Start()
	{
		ScoreText = FindObjectOfType<Text>();
		ScoreText.text = "Score: 0";
		BlockText.text = "Corruption: 0";
	}

	private void BlockDestroyed(Block block)
	{
		Killcount++;
		AddPoints(block.points);

		if (Killcount > 1 && Killcount % 5 == 0)
		{
			Events.OnLeveLUp(); //EVENT CALLED HERE
		}
	}

	public void AddPoints(int points)
	{
		Score += points;
		UpdateScoreText();
	}

	public void UpdateScoreText()
	{
		ScoreText.text = $"Score: {Score}";
		BlockText.text = $"Corruption: {CorruptedBlocks}";
	}

	private void LevelUp()
	{
		Level++;
	}

}