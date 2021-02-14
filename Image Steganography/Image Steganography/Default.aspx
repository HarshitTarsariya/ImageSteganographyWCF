<%@ Page Title="Steganography" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Image_Steganography._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row" style="position:absolute;bottom:200px;right:170px">
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
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    <div class="container">
            <asp:TextBox ID="message" runat="server"></asp:TextBox>
            <asp:FileUpload ID="file" runat="server"/>
            <asp:Button runat="server" OnClick="Unnamed1_Click" />
    </div>

            
<script>
    let ufo = document.querySelector('.ufo');
    ufo.addEventListener('mousemove', (e) => {
        let eyes = document.querySelector('.eyes');
        let mouseX = (eyes.getBoundingClientRect().left);
        let mouseY = (eyes.getBoundingClientRect().top);
        let radianDegrees = Math.atan2(e.pageX - mouseX, e.pageY - mouseY);
        let rotationDegrees = (radianDegrees * (180 / Math.PI) * -1) + 180;
        eyes.style.transform = `rotate(${rotationDegrees}deg)`
    });
</script>

</asp:Content>

