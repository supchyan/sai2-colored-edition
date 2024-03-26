## Table of the all colors and it's place I found in sai2's binaries.
|Number |Color |Address |Description |Warnings |
|:---:  |:---: |:---:   |:---        |:---     |
|1| `C0 C0 C0`|`0x001BC95B`|Inactive text.|
|2| `C0 C0 C0`|`0x00534688`|Inactive canvas and minimap's backgrounds.|
|3| `B0 B0 B0`|`0x0053468C`|Background behind layers UI.|
|4.1| `B0 B0 B0`|`0x0018838B`|Active canvas background.| *has artifacts* |
|4.2| `B0 B0 B0`|`0x001880AC`|Active canvas background.| *has artifacts* |
|4.3| `B0 B0 B0`|`0x0018A004`|Active canvas background.| *has artifacts* |
|4.4| `B0 B0 B0`|`0x0001AE93`|Active canvas background.| *has artifacts* |
|5| `B0 B0 B0 00`|`section .text`|Artifacts fixes for `4`.|
|6| `F8 F8 F8`|`0x00534678` `0x0053467C`|Global UI borders.|
|7| `E0 E0 E0`|`0x00534680`|Brushes UI outlines.|
|8| `D0 D0 D0`|`0x00534684`|Brushes separator.|
|9| `F8 F8 F8`|`0x005349D0`|Topbar.|
|10.1| `00 00 00`|`0x00534A98`|Topbar text. [ idle ]|
|10.2| `00 00 00`|`0x00534AA0`|Topbar text. [ hovered ]|
|10.3| `00 00 00`|`0x00534AA8`|Topbar text. [ focused ]|
|11| `F8 F8 F8`|`0x00534B60`|Context menu.|
|12.1| `00 00 00`|`0x00534C18`|Context menu text. [ idle ]|
|12.2| `00 00 00`| `0x00534C20`|Context menu text. [ hovered ]|
|12.3| `00 00 00`|`0x00534C28`|Context menu text. [ focused ]|
|13.1| `F8 F8 F8`|`0x00534ED8`|Slider's outline. [ horizontal ]|
|13.2| `F8 F8 F8`|`0x00535018`|Slider's outline. [ vertical ]|
|14.1| `F8 F8 F8`|`0x00535068`|Slider arrow up.|*no left and right arrows*| 
|14.2| `F8 F8 F8`|`0x005350C0`|Slider arrow down.|*no left and right arrows*|
|15| `F8 F8 F8`|`0x00535280`|Windows resize grabber.|
|16.1| `F8 F8 F8`|`0x00535CD8`|Tabs resize grabber. [ horizontal ]|
|16.2| `F8 F8 F8`|`0x00535E28`|Tabs resize grabber. [ vertical ]|
|17| `F8 F8 F8`|`0x005370D0`|Behind tree background in File menu.|
|18| `F8 F8 F8`|`0x00536C00`|Scale & Angle under minimap.|
|19| `FF FF FF`|`0x0031B4B8`|InActive sliders background.|*also active lists background somewhere*|
|20| `FF FF FF`|`0x0031B498`|Active sliders background. [ idle ]|
|20| `FF FF FF`|`0x0031B49C`|Active sliders background. [ hovered and focused ]|
|21| `C0 C0 C0`|`0x0031B4C0`|Sliders body.|
|22| `FF FF FF`|`0x003709B0`|Backgrounds in Lists, File Menu, Bookmarks.|
|23.1| `FF FF FF`|`0x00535568`|Top left buttons. [ minimize ]|
|23.2| `FF FF FF`|`0x00535590`|Top left buttons. [ maximize ]|
|23.3| `FF FF FF`|`0x005355E0`|Top left buttons. [ close ]|
|24| `FF FF FF`|`0x0053644C`|Radio Buttons background.|
|25.1| `00 00 00`|`0x00370A40`|File menu text. [ in lists ]|
|25.2| `00 00 00`|`0x00370B30`|File menu text. [ in tiles ]|
|26| `00 00 00`|`0x00370760`|Brushes text.|
|27| `FF FF FF FF`|`section .srclibs`|Backgrounds in Brushes, File menu, Scroll blocks.|*has artifacts, but no artifacts, when all channels has the same value*|
|28| `F2 F2 F2 00`|`section .srclibs`|Burger buttons outline.|
|29| `F4 F4 F4 00`|`section .srclibs`|Burger buttons outline.|
|30| `E4 E4 E4 00`|`section .srclibs`|Burger buttons outline.|*has artifacts*|
|31| `E0 E0 E0 00`|`section .srclibs`|Burger buttons outline.|
|32| `E8 E8 E8 00`|`section .srclibs`|Burger buttons outline, scroll bars background.|
|33| `F0 F0 F0 00`|`section .srclibs`|InActive scroll bars background.|
|34| `F8 F8 F8 00`|`section .srclibs`|Radio buttons "mask artifacts" fix, burger buttons background.|*has artifacts*|
|35| `DA DA DA 00`|`section .srclibs`|Burger buttons outline, sliders outline.|
|36| `F0 F0 F0 F0`|`section .appskin`|Empty elements in brushes UI.|
|37| `F8 F8 F8 F8`|`section .appskin`|Color picker circle.|*has artifacts*|
|38| `F8 F8 F8 F8`|`section .srclibs`|Burger buttons background, sliders outlines, list outlines.|*has artifacts*|
|39| `F8 F8 F8 F8`|`from 0x004DD400 to 0x004FC2AF`|Burger buttons background, sliders outlines, list outlines. Alternative painting for `38`.|
|40| `00 00 00 00`|`0x003706D0`|Brushes text.|
|41| `00 00 00 00`|`0x00370900`|Brushes size text.|
|42| `00 00 FF`|`0x00370768`|Blue brushes text. ( selection brushes )|
|43| `40 80 20 00`|`section .srclibs`|"Shit" colored text.|
|44.1| `DB DB FF` |`section .srclibs`|Selected objects background. [ idle ]|
|44.2| `D4 D4 FF`|`section .srclibs`|Selected objects background. [ active ]|
|44.3| `F6 F6 FF`|`section .srclibs`|Selected objects background. [ hovered ]|
|44.4| `D4 EC FF`|`section .srclibs`|Selected objects background. [ focused ]|
|45.1| `80 80 FF`|`section .srclibs`|Selected objects outline. [ ??? ]|
|45.2| `CF CF FF`|`section .srclibs`|Selected objects inner outline. [ idle ]|
|45.3| `C2 C2 FF`|`section .srclibs`|Selected objects inner outline. [ hovered ]|
|45.4| `66 B5 FF`|`section .srclibs`|Selected objects outline. [ focused ]|
|45.5| `BF E4 FF`|`section .srclibs`|Selected objects inner outline. [ focused ]|
|46.1| `A6 A6 FF`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|46.2| `8E 8E FF`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|46.3| `DF DF F9`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|46.4| `E4 E4 F9`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|46.5| `D4 EC FF`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|46.6| `66 B5 FF`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|46.7| `BF E4 FF`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|46.8| `7A C0 FF`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|46.9| `D5 E8 FA`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|46.10| `D5 E8 FA`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|46.11| `9C D0 FF`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|47| `D8 D8 D8`|`section .srclibs`|Sliders outline artifacts fix.|
|48| `F8 F8 F8`|`section .srclibs`|Sliders outline artifacts fix.|
|49| `F0 F0 F0`|`section .srclibs`|Empty Scroll bar background.|
|50.1| `DB DB FF`|`section .srclibs`|Selected Layer background. [ idle ]|
|50.2| `D4 D4 FF`|`section .srclibs`|Selected Layer background. [ hovered ]|
|50.3| `BD F2 FF`|`section .srclibs`|Selected Layer background. [ focused ]|
|51.1| `80 80 FF`|`section .srclibs`|Selected Layer outline. [ idle / hovered ]|
|51.2| `22 B1 E6`|`section .srclibs`|Selected Layer outline. [ focused ]|
|52.1| `CF CF FF`|`section .appskin`|Selected Layer inner outline. [ idle ]|
|52.2| `C2 C2 FF`|`section .appskin`|Selected Layer inner outline. [ hovered ]|
|52.3| `A8 EE FF`|`section .appskin`|Selected Layer inner outline. [ focused ]|
|54| `DB F8 FF`|`section .appskin`|Layer Background Focused.|
|55| `EE EE EE`|`section .srclibs`|FileMenu tree tabs.|*DON'T USE, DIDN'T FIND PATTERNS!*|
|56| `F6 F6 FF`|`from 0x004880F2 to 0x00488CF1`|Hovered empty brushes.|
|57| `F6 F6 FF` `B0 B0 B0`|`from 0x0048E5F6 to 0x0048FB9D`|Hovered Layers.|