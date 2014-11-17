
public sealed class GameLogic {

	static readonly GameLogic _instance = new GameLogic();

	private int points = 0;
	private int time = 90;

	public static GameLogic Instance
	{
		get
		{
			return _instance;
		}
	}

	GameLogic()
	{
		points = 0;
		// Initialize.
	}

	public int Points{
		get{
			return this.points;
		}
		set{
			this.points = value;
		}
	}
	public void addPoint(){
		points++;
	}
}
