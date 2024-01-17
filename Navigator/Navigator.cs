using System;
using System.Collections.Generic;
using System.Linq;

public class Navigator : INavigator
{
    private Htable routes; // Заменяем Dictionary на SimpleHashTable
    private HashSet<string> routeIds;

    public Navigator()
    {
        routes = new Htable(); // Используем вашу хеш-таблицу
        routeIds = new HashSet<string>();
    }
    

    public void addRoute(Route route)
    {
        if (!routeIds.Contains(route.Id))
        {
            routes.Add(route.Id, route);
            routeIds.Add(route.Id);
        }
    }

    public void removeRoute(string routeId)
    {
        if (routeIds.Contains(routeId))
        {
            routes.Remove(routeId);
            routeIds.Remove(routeId);
        }
    }

    public bool contains(Route route)
    {
        return routeIds.Contains(route.Id);
    }

    public int size()
    {
        return routes.Size();
    }

    public Route getRoute(string routeId)
    {
        return routes.GetValueOrDefault(routeId, null);
    }

    public void chooseRoute(string routeId)
    {
        if (routeIds.Contains(routeId) && routes.TryGetValue(routeId, out var route))
        {
            route.Popularity++;
        }
    }

    public IEnumerable<Route> searchRoutes(string startPoint, string endPoint)
    {
        var matchingRoutes = routes.Values()
            .Where(route => route.LocationPoints.First() == startPoint && route.LocationPoints.Last() == endPoint)
            .OrderBy(route => route.LocationPoints.Count)  // Сортировка по количеству точек местоположения
            .ThenByDescending(route => route.Popularity)  // Сортировка по популярности в порядке убывания
            .ThenBy(route => route.Distance);  // Сортировка по расстоянию в порядке возрастания

        // Поместить избранные маршруты в начало результата
        var favoriteRoutes = matchingRoutes.Where(route => route.IsFavorite);
        var nonFavoriteRoutes = matchingRoutes.Where(route => !route.IsFavorite);

        return favoriteRoutes.Concat(nonFavoriteRoutes);
    }

    public IEnumerable<Route> getFavoriteRoutes(string destinationPoint)
    {
        var favoriteRoutes = routes.Values()
            .Where(route => route.IsFavorite && !route.LocationPoints.First().Equals(destinationPoint))
            .OrderBy(route => route.Distance)  
            .ThenByDescending(route => route.Popularity);  

        return favoriteRoutes;
    }

    public IEnumerable<Route> getTop3Routes()
    {
        var topRoutes = routes.Values()
            .OrderByDescending(route => route.Popularity)  
            .ThenBy(route => route.Distance)  
            .ThenBy(route => route.LocationPoints.Count)  
            .Take(3);  

        return topRoutes;
    }
}
