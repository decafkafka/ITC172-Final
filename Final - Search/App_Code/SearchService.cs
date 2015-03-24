using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SearchService" in code, svc and config file together.
public class SearchService : ISearchService
{
    ShowTrackerEntities ste = new ShowTrackerEntities();
    public List<Artist> GetArtist()
    {
        var artists = from a in ste.Artists
                      orderby a.ArtistName
                      select new { a.ArtistName, a.ArtistKey };

        List<Artist> artistsObj = new List<Artist>();
        foreach (var a in artists)
        {
            Artist art = new Artist();
            art.ArtistName = a.ArtistName;
            art.ArtistKey = a.ArtistKey;
            artistsObj.Add(art);
        }
        return artistsObj;
    }
    public List<Genre> GetGenre()
    {
        var genres = from g in ste.Genres
                     orderby g.GenreName
                     select new { g.GenreName, g.GenreKey };

        List<Genre> genresObj = new List<Genre>();
        foreach (var g in genres)
        {
            Genre gen = new Genre();
            gen.GenreName = g.GenreName;
            gen.GenreKey = g.GenreKey;
            genresObj.Add(gen);
        }
        return genresObj;
    }

    public List<Venue> GetVenue()
    {
        var venues = from v in ste.Venues
                     orderby v.VenueName
                     select new { v.VenueName, v.VenueKey };

        List<Venue> venuesObj = new List<Venue>();
        foreach (var v in venues)
        {
            Venue ven = new Venue();
            ven.VenueName = v.VenueName;
            ven.VenueKey = v.VenueKey;
            venuesObj.Add(ven);
        }
        return venuesObj;
    }
    public List<Show> GetShowsByArtist(int artKey)
    {
        var shows = from s in ste.Shows
                    join sd in ste.ShowDetails on s.ShowKey equals sd.ShowKey
                    join a in ste.Artists on sd.ArtistKey equals a.ArtistKey
                    where a.ArtistKey == artKey
                    orderby s.ShowDate
                    select new { s.ShowDate, s.ShowDateEntered, s.ShowKey, s.ShowName, s.ShowTicketInfo, s.ShowTime, s.VenueKey };

        List<Show> showsObj = new List<Show>();
        foreach (var s in shows)
        {
            Show sh = new Show();
            sh.ShowDate = s.ShowDate;
            sh.ShowDateEntered = s.ShowDateEntered;
            sh.ShowKey = s.ShowKey;
            sh.ShowName = s.ShowName;
            sh.ShowTicketInfo = s.ShowTicketInfo;
            sh.ShowTime = s.ShowTime;
            sh.VenueKey = s.VenueKey;
            showsObj.Add(sh);
        }
        return showsObj;
    }
}