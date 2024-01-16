class Program
{
    static void Main()
    {
        
        INavigator navigator = new Navigator();
        Htable hashTable = new Htable();


        Route route1 = new Route("1", 100.0, 5, true, new List<string> { "CityA", "CityB", "CityC" });
        Route route2 = new Route("2", 150.0, 3, false, new List<string> { "CityA", "CityD", "CityE" });
        Route route3 = new Route("3", 120.0, 8, true, new List<string> { "CityB", "CityC", "CityF" });


        navigator.addRoute(route1);
        navigator.addRoute(route2);
        navigator.addRoute(route3);


        Console.WriteLine("Количество маршрутов в навигаторе: " + navigator.size());

        Route retrievedRoute = navigator.getRoute("2");
        if (retrievedRoute != null)
        {
            Console.WriteLine("Полученный маршрут: " + retrievedRoute.Id);
        }
        else
        {
            Console.WriteLine("Маршрут не найден");
        }

        navigator.chooseRoute("1");

        IEnumerable<Route> searchResult = navigator.searchRoutes("CityA", "CityE");
        Console.WriteLine("\nРезультат поиска:");
        foreach (var route in searchResult)
        {
            Console.WriteLine($"Маршрут {route.Id} - Расстояние: {route.Distance}, Популярность: {route.Popularity}");
        }

        IEnumerable<Route> favoriteRoutes = navigator.getFavoriteRoutes("CityE");
        Console.WriteLine("\nИзбранный Маршрут:");
        foreach (var route in favoriteRoutes)
        {
            Console.WriteLine($"Маршрут {route.Id} - Расстояние: {route.Distance}, Популярность: {route.Popularity}");
        }

        IEnumerable<Route> top3Routes = navigator.getTop3Routes();
        Console.WriteLine("\nToп 3 Маршрута:");
        foreach (var route in top3Routes)
        {
            Console.WriteLine($"Маршрут {route.Id} - Расстояние: {route.Distance}, Популярность: {route.Popularity}");
        }

    }
}

