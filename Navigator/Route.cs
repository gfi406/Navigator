public class Route
{
    public string Id { get; set; }
    public double Distance { get; set; }
    public int Popularity { get; set; }
    public bool IsFavorite { get; set; }
    public List<string> LocationPoints { get; set; }
   
    public Route(string id, double distance, int popularity, bool isFavorite, List<string> locationPoints)
    {
        Id = id;
        Distance = distance;
        Popularity = popularity;
        IsFavorite = isFavorite;
        LocationPoints = locationPoints;
    }
   
    public override bool Equals(object obj)
    {

        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Route other = (Route)obj;

        return Distance == other.Distance && 
            LocationPoints[0] == other.LocationPoints[0] && // это 1я точка 
            LocationPoints[LocationPoints.Count - 1] == other.LocationPoints[other.LocationPoints.Count - 1]; // это последняя 
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + Id.GetHashCode();
            hash = hash * 23 + Distance.GetHashCode();
            hash = hash * 23 + IsFavorite.GetHashCode();

           
            foreach (var point in LocationPoints)
            {
                hash = hash * 23 + point.GetHashCode();
            }

            return hash;
        }
    }

    public override string ToString()
    {
        return $"Маршрут: {Id}, Расстояние: {Distance}, Популярность: {Popularity}, Фаворит: {IsFavorite}, Маршруты: [{string.Join(", ", LocationPoints)}]";
    }

}
