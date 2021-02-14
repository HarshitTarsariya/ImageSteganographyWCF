<%@ Page Title="Encode" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Encode.aspx.cs" Inherits="ImageSteganographyApplication.Encode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <h3 class="text-center pt-3">Encode</h3>
        <div class="container">
            <div class="card m-1 bg-light">
                <div class="card-body text-center">
                    <div class="row">
                        <div class="col form-group">
                            <img src="Content/Static/encode.png" alt="Default PNG Image" class="img-responsive imageThumbnail" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col form-group">
                            <label class="font-weight-bold">Upload Picture (in PNG):</label>
                        </div>
                        
                        <div class="col form-group">
                            <asp:FileUpload class="form-control-file" ID="file" onchange="loadSelectedImage()" runat="server"/>
                            <%--<input id="image_upload" class="form-control-file"
                                onchange="loadSelectedImage()" type="file" name="picture"
                                title="Upload PNG Image" />--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col form-group">
                            <label class="font-weight-bold">Type Your Message: </label>
                        </div>
                        <div class="col form-group">
                             <asp:TextBox ID="message" class="form-control" runat="server" title="Enter message here" required=""></asp:TextBox>
                            <%--<input type="text" class="form-control" name="message" title="Enter message here" required="" />--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col form-group">
                            <label class="font-weight-bold">Enter Key: </label>
                        </div>
                        <div class="col form-group">
                             <asp:TextBox ID="key" class="form-control" runat="server" title="EnterKey" required=""></asp:TextBox>

                            <%--<input type="password" class="form-control" name="key" title="Enter key here" required="" />--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col form-group">
                            <%-- Reset is done by the HTML tags --%>
                            <button type="reset" class="btn btn-dark mr-1">Reset</button>
                            <asp:Button ID="EncodeSubmitButton" runat="server" Text="Submit" CssClass="btn btn-dark" OnClick="EncodeSubmitButton_Click"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <div class="row" style="position: absolute; top: 250px; right: 300px">
        <div class="col-10">
            <div class="ufo">
                <div class="monster" style="color: #7cb342">
                    <div class="body">
                        <div class="ear"></div>
                        <div class="ear"></div>
                        <div class="vampi-mouth">
                            <div class="vampi-tooth"></div>
                        </div>
                    </div>
                    <div class="eye-lid">
                        <div class="eyes">
                            <div class="eye"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-2">
            <b>Check if no one's seeing !!</b>
        </div>
    </div>
    <script src="Scripts/ufo_script.js"></script>
    <script type="text/javascript" src="Scripts/load_selected_image.js"></script>
</asp:Content>
