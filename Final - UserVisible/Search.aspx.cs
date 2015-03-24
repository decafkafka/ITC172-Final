using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{
    //instantiate service
    SearchServiceReference.SearchServiceClient ssc = new SearchServiceReference.SearchServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Id"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        if (!IsPostBack)
            FillArtistList();
            FillGenreList();
            FillVenueList();
    }

    protected void FillArtistList()
    {
        List<SearchServiceReference.Artist> artists = new List<SearchServiceReference.Artist>();
        artists = ssc.GetArtist().ToList();
        ddArtist.DataSource = artists;
        ddArtist.DataTextField = "ArtistName";
        ddArtist.DataValueField = "ArtistKey";
        ddArtist.DataBind();
        ddArtist.Items.Insert(0, "Choose an artist");
    }

    protected void FillGenreList()
    {
        List<SearchServiceReference.Genre> genres = new List<SearchServiceReference.Genre>();
        genres = ssc.GetGenre().ToList();
        ddGenre.DataSource = genres;
        ddGenre.DataTextField = "GenreName";
        ddGenre.DataValueField = "GenreKey";
        ddGenre.DataBind();
        ddGenre.Items.Insert(0, "Choose a genre");
    }

    protected void FillVenueList()
    {
        List<SearchServiceReference.Venue> venues = new List<SearchServiceReference.Venue>();
        venues = ssc.GetVenue().ToList();
        ddVenue.DataSource = venues;
        ddVenue.DataTextField = "VenueName";
        ddVenue.DataValueField = "VenueKey";
        ddVenue.DataBind();
        ddVenue.Items.Insert(0, "Choose a venue");
    }
    protected void ddArtist_SelectedIndexChanged(object sender, EventArgs e)
    {
        int artKey = int.Parse(ddArtist.SelectedValue.ToString());
        List<SearchServiceReference.Show> shows = ssc.GetShowsByArtist(artKey).ToList();
        GridView1.DataSource = shows.ToList();
        GridView1.DataBind();
    }
}