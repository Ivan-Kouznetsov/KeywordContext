# KeywordContext Library and Demo Applications
The KeywordContext Library is a cross-platform .NET Core 2.1 library that takes text and a keyword and gives you words related to the keyword and examples of quotes in which the keyword is used with the words the program found to be related to it. For example, if you use my other program TrademarkHistoryAnalysis and take the database of USPTO trademark data that it produces and then run a KeywordContext-based application against the goods and services identifications you will note that the word "games" is associated with electronics and computers in modern trademark applications, but in applications filed in the early 20th century it was associated with cards and balls. 
For your convenience, this repository includes a sub 100MB (to comply with Github file limits) database of trademark applications that you can try the library and demo applications with. You can also download the full database at http://dailymark.legal/downloads/uspto_archive_2019.zip
# Demo Applications
## ArticleReader
This is a command-line cross-platform .NET Core 2.1 application that reads a text file and prints phrases from the article (using a relationship threshold of 2 and an occurrence threshold of 2).
## KeywordContextCLIDemo
This is a command-line cross-platform .NET Core 2.1 application that uses an SQLite database containing trademark application data (produced by TrademarkHistoryAnalysis) and runs queries against it, showing which words the keywords you search for are related to. 
## NalpMark
This is a Windows application with a graphical interface that uses .NET Core 3.0 that uses an SQLite database containing trademark application data (produced by TrademarkHistoryAnalysis) and runs queries against it, showing which words the keywords you search for are related to. It has more search options than the command line application.
### Screenshot 
![](http://dailymark.legal/images/NalpMarkScreenshot.png)
#### Make Customizable Word Clouds
Words related to "games" between 1900 and 1950:  
![](http://dailymark.legal/images/games_1950s.png)
Words related to "games" between 2000 and present day:  
![](http://dailymark.legal/images/games_modern.png)
# Credits
The library uses [nemec's implementation of the Porter2 stemmer](https://github.com/nemec/porter2-stemmer)  
NalpMark uses [Konva JavaScript Framework](https://konvajs.org/) for word clouds