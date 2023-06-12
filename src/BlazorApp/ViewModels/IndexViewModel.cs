using BlazorApp.Models;

namespace BlazorApp.ViewModels;

public class IndexViewModel
{
    public async Task<List<TimeLine>> FetchDataAsync()
    {
        var items = new List<TimeLine>()
        {
            new TimeLine()
            {
                Year = 2023,
                Info = "Atom Towns",
                Desc =
                    "Construction of the town of Pripyat, one of 9 “atom towns” begins, to be inhabited by future employees of the nuclear power plants."
            },
            new TimeLine()
            {
                Year = 2022,
                Info = "Atom Towns",
                Desc =
                    "Construction of the town of Pripyat, one of 9 “atom towns” begins, to be inhabited by future employees of the nuclear power plants."
            },
            new TimeLine()
            {
                Year = 2021,
                Info = "Atom Towns",
                Desc =
                    "Construction of the town of Pripyat, one of 9 “atom towns” begins, to be inhabited by future employees of the nuclear power plants."
            },
            new TimeLine()
            {
                Year = 2020,
                Info = "Atom Towns",
                Desc =
                    "Construction of the town of Pripyat, one of 9 “atom towns” begins, to be inhabited by future employees of the nuclear power plants."
            },
            new TimeLine()
            {
                Year = 2019,
                Info = "Atom Towns",
                Desc =
                    "Construction of the town of Pripyat, one of 9 “atom towns” begins, to be inhabited by future employees of the nuclear power plants."
            },
            new TimeLine()
            {
                Year = 2018,
                Info = "Atom Towns",
                Desc =
                    "Construction of the town of Pripyat, one of 9 “atom towns” begins, to be inhabited by future employees of the nuclear power plants."
            },
            new TimeLine()
            {
                Year = 2027,
                Info = "Atom Towns",
                Desc =
                    "Construction of the town of Pripyat, one of 9 “atom towns” begins, to be inhabited by future employees of the nuclear power plants."
            },
        };

        return await Task.FromResult(items);
    }
}