using BlazorApp.Models;

namespace BlazorApp.ViewModels;

public class IndexViewModel
{
    public async Task<List<TimeLine>> FetchDataAsync()
    {
        var items = new List<TimeLine>()
        {
            new()
            {
                Year = "2022 — Present",
                Info = "Consultant",
                Desc = "As a consultant in thoughtworks, mainly committed to the transformation and upgrading of outdated systems."
            },
            new()
            {
                Year = "2019 — 2022",
                Info = ".NET Backend Developer",
                Desc =
                    "From Beijing to Wuhan, I worked as a developer for two companies and accumulated a lot of experience in .net core development."
            },
            new()
            {
                Year = "2016 — 2019",
                Info = "WPF Developer",
                Desc =
                    "Worked as a WPF developer in a traditional company, mainly engaged in the research and development of video surveillance related products."
            },
            new()
            {
                Year = "2015 — 2016",
                Info = "UAP Developer",
                Desc = "Work as an intern in a game company in Wuhan and accumulate work experience"
            }
        };

        return await Task.FromResult(items);
    }
}