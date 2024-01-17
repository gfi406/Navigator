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
            return false;

        Route other = (Route)obj;
        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"Маршрут: {Id}, Расстояние: {Distance}, Популярность: {Popularity}, Фаворит: {IsFavorite}, Маршруты: [{string.Join(", ", LocationPoints)}]";
    }

}
