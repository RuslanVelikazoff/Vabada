public class GameData
{
    public int coin;

    public int[] improveLevel = new int[3];
    public bool[] buyAbilities = new bool[3];
    public bool[] buyCosmetic = new bool[3];

    public bool[] openLocation = new bool[4];
    public bool[] openForestLevel = new bool[8];
    public bool[] openCastleLevel = new bool[8];
    public bool[] openDesertLevel = new bool[8];
    public bool[] openSubseaLevel = new bool[8];

    public GameData()
    {
        coin = 909999;

        buyCosmetic[0] = true;
        
        improveLevel[0] = 1;
        improveLevel[1] = 1;
        improveLevel[2] = 1;

        openLocation[0] = true;
        openLocation[1] = false;
        openLocation[2] = false;
        openLocation[3] = false;

        openForestLevel[0] = true;
        openForestLevel[1] = false;
        openForestLevel[2] = false;
        openForestLevel[3] = false;
        openForestLevel[4] = false;
        openForestLevel[5] = false;
        openForestLevel[6] = false;
        openForestLevel[7] = false;

        openCastleLevel[0] = false;
        openCastleLevel[1] = false;
        openCastleLevel[2] = false;
        openCastleLevel[3] = false;
        openCastleLevel[4] = false;
        openCastleLevel[5] = false;
        openCastleLevel[6] = false;
        openCastleLevel[7] = false;

        openDesertLevel[0] = false;
        openDesertLevel[1] = false;
        openDesertLevel[2] = false;
        openDesertLevel[3] = false;
        openDesertLevel[4] = false;
        openDesertLevel[5] = false;
        openDesertLevel[6] = false;
        openDesertLevel[7] = false;

        openSubseaLevel[0] = false;
        openSubseaLevel[1] = false;
        openSubseaLevel[2] = false;
        openSubseaLevel[3] = false;
        openSubseaLevel[4] = false;
        openSubseaLevel[5] = false;
        openSubseaLevel[6] = false;
        openSubseaLevel[7] = false;
    }
}
