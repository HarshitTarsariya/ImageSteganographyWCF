<%@ Page Title="Help" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="ImageSteganographyApplication.Help" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-3" style="font-family:monospace">
        <div class="card">
            <div class="card-header">
                <h3 class="text-center">How to use this application</h3>                
            </div>
            <div class="card-body bg-light">
                <div id="encode" class="container">
                    <h4 class="text-success">Part A: Encode</h4>
                    <hr class="bg-success"/>
                    <p class="h6 container">
                        Follow these steps for encoding:-<br /><br />
                        1) In <b>Upload Picture</b> field, select a picture of your choice to hide your message.<br />
                        2) Then, type your Secret Message and make sure that <b>NO ONE IS SEEING YOU</b>.<br />
                        3) Now, <b>Select Encryption Type</b>. You can choose either AES or DES methods of encryption.<br /> 
                        4) <b>Enter Key</b> for encrypting your message.<br />
                        5) Please remember your <b>Select Encryption Method</b> and <b>Key</b> value. Don't share it with anyone<br />
                        6) Click on the Submit button to hide the message inside the image.<br />
                        7) You will be redirected to a Preview page and download that image by clicking on Download button.<br />
                        8) Now you can share this encoded image to anyone.<br />
                        9) But to decode the message, you need to give the key and the encryption method used to that person.<br />
                       10) Refer <a href="#decode">PART B</a> for decoding the message.<br />
                    </p>
                </div>
                <div id="decode" class="container mt-3">
                    <h4 class="text-success">Part B: Decode</h4>
                    <hr class="bg-success"/>
                    <p class="h6 container">
                        Follow these steps for decoding:-<br /><br />
                        1) In <b>Upload Picture</b> field, upload the <b>*.png</b> picture shared by the sender to you.<br />
                        2) Then, <b>Select Encryption Type</b> used by the sender for encrypting the message.<br />
                        3) Now, enter the <b>Key</b> shared by the sender for decrypting the message.<br />
                        4) Click on the Submit button to see the message hidden inside the image<br />
                        5) Refer <a href="#encode">PART A</a> for encoding the message.<br />
                    </p>
                </div>                
            </div>
        </div>
    </div>

    <div class="container mt-2">
        <div class="card">
            <div class="card-header">
                <h3 class="text-center">Contact Developers</h3>
            </div>
            <div class="card-body bg-light">
                <div class="row">
                    <div class="col">
                        <img src="Content/Static/doubts.jpg" class="img-responsive" width="400" height="400" style="width: 80%;" />
                    </div>
                    <div class="col">
                        <img src="Content/Static/help.png" class="img-responsive" width="400" height="400" style="width: 75%;" />
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="col-4">
                        <div class="card text-center">
                            <div class="card-header">
                                <img class="rounded-circle img-responsive" src="Content/Static/harshit.jpg" alt="Generic placeholder image" width="200" height="200" style="width: 80%;" />
                            </div>
                            <div class="card-body bg-light">
                                <h3>Harshit Tarsariya</h3>
                                <a class="btn btn-dark" href="mailto:harshittarsariya@gmail.com" role="button">Send Mail</a>
                            </div>
                        </div>
                    </div>
                    <div class="col-4">
                        <div class="card text-center">
                            <div class="card-header">
                                <img class="rounded-circle img-responsive" src="Content/Static/janak.jpg" alt="Generic placeholder image" width="200" height="200" style="width: 80%;" />
                            </div>
                            <div class="card-body bg-light">
                                <h3>Janak Vaghasiya</h3>
                                <a class="btn btn-dark" href="mailto:janakvaghasiya97@gmail.com" role="button">Send Mail</a>
                            </div>
                        </div>
                    </div>
                    <div class="col-4">
                        <div class="card text-center">
                            <div class="card-header">
                                <img class="rounded-circle img-responsive" src="Content/Static/jayesh.jpg" alt="Generic placeholder image" width="200" height="200" style="width: 80%;" />
                            </div>
                            <div class="card-body bg-light">
                                <h3>Jayesh Zinzuvadia</h3>
                                <a class="btn btn-dark" href="mailto:jayeshzinzuvadiya099@gmail.com" role="button">Send Mail</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
