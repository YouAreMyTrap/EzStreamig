   M S B A M L   `   `   `  ���� R  NEzStreaming, Version=2.0.5.1, Culture=neutral, PublicKeyToken=54abe43435055e6e)clr-namespace:EzStreamingEzStreaming  U QSystem.Runtime, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a7,clr-namespace:System;assembly=System.RuntimeSystem *    $EzStreaming.YouTubeDownloaderWindows   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:EzStreaming     ?System,clr-namespace:System;assembly=System.Runtime     -     � 
ResizeMode$  NoResize=� � Title$1 +EzStreaming 2.1 - beta | YouTube Downlaoder��$	��361��$	��405��.��� .+��� -    ��Name$ ytlink��$
��Left=�$��	38,39,0,0q�$��Link Youtube�� �� TextWrapping$
 Wrap=�$	��Top=�$	��331��$��4��$��34���� -    ��Name$ settings_video��$
��Left=�$��	50,87,0,0q�$	��Top=�$��61��$��2��$y�Hidden=�.@��� $
��Auto�� �� 
IsSelected$
 True���� $	��mp4���� $	��mkv���� $	��m4a���� $
��webm���� -   $ settings_audio��$
��Left=�$��	38,87,0,0q�$	��Top=�$	��331��$��4��.@��� $
��Auto��$
 True���� $��bestvideo+bestaudio/best���� $��bestvideo+bestaudio���� $��bestvideo+worstaudio���� $��worstvideo+bestaudio���� $��worstvideo+worstaudio���� $!��worstvideo+worstaudio/worst���� $
��best���� $��worst���� $��	bestvideo���� $��
worstvideo���� $��	bestaudio���� $��
worstaudio���� $4��.YouTube 4K 60fps HDR AV1 + Opus WebM (701+251)���� $4��.YouTube 4K 60fps HDR VP9 + Opus WebM (337+251)���� $0��*YouTube 4K 60fps AV1 + Opus WebM (401+251)���� $0��*YouTube 4K 60fps VP9 + Opus WebM (315+251)���� $*��$YouTube 4K AV1 + Opus WebM (401+251)���� $*��$YouTube 4K VP9 + Opus WebM (313+251)���� $3��-YouTube 1440p60 HDR AV1 + Opus WebM (700+251)���� $3��-YouTube 1440p60 HDR VP9 + Opus WebM (336+251)���� $/��)YouTube 1440p60 AV1 + Opus WebM (400+251)���� $/��)YouTube 1440p60 VP9 + Opus WebM (308+251)���� $-��'YouTube 1440p AV1 + Opus WebM (400+251)���� $-��'YouTube 1440p VP9 + Opus WebM (271+251)���� $/��)YouTube 1080p60 AV1 + Opus WebM (399+251)���� $/��)YouTube 1080p60 VP9 + Opus WebM (303+251)���� $-��'YouTube 1080p60 AVC + AAC MP4 (299+140)���� $-��'YouTube 1080p AV1 + Opus WebM (399+251)���� $-��'YouTube 1080p VP9 + Opus WebM (248+251)���� $+��%YouTube 1080p AVC + AAC MP4 (137+140)���� $.��(YouTube 720p60 AV1 + Opus WebM (398+251)���� $.��(YouTube 720p60 VP9 + Opus WebM (302+251)���� $,��&YouTube 720p60 AVC + AAC MP4 (298+140)���� $,��&YouTube 720p AV1 + Opus WebM (398+251)���� $,��&YouTube 720p VP9 + Opus WebM (247+251)���� $&�� YouTube 720p AVC + AAC (136+140)���� $��1080p���� $
��720p���� -    ��Name$ bgrided��$
��Left=�$��
38,126,0,0q�$	��Top=�$��41��$	��332��$��4������  �� 
TargetType" ��.R�� .+��  �Name$ pgbarr��-   	 � Value$	 0Q�
 � Maximum$	
 100Q�$��Stretch=�$��Stretch=��� $��Downlaod��$��Stretch=�$��Stretch=�$��Center=�$��Center=��� -   $ resultTextBox��$��39,172,36,8q�$ NoWrap=� �� 
IsReadOnly$
 True��" �� VerticalScrollBarVisibility$
 Auto=�$ �� HorizontalScrollBarVisibility$
 Auto=� � Cursor$ IBeam��