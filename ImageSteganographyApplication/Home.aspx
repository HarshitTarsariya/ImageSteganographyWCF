<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ImageSteganographyApplication.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container text-center" style="font-family:monospace">
        <h2 class="m-4">Welcome to Image Steganography</h2>
        <hr />
        <img src="Content/Static/steganography.jpg" width="500" height="350" />
    </div>
    <br />
    <div class="container" style="font-family:monospace">
        <div class="card-header shadow">
            <h3>
                What is Steganography ?
            </h3>
            <hr />
            <h5>Steganography is method of hiding data in the some medium which is called cover.<br />
                It is like data is hidden under the cover which can be Image , Audio, Video, etc. Hiding in image is the most easy way for implementing the Steganography.<br />
            </h5>
        </div>
        <br />
        <div class="card-header shadow">
            <h3>
               Why Hiding under a image is easy ?
            </h3>
            <hr />
            <h5>
                The reason behind is how the digital image is constructed.We can describe a digital image as a finite set of digital values, called pixels. Pixels are the smallest individual element of an image, holding values that represent the brightness of a given color at any specific point. So we can think of an image as a matrix (or a two-dimensional array) of pixels which contains a fixed number of rows and columns.
            </h5>
            <div class="row">
                <div class="col">
                    <div class="img-thumbnail">
                        <img src="Content/Static/pixels.jpg" />
                        <img src="Content/Static/rgb.png" />
                    </div>
                </div>
            </div> 
        </div>
        <br />
        <div class="card-header shadow">
            <h3>
                How Steganography is Implemented by us ?
            </h3>
            <hr />
            <h5>
                As digital image has three channels, so bits can be changed as per the data we want to hide. But changing any bits will impact the image in larger way and both original and encoded image can be differentiated. So the solution is to change only the last bit of each channel which contributes less in the image visualization.
            </h5>
            <div class="row">
                <div class="col">
                    <div class="img-thumbnail">
                        <img src="Content/Static/lastbit.png" />
                    </div>
                </div>
            </div> 
            <br />
            <h5>
                So in total the bits that can be stored in image is limited to $${Image_Height * Image_Width * 3}$$ 
                But we have compressed the message to certain extent so our steganography will be able to store more than above specified.
            </h5>
            <div class="row">
                <div class="col">
                    <div class="img-thumbnail">
                        <img src="Content/Static/diff1.png" />
                        <img src="Content/Static/diff2.png" />
                        <br />
                        <h5>
                            Here one of it is encoded with data, but they can't be differentiated as image is encoded using LSB(Least Significant bit) technique.
                        </h5>
                    </div>
                    
                </div>
            </div> 
        </div>
        <br />
        <div class="card-header shadow">
            <h3>
               Is there any security flaw in this ?
            </h3>
            <hr />
            <h5>
                If someone knows that the current image is encoded then they can reverse the process and can know the data which is hidden.
                So to avoid such situation we have used data encryption standards like <b>AES</b> and <b>DES</b> which are much secure. So the image which is encoded has the data hidden in it is encrypted and can only be decrypted if the attacker knows the private Key. 
            </h5>
        </div>
        <br />
        <div class="card-header shadow">
            <h3>
               So where this system practically used ?
            </h3>
            <hr />
            <h5>
                The major use of this system is in the digital watermarking of images to stop getting pirated. Other usage are for secure communication over certain public channels.
            </h5>
        </div>
    </div>
</asp:Content>
