using System;
using System.Collections.Generic;
using System.Linq;

public class Navigator : INavigator
{
    private Htable routes; 
    private HashSet<string> routeIds;

    public Navigator()
    {
        routes = new Htable(); 
        routeIds = new HashSet<string>();
    }
    

    public void addRoute(Route route)
    {
        string routeKey = $"{route.LocationPoints.First()}-{route.LocationPoints.Last()}-{route.Distance}";

       // Console.WriteLine(routeKey.ToString());

        if (!routeIds.Contains(routeKey))
        {
            if (!routes.Values().Any(existingRoute => existingRoute.Equals(route)))
            {
                routes.Add(route.Id, route);
                routeIds.Add(routeKey);
            }
        }
        else
        {
            // А по ебалу?
            Console.WriteLine($"Маршрут '{routeKey}' уже есть");
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
        try
        {
            return routes.GetValueOrDefault(routeId, null);
        }
        catch
        {
            Console.WriteLine("Маршрут не найден");
            return null;
        }
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
            .OrderBy(route => route.LocationPoints.Count)  
            .ThenByDescending(route => route.Popularity) 
            .ThenBy(route => route.Distance);  
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
