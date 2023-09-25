# **CodeQuotes**

Another in-depth project led by Hector Perez on his Udemy course: *.NET MAUI course with Visual Studio 2022 creating PROJECTS*

The XAML on this project is fairly simple, with one Grid container holding the code for the entire application. The focus of this program is placed upon a label that displays quotes, a button that displays a random quote, and the imposition of a gradient background that is also randomized by the random quote button.

There are 2 additional resources added into this project:
- *quotes.txt* is a text file placed in the Raw folder that holds all of the quotes utilized in the application
- *PTSerif-Regular.ttf* is an external font that has been added to the project's Resources and applied to the font of the program
  - This font file is given the alias *Serif* in *MauiProgram.cs*

The codebehind achieves the desired behavior as follows:
- *LoadMauiAsset()* is lifted from *MauiProgram.cs* and reads *quotes.txt*, then adds each quote to the *quotes* List\<string> Property
- *OnAppearing()* is overridden to call *LoadMauiAsset()* when the Page is loaded
- btnGenerateQuote_Clicked() is the EventHandler that achieves the functionality of the program
  - *startColor* and *endColor* are created using the *random* instance of the *Random* Class, with the use of the *FromArgb()* method of the *System.Drawing* Class
  - The *colors* Collection is created to house the colors of the gradient, and the Float *stopOffset* is created for the assignment of the offsets of each color in the gradient
  - *stops* is then declared and in a foreach loop the gradient colors are assigned to an offset
  - *gradient* is the culmination of the work so far, taking on the *stops* Collection and the EndPoint, then assigning these values to the background of Grid *background*
    - The EndPoint is set to (1,1), which heads from the top-left to the bottom-right
  - Finally, Label *quote* is given a random quote by way of the Property *quotes* being accessed using a randomly generated index
