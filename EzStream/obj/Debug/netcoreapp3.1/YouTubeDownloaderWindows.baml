   M S B A M L   `   `   `  ����R  NEzStreaming, Version=2.0.5.0, Culture=neutral, PublicKeyToken=54abe43435055e6e)clr-namespace:EzStreamingEzStreaming  5   	   U QSystem.Runtime, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a7,clr-namespace:System;assembly=System.RuntimeSystem 5   	   *    $EzStreaming.YouTubeDownloaderWindows   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:EzStreaming     5   	   ?System,clr-namespace:System;assembly=System.Runtime     5   	   -   5          � 
ResizeMode$  NoResize=�5	   	    � Title$1 +EzStreaming 2.1 - beta | YouTube Downlaoder��5
   	   $	��361��6=   $	��405��6J   .��5      � .+�5   
   �� -   5         ��Name$ ytlink��5      $
��Left=�6"   $��	38,39,0,0q�6=   $��Link Youtube��6P    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��331��6�   $��4��6�   $��34��6�   6�   �� 5   
   -   5         ��Name$ settings_video��5      $
��Left=�6+   $��	50,87,0,0q�6F   $	��Top=�6Y   $��61��6q   $��2��6|   $y�Hidden=�6�   .@�5      �� $
��Auto��6    �� 
IsSelected$
 True��6*   �� 5      $	��mp4��6   �� 5      $	��mkv��6   �� 5      $	��m4a��6   �� 5      $
��webm��6   5      �� 5   
   -   5        $ settings_audio��5      $
��Left=�6+   $��	38,87,0,0q�6F   $	��Top=�6Y   $	��331��6q   $��4��6}   .@�5      �� $
��Auto��6   $
 True��6*   �� 5      $��bestvideo+bestaudio/best��6   �� 5      $��bestvideo+bestaudio��6   �� 5      $��bestvideo+worstaudio��6   �� 5      $��worstvideo+bestaudio��6   �� 5      $��worstvideo+worstaudio��6   �� 5      $!��worstvideo+worstaudio/worst��6   �� 5      $
��best��6   �� 5      $��worst��6   �� 5      $��	bestvideo��6   �� 5      $��
worstvideo��6   �� 5       $��	bestaudio��6   �� 5!      $��
worstaudio��6   �� 5"      $4��.YouTube 4K 60fps HDR AV1 + Opus WebM (701+251)��6   �� 5#      $4��.YouTube 4K 60fps HDR VP9 + Opus WebM (337+251)��6   �� 5$      $0��*YouTube 4K 60fps AV1 + Opus WebM (401+251)��6   �� 5%      $0��*YouTube 4K 60fps VP9 + Opus WebM (315+251)��6   �� 5&      $*��$YouTube 4K AV1 + Opus WebM (401+251)��6   �� 5'      $*��$YouTube 4K VP9 + Opus WebM (313+251)��6   �� 5(      $3��-YouTube 1440p60 HDR AV1 + Opus WebM (700+251)��6   �� 5)      $3��-YouTube 1440p60 HDR VP9 + Opus WebM (336+251)��6   �� 5*      $/��)YouTube 1440p60 AV1 + Opus WebM (400+251)��6   �� 5+      $/��)YouTube 1440p60 VP9 + Opus WebM (308+251)��6   �� 5,      $-��'YouTube 1440p AV1 + Opus WebM (400+251)��6   �� 5-      $-��'YouTube 1440p VP9 + Opus WebM (271+251)��6   �� 5.      $/��)YouTube 1080p60 AV1 + Opus WebM (399+251)��6   �� 5/      $/��)YouTube 1080p60 VP9 + Opus WebM (303+251)��6   �� 50      $-��'YouTube 1080p60 AVC + AAC MP4 (299+140)��6   �� 51      $-��'YouTube 1080p AV1 + Opus WebM (399+251)��6   �� 52      $-��'YouTube 1080p VP9 + Opus WebM (248+251)��6   �� 53      $+��%YouTube 1080p AVC + AAC MP4 (137+140)��6   �� 54      $.��(YouTube 720p60 AV1 + Opus WebM (398+251)��6   �� 55      $.��(YouTube 720p60 VP9 + Opus WebM (302+251)��6   �� 56      $,��&YouTube 720p60 AVC + AAC MP4 (298+140)��6   �� 57      $,��&YouTube 720p AV1 + Opus WebM (398+251)��6   �� 58      $,��&YouTube 720p VP9 + Opus WebM (247+251)��6   �� 59      $&�� YouTube 720p AVC + AAC (136+140)��6   �� 5:      $��1080p��6   �� 5;      $
��720p��6   5<      �� 5=   
   -   5         ��Name$ bgrided��5=      $
��Left=�6"   $��
38,126,0,0q�6=   $	��Top=�6Q   $��41��6i   $	��332��6u   $��4��6�   ��5>      �� 5?       �� 
TargetType" ��6"   .R�5@      � .+�5A      �  �Name$ pgbarr��6&   -   5        	 � Value$	 0Q�5A   6   
 � Maximum$	
 100Q�6@   $��Stretch=�6N   $��Stretch=�6j   6�   �� 5B      $��Downlaod��6    $��Stretch=�63   $��Stretch=�6O   $��Center=�6m   $��Center=�6�   5C      5D      5F      �� 5G   
   -   5        $ resultTextBox��5G      $��39,172,36,8q�5H      $ NoWrap=�5I       �� 
IsReadOnly$
 True��5J      " �� VerticalScrollBarVisibility$
 Auto=�5K      $ �� HorizontalScrollBarVisibility$
 Auto=�5L       � Cursor$ IBeam��5M      5N      5O      