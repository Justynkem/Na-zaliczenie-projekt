
public class Map

{
    public Point Origin { get; set;}
    public Point Size { get; }

    private int[][] mapData;
    private Dictionary<CellType, char> cellVisuals = new Dictionary<CellType, char>
    {
     {CellType.WallCorner, '+'},
     {CellType.WallHorizontal,'-'},
     {CellType.WallVertical, '|'},
     { CellType.Empty, ' '},
    };

    private CellType[] walkableCellTypes = new CellType[] 
    { 
        CellType.Empty
    };
    public Map()
    {
        mapData = new int[][]
        {
            new []{2,3,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
            new []{1,3,3,3,3,3,3,3,1,3,3,3,3,3,3,3,3,1,3,3,3,3,3,3,3,3,3,1},
            new []{1,3,3,2,0,2,3,3,1,3,3,2,0,0,2,3,3,1,3,3,2,0,0,0,2,3,3,1},
            new []{1,3,3,1,3,1,3,3,1,3,3,3,3,3,1,3,3,1,3,3,3,3,3,3,1,3,3,1},
            new []{1,3,3,2,3,1,3,3,2,0,0,2,3,3,1,3,3,2,0,0,0,2,3,3,1,3,3,1},
            new []{1,3,3,3,3,1,3,3,1,3,3,3,3,3,1,3,3,3,3,3,3,3,3,3,1,3,3,1},
            new []{2,0,0,0,0,2,3,3,2,3,3,3,2,0,0,0,0,0,0,0,0,0,0,0,2,3,3,1},
            new []{1,3,3,3,3,1,3,3,3,3,3,3,1,3,3,3,3,3,3,3,3,3,3,3,3,3,3,1},
            new []{1,3,2,3,3,2,0,0,0,0,0,0,2,3,3,3,2,0,0,0,0,0,0,0,2,0,0,2},
            new []{1,3,1,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,1,3,3,1},
            new []{1,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,3,1,3,3,1},
            new []{1,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,1,3,3,1,3,3,1},
            new []{2,0,0,0,2,3,3,3,2,0,0,0,2,0,0,0,0,0,0,0,0,2,3,3,1,3,3,1},
            new []{1,3,3,3,1,3,3,3,3,3,3,3,1,3,3,3,2,3,3,3,2,0,0,0,2,3,3,1},
            new []{1,3,3,3,1,3,3,3,3,3,3,3,1,3,3,3,1,3,3,3,1,3,3,3,3,3,3,1},
            new []{1,3,3,3,2,3,3,3,2,0,0,0,2,3,3,3,1,3,3,3,1,3,3,3,3,3,3,1},
            new []{1,3,3,3,1,3,3,3,1,3,3,3,3,3,3,3,1,3,3,3,2,0,0,0,2,3,3,1},
            new []{1,3,3,3,1,3,3,3,2,3,3,3,3,3,3,3,1,3,3,3,3,3,3,3,3,3,3,1},
            new []{2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,2,3,3,2},

        };
         int y = mapData.Length;
         int x = 0;

         foreach (int[] row in mapData)
        {
            if (row.Length > x)
            {
                x = row.Length;
            }
        }

        Size = new Point(x, y);
        Origin = new Point(0, 0);
    }
     public CellType GetCellAt(Point point)
    {
        return GetCellAt(point.X, point.Y);
    }

    private CellType GetCellAt(int x, int y)
    {
        return (CellType)mapData[y][x];
    }

    public char GetCellVisualAt(Point point)
    {
        return cellVisuals[GetCellAt(point)];
    }

    public void Display(Point origin)
    {
         Origin = origin;
         
        Console.CursorTop = origin.Y;
         for (int y = 0; y < mapData.Length; y++)
        {
            Console.CursorLeft = origin.X;
            for (int x = 0; x < mapData[y].Length; x++)
            {
                var cellValue = GetCellAt(x, y);
                var cellVisual = cellVisuals[cellValue];
                Console.Write(cellVisual);
            }
            Console.WriteLine();
        }
   
    }

    private CellType GetCellAt(object x, int y)
    {
        throw new NotImplementedException();
    }

    internal bool IsPointCorrect(Point point)
    {
        if (point.Y >= 0 && point.Y < mapData.Length)
        {
            if (point.X >= 0 && point.X < mapData[point.Y].Length)
            {
                if (walkableCellTypes.Contains(GetCellAt(point)))
                {
                    return true;
                }
            }
        }

        return false;
    }
    

}

    