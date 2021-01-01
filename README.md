# Asp.Net-Panel-Control-to-HTML-download
Grabs all the HTML inside an Asp.Net Panel control and allows it to be downloaded.

Note: See Default2.aspx.

This works similar to printing everything in a Panel control to a printer, only it will get all the HTML and create a sample .html file that will prompt to be downloaded. Nothing is saved to the server in the process.

This started out as a way to print to PDF using PdfSharp and HtmlRenderer.PdfSharp. This did work, however, the resulting PDF is just too crude. It would probably work fine if you just needed a simple PDF. It did not handle a table or a GridView well at all. 

While researching this, the methods to grab all the html markup inside a Panel had to be grabbed on page_load during prerender. They also didn't like it if you had other controls inside the Panel that needed to be ran at the server. 

This useses javascript to grab everything inside a Panel and pass it to the codebehind. The HTML is encoded by javascript. If you don't do this, you will get the error:

https://stackoverflow.com/questions/81991/a-potentially-dangerous-request-form-value-was-detected-from-the-client

The choice is encode the HTML or turn off validation on postback. 

The CSS has to be incorporated into the resulting HTML if you want it to look like the web page you are saving. This is actually not hard. I was able to save a large form with a fairly complex GridView that had multiple header rows on it. The resulting downloaded file looked identical to the web page.

Look at the codebehind for Default2.aspx to see how the header and style tags were added to the html.

The sample GridView data was created by code from Aspsnippets:

https://www.aspsnippets.com/Articles/Using-Multiple-DataKeyNames-DataKeys-in-ASPNet-GridView-with-examples.aspx












