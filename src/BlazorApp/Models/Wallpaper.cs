namespace BlazorApp.Models;

public class WallpaperRoot
{
    public List<Wallpaper> Images { get; set; }
}

public class Wallpaper
{
    public DateOnly Startdate { get; set; }
    public DateTime Fullstartdate { get; set; }
    public DateOnly Enddate { get; set; }
    public string Url { get; set; }
    public string Urlbase { get; set; }
    public string Copyright { get; set; }
    public string Copyrightlink { get; set; }
    public string Title { get; set; }
    public string Quiz { get; set; }
    public string Hsh { get; set; }
}