
# Image Steganography: Hiding an Data inside Image

## Pre-requisites
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* ASP.net
* [WCF](https://docs.microsoft.com/en-us/dotnet/framework/wcf/)
  
## Usage

```
csc ImageSteganographyHost.exe
```

Then, start the Client:

```
Directly from Visual Studio
```


### What is steganography ?

> [Steganography](https://en.wikipedia.org/wiki/Steganography) is method of hiding data in the some medium which is called cover.
                It is like data is hidden under the cover which can be Image , Audio, Video, etc. Hiding in image is the most easy way for implementing the Steganography.

<br/>

### Why Hiding under a image is easy ?
>The reason behind is how the digital image is constructed.We can describe a digital image as a finite set of digital values, called pixels. Pixels are the smallest individual element of an image, holding values that represent the brightness of a given color at any specific point. So we can think of an image as a matrix (or a two-dimensional array) of pixels which contains a fixed number of rows and columns.
![](https://raw.githubusercontent.com/HarshitTarsariya/ImageSteganographyWCF/main/ImageSteganographyApplication/Content/Static/pixels.jpg)![](https://raw.githubusercontent.com/HarshitTarsariya/ImageSteganographyWCF/main/ImageSteganographyApplication/Content/Static/rgb.png)

<br/>

### How Steganography is Implemented by us ?
>As digital image has three channels, so bits can be changed as per the data we want to hide. But changing any bits will impact the image in larger way and both original and encoded image can be differentiated. So the solution is to change only the last bit of each channel which contributes less in the image visualization.
![](https://raw.githubusercontent.com/HarshitTarsariya/ImageSteganographyWCF/main/ImageSteganographyApplication/Content/Static/lastbit.png)

<br/>

So in total the bits that can be stored in image is limited to (Image_Height * Image_Width * 3) 
                But we have compressed the message to certain extent so our steganography will be able to store more than above specified.

<br/>

### Here one of it is encoded with data, but they can't be differentiated as image is encoded using LSB(Least Significant bit) technique.
>![](https://raw.githubusercontent.com/HarshitTarsariya/ImageSteganographyWCF/main/ImageSteganographyApplication/Content/Static/diff1.png)![](https://raw.githubusercontent.com/HarshitTarsariya/ImageSteganographyWCF/main/ImageSteganographyApplication/Content/Static/diff2.png)

<br/>

### Is there any security flaw in this ?
>If someone knows that the current image is encoded then they can reverse the process and can know the data which is hidden.
                So to avoid such situation we have used data encryption standards like <b>AES</b> and <b>DES</b> which are much secure. So the image which is encoded has the data hidden in it is encrypted and can only be decrypted if the attacker knows the private Key. 
    
<br/>

### So where this system practically used ?
>The major use of this system is in the digital watermarking of images to stop getting pirated. Other usage are for secure communication over certain public channels.

### Video Link : [Image Steganography](https://drive.google.com/file/d/1Gjje3s0wfGalk0vcuvAZ1E4z6c8X8nEg/view?usp=sharing)