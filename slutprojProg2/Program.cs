using System.Numerics;
using Raylib_cs;


GameManager g = new();


while (Raylib.WindowShouldClose() == false)
{
    g.Logic();
    g.DrawScene();
}


