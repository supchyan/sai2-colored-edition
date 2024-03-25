1. `C0 C0 C0` → `0x001BC95B` → Inactive text.
2. `C0 C0 C0` → `0x00534688` → Inactive canvas and minimap's backgrounds.
3. `B0 B0 B0` → `0x0053468C` → Background behind layers UI.
4. `B0 B0 B0` → `0x0018838B` `0x001880AC` `0x0018A004` `0x0001AE93` → Active canvas background. *has artifacts*
5. `B0 B0 B0 00` → `section .text` → Artifacts fixes for `4`.
6. `F8 F8 F8` → `0x00534678` `0x0053467C` → Global UI borders.
7. `E0 E0 E0` → `0x00534680` → Brushes UI outlines.
8. `D0 D0 D0` → `0x00534684` → Brushes separator.
9. `F8 F8 F8` → `0x005349D0` → Topbar.
10. `00 00 00` → `0x00534A98` `0x00534AA0` `0x00534AA8` → Topbar text. [ idle, hovered, focused ]
11. `F8 F8 F8` → `0x00534B60` → Context menu.
12. `00 00 00` → `0x00534C18` `0x00534C20` `0x00534C28` → Context menu text. [ idle, hovered, focused ]
13. `F8 F8 F8` → `0x00534ED8` `0x00535018` → Slider's outline. [ horizontal, vertical ]
14. `F8 F8 F8` → `0x00535068` `0x005350C0` → Slider's arrows. [ up, down ] *no left and right arrows* 
15. `F8 F8 F8` → `0x00535280` → Windows resize grabber.
16. `F8 F8 F8` → `0x00535CD8` `0x00535E28` → Tabs resize grabber. [ horizontal, vertical ]
17. `F8 F8 F8` → `0x005370D0` → Behind tree background in File menu.
18. `F8 F8 F8` → `0x00536C00` → Scale & Angle under minimap.
19. `FF FF FF` → `0x0031B4B8` → InActive sliders background. *also active lists background somewhere*
20. `FF FF FF` → `0x0031B498` `0x0031B49C` → Active sliders background. [ idle, hovered and focused ]
21. `C0 C0 C0` → `0x0031B4C0` → Sliders body.
22. `FF FF FF` → `0x003709B0` → Backgrounds in Lists, File Menu, Bookmarks.
23. `FF FF FF` → `0x00535568` `0x00535590` `0x005355E0` → Top left buttons. [ minimize, maximize, close ]
24. `FF FF FF` → `0x0053644C` → Radio Buttons background.
25. `00 00 00` → `0x00370A40` `0x00370B30` → File menu text. [ in lists, in tiles ]
26. `00 00 00` → `0x00370760` → Brushes text.
27. `FF FF FF FF` → `section .srclibs` → Backgrounds in Brushes, File menu, Scroll blocks. *has artifacts, but no artifacts, when all channels has the same value*
28. `F2 F2 F2 00` → `section .srclibs` → Burger buttons outline.
29. `F4 F4 F4 00` → `section .srclibs` → Burger buttons outline.
30. `E4 E4 E4 00` → `section .srclibs` → Burger buttons outline. *has artifacts*
31. `E0 E0 E0 00` → `section .srclibs` → Burger buttons outline.
32. `E8 E8 E8 00` → `section .srclibs` → Burger buttons outline, scroll bars background.
33. `F0 F0 F0 00` → `section .srclibs` → InActive scroll bars background.
34. `F8 F8 F8 00` → `section .srclibs` → Radio buttons "mask artifacts" fix, burger buttons background. *has artifacts*
35. `DA DA DA 00` → `section .srclibs` → Burger buttons outline, sliders outline.
36. `F0 F0 F0 F0` → `section .appskin` → Empty elements in brushes UI.
37. `F8 F8 F8 F8` → `section .appskin` → Color picker circle. *has artifacts*
38. `F8 F8 F8 F8` → `section .srclibs` → Burger buttons background, sliders outlines, list outlines. *has artifacts*
39. `F8 F8 F8 F8` → `from 0x004DD400 to 0x004FC2AF` → Burger buttons background, sliders outlines, list outlines. Alternative painting for `38`.
40. `00 00 00 00` → `0x003706D0` → Brushes text.
41. `00 00 00 00` → `0x00370900` → Brushes size text.
42. `00 00 FF` → `0x00370768` → Blue brushes text. ( selection brushes )
43. `40 80 20 00` → `section .srclibs` → "Shit" colored text. *good to replace as well in section .appskin* 
44. `DB DB FF`  → `section .srclibs` → Selected objects background. [ idle ]
45. `D4 D4 FF` → `section .srclibs` → Selected objects background. [ Active ]
46. `F6 F6 FF` → `section .srclibs` → Selected objects background. [ Hovered ]
47. `80 80 FF` → `section .srclibs` → Selected objects outline. [ ??? ]
48. `C2 C2 FF` → `section .srclibs` → Selected objects inner outline. [ Hovered ]
49. `CF CF FF` → `section .srclibs` → Selected objects inner outline. [ idle ]
50. `D4 EC FF` → `???` → Selected objects background. [ hold ]
51. `66 B5 FF` → `???` → Selected objects outline. [ hold ]
52. `BF E4 FF` → `???` → Selected objects inner outline. [ hold ]
53. `A6 A6 FF` `8E 8E FF` `DF DF F9` `E4 E4 F9` `D4 EC FF` `66 B5 FF` `BF E4 FF` `7A C0 FF` `D5 E8 FA` `9C D0 FF` → `section .srclibs` → Selected objects outline "gradient artifacts" fixes.
54. `D8 D8 D8` `F8 F8 F8` → `section .srclibs` → Sliders outline artifacts fix.