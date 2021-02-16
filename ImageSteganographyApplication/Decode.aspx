<%@ Page Title="Decode" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Decode.aspx.cs" Inherits="ImageSteganographyApplication.Decode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <h3 class="text-center pt-3">Decode</h3>
        <div class="container">
            <div class="card m-1 bg-light">
                <div class="card-body text-center">
                    <div class="row">
                        <div class="col-6 form-group">
                            <%--<asp:Image ID="preview" ImageUrl="~/Content/Static/encode.png" Width="500" Height="300" runat="server" />--%>
                            <img src="Content/Static/decode.png" alt="Default PNG Image" class="img-responsive imageThumbnail"  />
                        </div>
                        <div class="col-4">
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
                    <div class="row">
                        <div class="col form-group">
                            <label class="font-weight-bold">Upload Picture (in PNG):</label>
                        </div>
                        <div class="col form-group">
                            <input id="image_upload" class="form-control"
                                onchange="loadSelectedImage()" type="file" name="picture"
                                title="Upload PNG Image" runat="server" ClientIDMode="Static" required="required"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col form-group">
                            <label class="font-weight-bold">Select Encrytion Type:</label>
                        </div>
                        <div class="col form-group">
                            <asp:DropDownList ID="encrypt" CssClass="form-control" runat="server" >
                                <asp:ListItem Text="AES"></asp:ListItem>
                                <asp:ListItem Text="DES"></asp:ListItem>
                            </asp:DropDownList>
                            <%--<input type="text" class="form-control" name="message" title="Enter message here" required="" />--%>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col form-group">
                            <label class="font-weight-bold">Enter Key: </label>
                        </div>
                        <div class="col form-group">
                            <asp:TextBox ID="key" class="form-control" runat="server" title="EnterKey" required=""></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col form-group">
                            <%-- Reset is done by the HTML tags --%>
                            <button type="reset" class="btn btn-dark mr-1">Reset</button>
                            <asp:Button ID="DecodeSubmitButton" runat="server" Text="Submit" CssClass="btn btn-dark" OnClick="DecodeSubmitButton_Click"></asp:Button>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:Label ID="error" runat="server" ForeColor="Red" CssClass="font-weight-bold" Visible="false" >Invalid Data Provided For Decoding</asp:Label>
                        </div>
                    </div>

                    <%-- Display Output here --%>
                    <div class="row">
                        <div class="col form-group">
                            <label class="font-weight-bold">Message: </label>
                            <label id="finalmessage" runat="server"></label>
                            <%-- Display the decoded message here --%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="Scripts/ufo_script.js"></script>
    <script type="text/javascript" src="Scripts/load_selected_image.js"></script>
</asp:Content>
