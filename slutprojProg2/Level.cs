using Raylib_cs;
public class Level
{
    public List<Rectangle> Walls {get; set;} = new();
    public List<Rectangle> Sand {get; set;} = new();
    public List<Rectangle> Track {get; set;} = new();

    public Level()
    {
        // en array som används som banans layout, där de olika siffrorna beskriver olika "tiles"
        int [,] layout =
        {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,2,2,2,2,2,2,2,2,2,2,2,2,0,1},
            {1,0,2,2,2,2,2,2,2,2,2,2,2,2,0,1},
            {1,0,2,2,0,0,0,0,0,0,0,0,2,2,0,1},
            {1,0,2,2,0,0,0,0,0,0,0,0,2,2,0,1},
            {1,0,2,2,0,0,0,0,0,0,0,0,2,2,0,1},
            {1,0,2,2,0,0,0,0,0,0,0,0,2,2,0,1},
            {1,0,2,2,0,0,0,0,0,0,0,0,2,2,0,1},
            {1,0,2,2,0,0,0,0,0,0,0,0,2,2,0,1},
            {1,0,2,2,0,0,0,0,0,0,0,0,2,2,0,1},
            {1,0,2,2,0,0,0,0,0,0,0,0,2,2,0,1},
            {1,0,2,2,2,2,2,2,2,2,2,2,2,2,0,1},
            {1,0,2,2,2,2,2,2,2,2,2,2,2,2,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        };
        // lägger in de olika tilsen i respektive listor
        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 16; y++)
            {
                if(layout[y,x] == 0)
                {
                    Rectangle s = new(x * 50,y * 50, 50, 50);
                    Sand.Add(s);
                }
                if(layout[y,x] == 1)
                {
                    Rectangle w = new(x * 50,y * 50, 50, 50);
                    Walls.Add(w);
                }
                if(layout[y,x] == 2)
                {
                    Rectangle t = new(x * 50,y * 50, 50, 50);
                    Track.Add(t);
                }
            }
        }
    }
}
