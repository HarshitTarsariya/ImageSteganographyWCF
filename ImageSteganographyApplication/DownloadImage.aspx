<%@ Page Title="Download Image" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DownloadImage.aspx.cs" Inherits="ImageSteganographyApplication.DownloadImage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-center pt-3">Preview Image</h3>
    <div class="container">
        <div class="card m-1 bg-light">
            <div class="card-body text-center">
                <div class="row">
                    <div class="col form-group">
                        <img src="Content/Static/decode.png" alt="Default PNG Image" class="img-responsive imageThumbnail" />
                    </div>
                </div>                
                <form id="form1" runat="server">
                    <div class="row">
                        <div class="col form-group">
                            <asp:Button ID="BackToEncodePage" runat="server" Text="Back" CssClass="btn btn-dark mr-1" OnClick="BackToEncodePage_Click"></asp:Button>
                            <asp:Button ID="DownloadEncodedImage" runat="server" Text="Download" CssClass="btn btn-dark" OnClick="DownloadEncodedImage_Click"></asp:Button>
                        </div>
                    </div>
                </form>                
            </div>
        </div>
    </div>
</asp:Content>
