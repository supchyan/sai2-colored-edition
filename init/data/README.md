## Table of the all colors and it's place in binary I found for `2024.02.22` patch:
|Num|Color|Address|Description|Warnings|
|:---:|:---:|:---:|:---|:---|
|1| `C0C0C0`|`0x001BC95B`|Inactive text.|
|2| `C0C0C0`|`0x00534688`|Inactive canvas and minimap's backgrounds.|
|3| `B0B0B0`|`0x0053468C`|Background behind layers UI.|
|4.1| `B0B0B0`|`0x0018838B`|Active canvas background.| *has artifacts, but has fix below* |
|4.2| `B0B0B0`|`0x001880AC`|Active canvas background.| *has artifacts, but has fix below* |
|4.3| `B0B0B0`|`0x0018A004`|Active canvas background.| *has artifacts, but has fix below* |
|4.4| `B0B0B0`|`0x0001AE93`|Active canvas background.| *has artifacts, but has fix below* |
|5| `B0B0B000`|`section .text`|Artifacts fixes for `4`.|
|6.1| `F8F8F8`|`0x0053467C`|Global UI borders.|
|6.2| `F8F8F8`|`0x00534678`|Global UI borders.|
|7| `E0E0E0`|`0x00534680`|Brushes UI outlines.|
|8| `D0D0D0`|`0x00534684`|Brushes separator.|
|9| `F8F8F8`|`0x005349D0``0x00537D50``0x0053B150``0x005316E0`|Topbar.|
|10.1| `000000`|`0x00534A98``0x005317A8``0x00537E18``0x0053B218`|Topbar text. [ idle ]|
|10.2| `000000`|`0x00534AA0``0x005317B0``0x00537E20``0x0053B220`|Topbar text. [ hovered ]|
|10.3| `000000`|`0x00534AA8``0x005317B8``0x00537E28``0x0053B228`|Topbar text. [ focused ]|
|11| `F8F8F8`|`0x00534B60``0x00537EE0``0x0053B2E0``0x00531870`|Context menu.|
|12.1| `000000`|`0x00534C18``0x00531928``0x0053B398``0x00537F98`|Context menu text. [ idle ]|
|12.2| `000000`| `0x00534C20``0x00531930``0x0053B3A0``0x00537FA0`|Context menu text. [ hovered ]|
|12.3| `000000`|`0x00534C28``0x00531938``0x0053B3A8``0x00537FA8`|Context menu text. [ focused ]|
|13.1| `F8F8F8`|`0x00534ED8`|Slider's outline. [ horizontal ]|
|13.2| `F8F8F8`|`0x00535018`|Slider's outline. [ vertical ]|
|14.1| `F8F8F8`|`0x00535068`|Scroll bar arrow up.|
|14.2| `F8F8F8`|`0x005350C0`|Scroll bar  arrow down.|
|14.3|`FFFFFF`|`0x00534F28`|Scroll bar arrow left.|
|14.4|`FFFFFF`|`0x00534F80`|Scroll bar arrow right.|
|15| `F8F8F8`|`0x00535280`|Windows resize grabber.|
|16.1| `F8F8F8`|`0x00535CD8`|Tabs resize grabber. [ horizontal ]|
|16.2| `F8F8F8`|`0x00535E28`|Tabs resize grabber. [ vertical ]|
|17| `F8F8F8`|`0x005370D0`|Behind tree background in File menu.|
|18| `F8F8F8`|`0x00536C00`|Scale & Angle under minimap.|
|19| `FFFFFF`|`0x0031B4B8`|InActive sliders background.|*also active lists background somewhere*|
|20| `FFFFFF`|`0x0031B498`|Active sliders background. [ idle ]|
|20| `FFFFFF`|`0x0031B49C`|Active sliders background. [ hovered and focused ]|
|21| `C0C0C0`|`0x0031B4C0`|Sliders body.|
|22| `FFFFFF`|`0x003709B0`|Backgrounds in Lists, File Menu, Bookmarks.|
|23.1| `FFFFFF`|`0x00535568`|Top left buttons. [ minimize ]|
|23.2| `FFFFFF`|`0x00535590`|Top left buttons. [ maximize ]|
|23.3| `FFFFFF`|`0x005355E0`|Top left buttons. [ close ]|
|24.1| `FFFFFF`|`0x00536498`|Radio Buttons background.|
|24.2| `FFFFFF`|`0x00536514`|Radio Buttons background. [ hovered ]|
|24.3| `FFFFFF`|`0x00536590`|Radio Buttons background. [ active ]|
|25.1| `000000`|`0x00370A40`|File menu text. [ in lists ]|
|25.2| `000000`|`0x00370B30`|File menu text. [ in tiles ]|
|26| `000000`|`0x00370760`|Brushes text.|
|27.1| `FFFFFF`|`section .srclibs`|Backgrounds in Brushes, File menu, Scroll blocks.|*has artifacts, but no artifacts, when all channels has the same value*|
|27.2|`E8F4FF`|`section .srclibs`|SelectableBrushesButtonsRightCLicked|
|28| `F2F2F200`|`section .srclibs`|Burger buttons outline.|
|29| `F4F4F400`|`section .srclibs`|Burger buttons outline.|
|30| `E4E4E400`|`section .srclibs`|Burger buttons outline.|*has artifacts*|
|31| `E0E0E000`|`section .srclibs`|Burger buttons outline.|
|32| `E8E8E800`|`section .srclibs`|Burger buttons outline, scroll bars background.|
|33| `F0F0F000`|`section .srclibs`|InActive scroll bars background.|
|34| `F8F8F800`|`section .srclibs`|Radio buttons "mask artifacts" fix, burger buttons background.|*has artifacts*|
|35| `DADADA00`|`section .srclibs`|Burger buttons outline, sliders outline.|
|36| `F0F0F0F0`|`section .appskin`|Empty elements in brushes UI.|
|37| `F8F8F8F8`|`section .appskin`|Color picker circle.|*has artifacts*|
|38| `F8F8F8F8`|`section .srclibs`|Burger buttons background, sliders outlines, list outlines.|*has artifacts*|
|39| `F8F8F8F8`|`from 0x004DD400 to 0x004FC2AF`|Burger buttons background, sliders outlines, list outlines. Alternative painting for `38`.|
|40| `00000000`|`0x003706D0`|Brushes text.|
|41| `00000000`|`0x00370900`|Brushes size text.|
|42| `0000FF`|`0x00370768`|Blue brushes text. ( selection brushes )|
|43| `804020`|`section .srclibs`|"Shit" colored text.|
|44.1| `DBDBFF` |`section .srclibs`|Selected objects background. [ idle ]|
|44.2| `D4D4FF`|`section .srclibs`|Selected objects background. [ active ]|
|44.3| `F6F6FF`|`section .srclibs`|Selected objects background. [ hovered ]|
|44.4| `D4ECFF`|`section .srclibs`|Selected objects background. [ focused ]|
|45.1| `8080FF`|`section .srclibs`|Selected objects outline. [ ??? ]|
|45.2| `CFCFFF`|`section .srclibs`|Selected objects inner outline. [ idle ]|
|45.3| `C2C2FF`|`section .srclibs`|Selected objects inner outline. [ hovered ]|
|45.4| `66B5FF`|`section .srclibs`|Selected objects outline. [ focused ]|
|45.5| `BFE4FF`|`section .srclibs`|Selected objects inner outline. [ focused ]|
|46.1| `A6A6FF`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|46.2| `8E8EFF`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|46.3| `DFDFF9`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|46.4| `E4E4F9`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|46.5| `D4ECFF`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|46.6| `66B5FF`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|46.7| `BFE4FF`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|46.8| `7AC0FF`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|46.9| `D5E8FA`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|46.10| `D5E8FA`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|46.11| `9CD0FF`|`section .srclibs`|Selected objects outline "gradient artifacts" fixes.|
|47| `D8D8D8`|`section .srclibs`|Sliders outline artifacts fix.|
|48| `F8F8F8`|`section .srclibs`|Sliders outline artifacts fix.|
|49| `F0F0F0`|`section .srclibs`|Empty Scroll bar background.|
|50.1| `DBDBFF`|`section .appskin`|Selected Layer background. [ idle ]|
|50.2| `D4D4FF`|`section .appskin`|Selected Layer background. [ hovered ]|
|50.3| `BDF2FF`|`section .appskin`|Selected Layer background. [ focused ]|
|50.4|`D1F6FF`|`section .appskin`|Selected Layer background. [ grabbed ]|
|51.1| `8080FF`|`section .appskin`|Selected Layer outline. [ idle / hovered ]|
|51.2| `22B1E6`|`section .appskin`|Selected Layer outline. [ focused ]|
|51.3|`B0B0B0`|`section .appskin`|Selected Layer outline fix.|
|52.1| `CFCFFF`|`section .appskin`|Selected Layer inner outline. [ idle ]|
|52.2| `C2C2FF`|`section .appskin`|Selected Layer inner outline. [ hovered ]|
|52.3| `A8EEFF`|`section .appskin`|Selected Layer inner outline. [ focused ]|
|52.4| `BFF3FF`|`section .appskin`|Selected Layer inner outline. [ grabbed ]|
|54.1| `DBF8FF`|`section .appskin`|Layer background. [ focused ]|
|54.2|`F6F6FF`|`from 0x0048E5F6 to 0x0049A6BF`|Layers background. [ hovered ]|
|54.3|`B0B0B0`|`from 0x0048E5F6 to 0x0048FB9D`|Layers background. Addition to `57.1`. [ hovered ]|
|55| `EEEE EE`|`section .srclibs`|FileMenu tree tabs.|*DON'T USE, DIDN'T FIND PATTERNS!*|
|56| `F6F6 FF`|`from 0x004880F2 to 0x00488CF1`|Hovered empty brushes.|
|57.1|`9D9DFF`|`section .srclibs`|Scrollbar Fill. [ hovered ]|
|57.2|`B5B5FF`|`section .srclibs`|Scrollbar Fill. [ focused ]|
|58.1|`5E5EEC`|`section .srclibs`|Scrollbar Outline. [ hovered ]|
|58.2|`7171F1`|`section .srclibs`|Scrollbar Outline Fix. [ hovered ]|
|58.3|`8C8CF8`|`section .srclibs`|Scrollbar Outline Fix. [ hovered ]|
|58.4|`CBCBFF`|`section .srclibs`|Scrollbar Outline Fix. [ hovered ]|*it's 4 pix on edges, so probably should be paintent to SelectablePrimary*|
|58.5|`6161FF`|`section .srclibs`|Scrollbar Outline. [ focused ]|
|58.6|`7878FF`|`section .srclibs`|Scrollbar Outline Fix. [ focused ]|
|58.7|`9F9FFF`|`section .srclibs`|Scrollbar Outline Fix. [ focused ]|
|59|`7C96E2`|`section .srclibs`|Yes No Buttons background.|
|60.1|`4267D6`|`section .srclibs`|Yes No Buttons outline.|
|60.2|`5375D9`|`section .srclibs`|Yes No Buttons outline fix.|
|60.3|`6C88DE`|`section .srclibs`|Yes No Buttons outline fix.|
|60.3|`A5B4E1`|`section .srclibs`|Yes No Buttons outline fix.|*it's 4 pix on edges, so probably should be paintent to SelectablePrimary*|
|61|`969696`|`section .srclibs`|Scrollbar Fill; Service Buttons fill.|
|62.1|`707070`|`section .srclibs`|Scrollbar outline; Service Buttons outline.|
|62.2|`7D7D7D`|`section .srclibs`|Scrollbar outline Fix; Service Buttons outline Fix.|
|62.3|`8C8C8C`|`section .srclibs`|Scrollbar outline Fix; Service Buttons outline Fix.|
|63|`FFFFFF`|`from 0x0048D018 to 0x0049927F`|Layers background.|
|63|`E3F9FF`|`section .appskin`|Layers background. [ grabbed ]|
|64.1|`EBEBEB`|`section .srclibs`|.sai file in menu below background.|
|64.2|`E7E7E7`|`section .srclibs`|.sai file in menu below background. [ hovered ]|
|65.1|`A6A6A6`|`section .srclibs`|.sai file in menu below outline.|
|65.2|`DCDCDC`|`section .srclibs`|.sai file in menu below outline. [ hovered ]|
|65.3|`B2B2B2`|`section .srclibs`|.sai file in menu below outline fix.|
|65.4|`DFDFDF`|`section .srclibs`|.sai file in menu below inner outline.|
|66|`FCFCFF`|`section .appskin`|File menu background|
|67.1|`E6E6E6`|`section .srclibs`|File menu list Elements background. [ hovered ]|
|67.2|`EDEDED`|`section .srclibs`|File menu list Elements background. [ default ]|*`deafult` means u see this on first open. like last selected item or kind of.*|
|68|`8E8E8E`|`section .srclibs`|File menu list Elements outline. [ default ]|*`deafult` means u see this on first open. like last selected item or kind of.*|
|69.1|`EEEEEE`|`section .srclibs`|File menu tree non-selected tab artifacts fix.|*`BordersFix9` Color does the same! That color isn't documented here, but doing the same job. I guess, it'll be better to find certain addresses for `#eeeeee` elements, but it's to complicated, so keep it in mind. Btw, #eeeeee is color of the burger buttons outlines, which is hidden in `section .srclibs` too.*|
|69.2|`F3F3F3`|`section .srclibs`|File menu tree non-selected tab artifacts fix.|*primary  color*|
|69.3|`A7A7A7`|`section .srclibs`|File menu tree non-selected tab artifacts fix.|*ternary  color*|
|69.4|`B8B8B8`|`section .srclibs`|File menu tree non-selected tab artifacts fix.|*ternary  color*|
|69.5|`DADADA`|`section .srclibs`|File menu tree non-selected tab artifacts fix.|*ternary  color*|
|69.5|`E2E2E2`|`section .srclibs`|File menu tree non-selected tab artifacts fix.|*ternary  color*|
|69.6|`EAEAEA`|`section .srclibs`|File menu tree non-selected tab artifacts fix.|*ternary  color*|
|69.7|`AEAEAE`|`section .srclibs`|File menu tree non-selected tab artifacts fix.|*ternary  color*|
|70|`343434`|`section .appskin`|File menu list arrows. (minimize / maximize category, such as folder)|
|71.1|`404040`|`section .srclibs`|File menu Tree text|
|71.2|`4020C0`|`section .srclibs`|File menu Tree text [ hovered ]|
|71.3|`C06040`|`section .srclibs`|File menu Tree text [ focused ]|
|72.2|`804020`|`0x000DDEC0`|Shit text in windows.|
|73.1|`000000`|`0x00534C68`|Context menu Arrows [ idle ]|
|73.2|`000000`|`0x00534C70`|Context menu Arrows [ hovered ]|
|73.3|`000000`|`0x00534C78`|Context menu Arrows [ focused ]|
|74.1|`000000`|`0x00534DA8`|Context menu Check boxes [ idle ]|
|74.2|`000000`|`0x00534DB0`|Context menu Check boxes [ hovered ]|
|74.3|`000000`|`0x00534DB8`|Context menu Check boxes [ focused ]|
|75.1|`000000`|`0x00534DE8`|Context menu Check box marks [ idle ]|
|75.2|`000000`|`0x00534DF0`|Context menu Check box marks [ hovered ]|
|75.3|`000000`|`0x00534DF8`|Context menu Check box marks [ focused ]|
|76.1|`000000`|`0x00534E28`|Context menu Radio Buttons [ empty ]|
|76.2|`000000`|`0x00534E68`|Context menu Radio Buttons [ idle ]|
|76.3|`000000`|`0x00534E70`|Context menu Radio Buttons [ hovered ]|
|76.4|`000000`|`0x00534E78`|Context menu Radio Buttons [ focused ]|
|77.1|`000000`|`0x0036FC10`|.sai file in menu below text|
|77.2|`000000`|`0x0036FC28`|.sai file in menu below text percents|
|78|`DBEFFF`|`section .srclibs`|Context Menu element selected background.|
|79|`C4E6FF`|`section .srclibs`|Context Menu element selected inner outline.|
|80|`5030FF`|`section .srclibs`|Expand Arrows, scale & angle sliders, selectable elements in settings and etc.|
|81|`4020C0`|`section .text`|Text color for all from `80`.|
|82|`C0C0C0`|`0x001BC95B`|Text color of inactive elements in UI.|
|83|`000000`|`0x00370780`|Fix for brushes multiple lines text color (check `26`).
|84|`DBDBDB`|`section .srclibs`|Burger buttons `grey outline` fix.|
|85|`C0C0C0`|`section .srclibs`|Inactive Burger buttons outline.|
|85|`C9C9C9`|`section .srclibs`|Inactive Burger buttons outline edges fix.|
|85|`CECECE`|`section .srclibs`|Inactive Burger buttons outline edges fix.|
|86|`C0C0C0`|`0x0031B4C4`|Slider bar. [ hovered / focused ]|
|87|`FFFFFF`|`0x000F9B60`|Stabilizer minimized background.|
|88|`FFFFFF`|`0x003715E0`|That buttons in layers fill. (hide / selected or what is this...)|
|90|`FFFFFF`|`0x005366C0`|Closed list arrow.|
|91.1|`D3D3FF`|`section .srclibs`|Service buttons outline fix. [ hovered ]|
|91.2|`B8B8FF`|`section .srclibs`|Service buttons outline fix. [ hovered ]|
|91.3|`8F8FFF`|`section .srclibs`|Service buttons outline. [ hovered ]|
|91.4|`8A8AFF`|`section .srclibs`|Service buttons outline. [ focused ]|
|91.5|`BBBBFF`|`section .srclibs`|Service buttons outline fix. [ focused ]|
|91.6|`9898FF`|`section .srclibs`|Service buttons outline fix. [ focused ]|
|91.7|`E3E3FF`|`section .srclibs`|Service buttons outline fix. Service buttons background [ focused ]|
|92|`DBEFFF`|`section .srclibs`|Brushes background. [ grabbed ]|
|93|`C4E6FF`|`section .srclibs`|Brushes outline. [ grabbed ]|
|94|`E5EDF5`|`section .srclibs`|Service buttons background 2.|
|95.1|`E0EAF3`|`section .srclibs`|Service buttons outline 2.|
|95.2|`D1E0EE`|`section .srclibs`|Service buttons outline 2 fix.|
|95.3|`E1E9F0`|`section .srclibs`|Service buttons outline 2 fix.|
|95.4|`D6E3F0`|`section .srclibs`|Service buttons outline 2 fix.|
|95.5|`DBE7F2`|`section .srclibs`|Service buttons outline 2 fix.|
|96.1|`multiple`|`0x0038F030`|Color circle begin.|
|96.2|`multiple`|`0x003AE315`|Color circle end.|
|96.3|`multiple`|`0x003D1B70`|Color circle begin 2.|
|96.4|`multiple`|`0x003FF9CD`|Color circle end 2.|
|96.5|`multiple`|`0x00437300`|Color circle begin 3.|
|96.6|`multiple`|`0x004852F5`|Color circle end 3.|
|96.7|`multiple`|`0x00359F90`|Color circle begin 3.|
|96.8|`multiple`|`0x0036E3C5`|Color circle end 3.|
|97.1|`303030`|`0x005352C0`|Global Top Bar (where buttons minimize/maximize/close).|
|97.2|`D0D0D0`|`0x005352B8``0x00531FC8``0x00538638``0x0053BA38`|Global Top Bar. [ inactive ]|
|98.1|`F0F0E8`|`section .appskin`|Folder background.|
|98.2|`E8E7E0`|`section .appskin`|Folder background. [ hovered ]|
|98.3|`D3E9FF` `DCEDFF`|`section .appskin`|Folder background. [ focused ]|*focused means hold mouse button on it*|
|99.1|`E8D3F2` `EBDAF3`|`section .appskin`|Folder background selected.|
|99.2|`BFDFFF` `C7E3FF`|`section .appskin`|Folder background selected. [ focused ]|
|100.1|`985AB8`|`section .appskin`|Folder outline selected.|
|100.2|`1B7BCC`|`section .appskin`|Folder outline selected. [ focused ]|
|101.1|`E2CAED`|`section .appskin`|Folder inner outline selected.|
|101.1|`DCC0EA`|`section .appskin`|Folder inner outline selected. [ hovered ]|
|101.2|`B5D8FA` `BADAFA`|`section .appskin`|Folder inner outline selected. [ focused ]|
|102|`3386CC`|`section .appskin`|Folder service buttons selected. [ focused ]|
|103|`6050FF`|`0x003703C0` `0x003703F0`|Folder arrow. [ hovered ]|
|104|`606060`|`0x003703B8`|Folder arrow. [ closed ]|
|105|`606060`|`0x003703E8`|Folder arrow. [ opened ]|
|106|`800060`|`0x000F0E86`|Folder overlay text. ( Normal, multiply and etc. stuff )|
|107|`F5F5ED` `FAFAF2`|`section .appskin`|Folder behind background.|
|108|`000000`|`0x00536D20`|Scale&Angle arrow.|
|109|`000000`|`0x00536EB8`|Color sliders arrows. (HSV / RGB / etc.)|
|110.1|`808080`|`0x00536C70`|Scale & Angle slider fill [ left ]|
|110.2|`808080`|`0x00536CC8`|Scale & Angle slider fill [ right ]|
|111|`709090`|`0x000DE017`|Grey note text in settings and etc. ("This mode doesn't support WinTab driver..." and more on)|
|112|`444488`|`0x000DDF30`|Blue note text in settings and etc. ("Coodrdinate Control Mode...")|
|113|`000000`|`0x000E81AD`|Brush circles.|
|114|`FFFFFF`|`0x0014C569``0x003413D0``0x003B0A30`|Settings left side background.|
|115|`FFFFFF`|`0x001F05BA`|Some Minimized lists background. Stablizier in the same category, but has unique address is `87`.|
|116.1|`FFFFFF`|`0x001ECC89`|Context menu lists background.|
|116.2|`FFFFFF`|`0x001ECC23`|Context menu lists separator background fix.|
|117|`FFFFFF`|`0x001B1D49`|Window titles.|
|118|`FFFFFF`|`0x001C4481`|Check boxes background.|
|119.1|`5488D7`|`section .srclibs`|Another selectable outline. [ focused ]|
|119.2|`6E9CE0`|`section .srclibs`|Another selectable outline fix 1. [ focused ]|
|119.3|`B6CBEA`|`section .srclibs`|Another selectable outline fix 2. [ focused ]|
|119.4|`D9E8F8`|`section .srclibs`|Another selectable inner outline. [ focused ]|
|119.5|`B6CDED`|`section .srclibs`|Another selectable inner outline fix. [ focused ]|
|120.1|`FFFFFF`|`0x001BC96A`|OK / CANCEL text.|
|120.2|`FFFFFF`|`0x001BC974`|OK / CANCEL text. [ hovered ]|
|120.3|`FFFFFF`|`0x001BC9B6` `0x001BC988` `0x001BC97E`|OK / CANCEL text. [ focused ]|
|120.4|`FFFFFF`|`0x001BC9A2` `0x001BC9AC` `0x001BC998`|OK / CANCEL text. [ disfocused  ]|
|120.5|`FFFFFF`|`0x001BC9C0`|OK / CANCEL text. [ inactive ]|
|121|`FFFFFF`|`0x001F2C13`|Path line in File menu background.|
|121|`FFFFFF`|`0x000E31E4`|Asset manager background.|
|122|`E0F0FF`|`0x000E31E4`|Selectable background right clicked.|
|123.1|`FCFCFC`|`from 0x004CB849 to 0x004CBB60`|Sliders background transparent. (that transparent squares color)|
|123.2|`F0F0F0`|`from 0x004CB849 to 0x004CBB60`|Sliders background transparents. (that transparent squares color)|
|123.3|`F4F4F4` `FFFFFF`|`from 0x004CB849 to 0x004CBB60`|Transparent squares in sliders Fix.|*it's literally a bug in sai, just a line inside that slider background, so... it is a color.*|
|123.4|`C0C0C0`|`from 0x004CB849 to 0x004CBB60`|Sliders bar background transparent. (that transparent squares color)|
|123.5|`D0D0D0`|`from 0x004CB849 to 0x004CBB60`|Sliders bar background transparent. (that transparent squares color)|
|123.6|`C6C6C6`|`from 0x004CB849 to 0x004CBB60`|Sliders bar background transparent line fix|*it's literally a bug in sai, just a line inside that slider background, so... it is a color.*|
|124.1|`EBF1F7`|`section .srclibs`|Burger buttons background right clicked non selected.|
|124.2|`D5E2EF` `E6EEF6` `E3EAF0` `DAE5F1`|`section .srclibs`|Burger buttons outline right clicked non selected.|
|125|`0000ff`|`0x00341188``0x00401FF8``0x003B07E8`|blue brushes text 100%|