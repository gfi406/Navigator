class Program
{
    static void Main()
    {
        
        INavigator navigator = new Navigator();
        Htable hashTable = new Htable();
       


        Route route1 = new Route("1", 100.0, 5, true, new List<string> { "CityA", "CityB", "CityC" });
        Route route2 = new Route("2", 150.0, 3, false, new List<string> { "CityA", "CityD", "CityE" });
        Route route3 = new Route("3", 120.0, 8, true, new List<string> { "CityB", "CityC", "CityF" });

        Route route4 = new Route("4", 100.0, 8, true, new List<string> { "CityA", "CityG" });
        Route route5 = new Route("5", 100.0, 8, true, new List<string> { "CityA", "CityC" });

        Route route6 = new Route("6", 180.0, 6, false, new List<string> { "CityD", "CityE", "CityF" });
        Route route7 = new Route("7", 80.0, 4, true, new List<string> { "CityG", "CityA", "CityB" });
        Route route8 = new Route("8", 200.0, 7, false, new List<string> { "CityC", "CityD", "CityE" });
        Route route9 = new Route("9", 60.0, 5, true, new List<string> { "CityA", "CityF", "CityE" });
        Route route10 = new Route("10", 60.0, 5, true, new List<string> { "CityA", "City3", "CityG" });
        Route route11 = new Route("11", 120.0, 6, false, new List<string> { "CityB", "CityD", "CityF" });
        Route route12 = new Route("12", 150.0, 8, true, new List<string> { "CityE", "CityA", "CityC" });
        Route route13 = new Route("13", 90.0, 4, false, new List<string> { "CityG", "CityB", "City3" });
        Route route14 = new Route("14", 180.0, 7, true, new List<string> { "CityD", "CityF", "CityA" });
        Route route15 = new Route("15", 100.0, 5, false, new List<string> { "CityC", "CityG", "CityE" });
        Route route16 = new Route("16", 80.0, 4, true, new List<string> { "CityA", "CityB", "City3" });
        Route route17 = new Route("17", 220.0, 9, false, new List<string> { "CityG", "CityF", "CityC" });
        Route route18 = new Route("18", 70.0, 3, true, new List<string> { "CityE", "CityB", "CityD" });
        Route route19 = new Route("19", 130.0, 6, false, new List<string> { "City3", "CityA", "CityG" });
        Route route20 = new Route("20", 110.0, 5, true, new List<string> { "CityC", "CityD", "CityF" });


        navigator.addRoute(route1);
        navigator.addRoute(route2);
        navigator.addRoute(route3);
        navigator.addRoute(route4);//
        navigator.addRoute(route5);//
        navigator.addRoute(route6);
        navigator.addRoute(route7);
        navigator.addRoute(route8);
        navigator.addRoute(route9);
        navigator.addRoute(route10);
        navigator.addRoute(route11);
        navigator.addRoute(route12);
        navigator.addRoute(route13);
        navigator.addRoute(route14);
        navigator.addRoute(route15);
        navigator.addRoute(route16);
        navigator.addRoute(route17);
        navigator.addRoute(route18);
        navigator.addRoute(route19);
        navigator.addRoute(route20);


        Console.WriteLine("Количество маршрутов в навигаторе: " + navigator.size());

        Route retrievedRoute = navigator.getRoute("2");
        if (retrievedRoute != null)
        {
            Console.WriteLine("\nПолученный маршрут: \n" + retrievedRoute.ToString());
        }
       
        
        if (navigator.contains(route2)== true)
        {
            Console.WriteLine("\nМаршрут  найден");
        }
        

        navigator.chooseRoute("1");

        IEnumerable<Route> searchResult = navigator.searchRoutes("CityA", "CityE");
        Console.WriteLine("\nРезультат поиска:");
        foreach (var route in searchResult)
        {
            Console.WriteLine($"Маршрут {route.Id} - Расстояние: {route.Distance}, Популярность: {route.Popularity}  Маршруты: [{string.Join(", ", route.LocationPoints)}]");
        }

        IEnumerable<Route> favoriteRoutes = navigator.getFavoriteRoutes("CityE");
        Console.WriteLine("\nИзбранный Маршрут:");
        foreach (var route in favoriteRoutes)
        {
            Console.WriteLine($"Маршрут {route.Id} - Расстояние: {route.Distance}, Популярность: {route.Popularity} Маршруты: [{string.Join(", ", route.LocationPoints)}]");
        }

        IEnumerable<Route> top3Routes = navigator.getTop3Routes();
        Console.WriteLine("\nToп 3 Маршрута:");
        foreach (var route in top3Routes)
        {
            Console.WriteLine($"Маршрут {route.Id} - Расстояние: {route.Distance}, Популярность: {route.Popularity} Маршруты: [{string.Join(", ", route.LocationPoints)}]");
        }

        
    }
}

