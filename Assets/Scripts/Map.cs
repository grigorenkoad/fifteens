public struct Map
{
    int _size;
    int[,] map;

    public Map(int size)
    {
        _size = size;
        map = new int[_size, _size];
    }

    public void Set(Coord xy, int value)
    {
        if (xy.OnBoard(_size))
            map[xy.x, xy.y] = value;
    }

    public int Get(Coord xy)
    {
        if (xy.OnBoard(_size))
            return map[xy.x, xy.y];
        return 0;
    }

    public void Copy(Coord from, Coord to)
    {
        Set(to, Get(from));
    }
}