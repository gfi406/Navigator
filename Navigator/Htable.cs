public class Htable
{
    private const int Capacity = 100; // Размер массива хеш-таблицы
    private List<Route>[] table;

    public Htable()
    {
        table = new List<Route>[Capacity];
        for (int i = 0; i < Capacity; i++)
        {
            table[i] = new List<Route>();
        }
    }

    private int GetHash(string key)
    {
        int hashCode = key.GetHashCode();
        int positiveHashCode = hashCode >= 0 ? hashCode : ~hashCode;
        return positiveHashCode % Capacity;
    }

    public void Add(string key, Route route)
    {
        int hash = GetHash(key);

        
        if (hash < 0 || hash >= Capacity)
        {
            throw new ArgumentOutOfRangeException(nameof(hash), "Invalid hash value");
        }
        
        if (table[hash].Any(r => r.Id == route.Id))
        {
            // throw new ArgumentException($"An element with the same Id '{route.Id}' already exists.", nameof(route));
            Console.WriteLine($"Маршрут '{route.Id}' уже есть");


        }
        else
        {
            table[hash].Add(route);
        }


    }

    public Route Get(string routeId)
    {
        int hash = GetHash(routeId);
        return table[hash].FirstOrDefault(route => route.Id == routeId);
    }

    public bool Contains(string routeId)
    {
        int hash = GetHash(routeId);
        return table[hash].Any(route => route.Id == routeId);
    }

    public void Remove(string routeId)
    {
        int hash = GetHash(routeId);
        var routeToRemove = table[hash].FirstOrDefault(route => route.Id == routeId);
        if (routeToRemove != null)
        {
            table[hash].Remove(routeToRemove);
        }
    }

    public int Size()
    {
        int size = 0;
        foreach (var list in table)
        {
            size += list.Count;
        }
        return size;
    }
    public Route GetValueOrDefault(string routeId, Route defaultValue)
    {
        int hash = GetHash(routeId);
        return table[hash].FirstOrDefault(route => route.Id == routeId) ?? defaultValue;
    }

    public bool TryGetValue(string routeId, out Route route)
    {
        int hash = GetHash(routeId);
        route = table[hash].FirstOrDefault(r => r.Id == routeId);
        return route != null;
    }

    public IEnumerable<Route> Values()
    {
        return table.SelectMany(list => list);
    }
    
}
