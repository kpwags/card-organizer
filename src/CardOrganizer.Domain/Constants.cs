namespace CardOrganizer.Domain;

public static class Constants
{
    public enum PageState
    {
        Loading = 1,
        Ready = 2,
        Error = 3,
    }
    
    public enum CardType
    {
        Baseball = 1,
        Football = 2,
    }

    public static List<string> BaseballTeams = new List<string>()
    {
        "Arizona Diamondbacks",
        "Atlanta Braves",
        "Baltimore Orioles",
        "Boston Red Sox",
        "Chicago White Sox",
        "Chicago Cubs",
        "Cincinnati Reds",
        "Cleveland Indians",
        "Colorado Rockies",
        "Detroit Tigers",
        "Houston Astros",
        "Kansas City Royals",
        "Los Angeles Angels",
        "Los Angeles Dodgers",
        "Miami Marlins",
        "Milwaukee Brewers",
        "Minnesota Twins",
        "Montreal Expos",
        "New York Yankees",
        "New York Mets",
        "Oakland Athletics",
        "Philadelphia Phillies",
        "Pittsburgh Pirates",
        "San Diego Padres",
        "San Francisco Giants",
        "Seattle Mariners",
        "St. Louis Cardinals",
        "Tampa Bay Rays",
        "Texas Rangers",
        "Toronto Blue Jays",
        "Washington Nationals",
    };
    
    public enum ImageType
    {
        Jpeg,
        Png,
        Gif,
        Unknown
    }

    public enum CardSide
    {
        Back,
        Front,
    }
}