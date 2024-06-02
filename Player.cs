class Player
{
    public string Visual { get; set;} = "@";
    public int Hp 
    { 
        get => hp;
        set => hp = Math.Clamp(value, 0, MaxHp);
    }
    int hp = 90;
    public int MaxHp { get; set; } = 100;
    public Point Position { get; set; }
    public Point PreviousPosition { get; set;}

    private Dictionary<ConsoleKey, Point> directions = new()
    {
        { ConsoleKey.A, new Point(-1, 0)}
    };

    public Player(int x, int y)
    {
        Position = new Point(x, y);
        PreviousPosition = new Point(x, y);
    }

    public Player(string visual, Point startingPosition)
    {
        Visual = visual;
        Position = new Point(startingPosition);
        PreviousPosition = new Point(startingPosition);
        directions[ConsoleKey.D] = new Point(1, 0);
        directions[ConsoleKey.W] = new Point(0, -1);
        directions[ConsoleKey.S] = new Point(0, 1);
        directions[ConsoleKey.E] = new Point(1, -1);
    }
    
    //Copy constructor
    public Player(Player other)
    {
        MaxHp = other.MaxHp;
        Hp = other.Hp;
        Position = new Point(other.Position);
        PreviousPosition = new Point(other.PreviousPosition);
    }


    // TODO: Should it return hp after heal?
    public void Heal(int amount)
    {
        Console.WriteLine("Healing!");
        Hp += amount;
    }

    public Point GetNextPosition()
    {
        Point nextPosition = new Point(Position);
        
        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
        if (directions.ContainsKey(pressedKey.Key))
        {
            nextPosition.X += directions[pressedKey.Key].X;
            nextPosition.Y += directions[pressedKey.Key].Y;
        }

        return nextPosition;
    }
    
    public void Move(Point targetPosition)
    {
        PreviousPosition.X = Position.X;
        PreviousPosition.Y = Position.Y;
        
        Position.X = targetPosition.X;
        Position.Y = targetPosition.Y;
    }
}