using Raylib_cs;
public class Level
{
    int [,] layout = 
    {
        {0,0,1},
        {1,0,1},
        {0,1,0}

    };
    public Level()
    {
        for (int i = 0; i < layout.Length; i++)
        {
            Raylib.DrawRectangle(i+10,i+10,5,5, Color.BLACK);
        }
    }
}
