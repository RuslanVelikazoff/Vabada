public class GameData
{
    public int coin;

    public int[] improveLevel = new int[3];
    public bool[] buyAbilities;
    public bool[] buyCosmetic;

    public GameData()
    {
        coin = 0;

        improveLevel[0] = 1;
        improveLevel[1] = 1;
        improveLevel[2] = 1;
        buyAbilities = new bool[3];
        buyCosmetic = new bool[3];
    }
}
