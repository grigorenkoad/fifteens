using System;

public class Game
{
    int _size;
    Map _map;
    Coord _space;
    public int Moves { get; private set; }

    public Game(int size)
    {
        _size = size;
        _map = new Map(_size);
    }

    public void Start(int seed = 0)
    {
        int digit = 0;

        foreach (Coord xy in new Coord().YeldCoord(_size))
            _map.Set(xy, ++digit);

        _space = new Coord(_size);

        if (seed > 0) Shuffle(seed);

        Moves = 0;
    }

    void Shuffle(int seed)
    {
        Random random = new Random(seed);

        for (int j = 0; j < seed; j++)
            PressAt(random.Next(_size), random.Next(_size));
    }

    public int PressAt(int x, int y)
    {
        return PressAt(new Coord(x, y));
    }

    int PressAt(Coord xy)
    {
        if (_space.Equals(xy)) return 0;
        if (xy.x != _space.x && xy.y != _space.y) return 0;

        int steps = Math.Abs(xy.x - _space.x) +
                    Math.Abs(xy.y - _space.y);

        while(xy.x != _space.x)
        {
            Shift(Math.Sign(xy.x - _space.x), 0);
        }

        while(xy.y != _space.y)
        {
            Shift(0, Math.Sign(xy.y - _space.y));
        }

        Moves += steps;

        return steps ;
    }

    void Shift(int sx, int sy)
    {
        Coord next = _space.Add(sx, sy);
        _map.Copy(next, _space);
        _space = next;
    }

    public int GetDigitAt(int x, int y)
    {
        return GetDigitAt(new Coord(x, y));
    }

    int GetDigitAt(Coord xy)
    {
        if (_space.Equals(xy))
            return 0;
        return _map.Get(xy);
    }

    public bool Solved()
    {
        return false;
    }
}
