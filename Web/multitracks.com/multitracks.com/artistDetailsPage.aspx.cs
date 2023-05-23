using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class artistDetailsPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var sql = new SQL();

        try
        {
            //sql.Parameters.Add("@stepID", 1);
            var data = sql.ExecuteStoredProcedureDT("spGetArtistDetails1");

            for (int i = 0; i <= data.Rows.Count - 1; i++)
            {
                DataRow dr = data.Rows[i];

                Image1.ImageUrl = dr[3].ToString();
                Image2.ImageUrl = dr[2].ToString();
                Image3.ImageUrl = dr[9].ToString();
                Image12.ImageUrl = dr[9].ToString();
                Image13.ImageUrl = dr[9].ToString();
                SongTitle1.Text = dr[5].ToString();
                Albumtitle1.Text = dr[8].ToString();
                BPM.Text = dr[6].ToString();
                albumtitle2.Text = dr[8].ToString();
                BPM2.Text = dr[6].ToString();
                albumtitle3.Text = dr[8].ToString();
                BPM3.Text = dr[6].ToString();
                Image4.ImageUrl = dr[9].ToString();
                Image5.ImageUrl = dr[9].ToString();
                Image6.ImageUrl = dr[9].ToString();
                Image7.ImageUrl = dr[9].ToString();
                Image8.ImageUrl = dr[9].ToString();
                Image9.ImageUrl = dr[9].ToString();
                Image10.ImageUrl = dr[9].ToString();
                Image11.ImageUrl = dr[9].ToString();
                SongTitle4.Text = dr[5].ToString();
                SongTitle5.Text = dr[5].ToString();
                SongTitle6.Text = dr[5].ToString();
                SongTitle7.Text = dr[5].ToString();
                SongTitle8.Text = dr[5].ToString();
                SongTitle9.Text = dr[5].ToString();
                SongTitle10.Text = dr[5].ToString();
                SongTitle11.Text = dr[5].ToString();
                biography.Text = dr[1].ToString();


            }

        }
        catch
        {

        }

    }
}
    