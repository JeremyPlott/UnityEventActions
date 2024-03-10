using System;

public class Events
{
	public static Action<Block> OnBlockDestroyed;
	public static Action<int> OnPointsAdded;
	public static Action OnLeveLUp;
}
