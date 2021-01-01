using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridView();
        }
    }

    protected void BindGridView()
    {
        DataTable dt = SampleDataTable();

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView_Button_Click(object sender, EventArgs e)
    {
        //Determine the RowIndex of the Row whose Button was clicked.
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

        //Get the value of column from the DataKeys using the RowIndex.
        int id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]);
        string group = GridView1.DataKeys[rowIndex].Values[1].ToString();

        Label1.Text = id.ToString();
        Label2.Text = group;

    }


    protected DataTable SampleDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Id"), new DataColumn("Group"), new DataColumn("Name"), new DataColumn("Country") });
        dt.Rows.Add(1, "A", "John Hammond", "United States");
        dt.Rows.Add(2, "B", "Mudassar Khan", "India");
        dt.Rows.Add(3, "A", "Suzanne Mathews", "France");
        dt.Rows.Add(4, "B", "Robert Schidner", "Russia");
        dt.Rows.Add(5, "B", "Dale Roberts", "Russia");
        dt.Rows.Add(6, "C", "Bena Mudra", "India");
        dt.Rows.Add(7, "B", "Galilahi Fala", "India");
        dt.Rows.Add(8, "C", "Una Kanti", "India");

        return dt;
    }



    protected void Button3_Click(object sender, EventArgs e)
    {
        SaveToHtml();
    }

    protected void SaveToHtml()
    {
       
        string htmlOutput = Server.UrlDecode(HiddenField1.Value);     
        
        htmlOutput = string.Join(" ", System.Text.RegularExpressions.Regex.Split(htmlOutput, @"(?:\r\n|\n|\r|\t)"));
        htmlOutput = htmlOutput.Replace("\"", "'");

        string headerStyle = HeaderStyle();

        string finalHtml = headerStyle + htmlOutput;
               
        Response.Clear();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment; filename=exampleHtml.html");
        Response.ContentType = "text/plain";
        Response.Write(finalHtml);
        Response.End();

    }

    protected string HeaderStyle()
    {
        string headerStyle = @"<!DOCTYPE html>

       <html xmlns='http://www.w3.org/1999/xhtml'>
       <head runat='server'>
    <title></title>
    <style>
        .otr {
            text-align: center;
        }

        .inr {
            width: 90%;
        }

        .btn3 {
            background-color: #666699; /* Green */
            color: white;
            text-align: center;
            text-decoration: none;
            font-size: 15px;
            cursor: pointer;
            transition-duration: 0.4s;
            border: none;
        }

            .btn3:hover {
                box-shadow: 0 4px 6px 0 rgba(0,0,0,0.17),0 6px 8px 0 rgba(0,0,0,0.18);
                background-color: #9999FF;
            }


             </style>
            </head>";

        return headerStyle;
    }

}