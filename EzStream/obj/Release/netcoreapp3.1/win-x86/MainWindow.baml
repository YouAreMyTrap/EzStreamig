   M S B A M L   `   `   `  ���� F  BEzStreaming, Version=2.0.1.0, Culture=neutral, PublicKeyToken=null)clr-namespace:EzStreamingEzStreaming      EzStream.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:EzStreaming       � 
ResizeMode$  NoResize=� � Title$ EzStream 2.1 - beta��$	��450��$	��641��.��� .+��� .@��� $
��Main��.��� ���	#FFE5E5E5.+��� -    ��Name$
 lbox��$��Stretch=�$��21,45,10,24q����� .R�� $	��0,0q� � ColumnDefinitions �� $��* ��� $��20 ��� $��20 �.+��� ���� *
Channels+��  ��Name$
 btn1��-   $��1��$��20��.����  ��Name$ btn1i��$��/data/1.png���� $
 btn3��-   $��2��$��20��.���� $��/data/bt2.png���� $��Channel Name��$
��Left=�$��	21,19,0,0q�$	��Top=��� $��New User��.��� ���	#FFE5E5E5.+��� -    ��Name$ Channel_Name��$
��Left=�$��	30,20,0,0q�$��Channel Name�� �� TextWrapping$
 Wrap=�$	��Top=�$	��322��$��37��$��Normal"�$��20(��� -   $ 
stream_key��$
��Left=�$��	30,74,0,0q�$��
Stream_Key��$
 Wrap=�$	��Top=�$	��322��$��37��$��20(��� -    ��Name$ Plarfomr_sel��$
��Left=�$��
30,194,0,0q�$	��Top=�$	��159��$��37��	 �� 
IsReadOnly$
	 True��$��20(�.@��� 
 �� 
IsSelected$

 True��$��Twitch���� $��Youtube���� $��Facebook���� -    ��Name$	 cb1��$��Video��$
��Left=�$��
30,246,0,0q�$	��Top=�$��69��$	��322���� -   $	 cb2��$��Audio��$
��Left=�$��
30,283,0,0q�$	��Top=�$��70��$	��322���� -	   $��CREATE DIRECT SETTINGS��$
��Left=�$��
24,328,0,0q�$	��Top=�$��41��$	��328���� -
   $ 	Codec_sel��$
��Left=�$	��Top=�$	��158��$��37��$
	 True��$��194,194,0,0q�$��20(�.@��� $

 True��$��
h264_nvenc���� $��nvenc���� $��
nvenc_h264���� $��
nvenc_hevc���� $��hevc_amf���� $��
hevc_nvenc���� $��hevc_qsv���� $��libx264���� $��
libx264rgb���� $��libx265���� $��h264_amf���� $��
h264_vaapi���� $��h264_amf���� -   $ bittrate��$
��Left=�$��
30,131,0,0q�$��1000k��$
 Wrap=�$	��Top=�$	��159��$��37��$��20(��� -   $	 fps��$
��Left=�$��194,131,0,0q�$��30��$
 Wrap=�$	��Top=�$	��159��$��37��$��20(��� $
��Left=�$��30,4,0,0q�$��Chanel Name��$
��Wrap=�$	��Top=��� $
��Left=�$��	30,57,0,0q�$��
Stream Key��$
��Wrap=�$	��Top=��� $
��Left=�$��
30,115,0,0q�$��Bittrate��$
��Wrap=�$	��Top=��� $
��Left=�$��195,115,0,0q�$	��FPS��$
��Wrap=�$	��Top=��� $
��Left=�$��
30,178,0,0q�$��Platform��$
��Wrap=�$	��Top=��� $
��Left=�$��195,178,0,0q�$��Codec��$
��Wrap=�$	��Top=��� $��Options��.��� ���	#FFE5E5E5.+��� -   $ AutoRun��$��Auto Run EzStreaming��$
��Left=�$��	23,28,0,0q�$	��Top=� J� RenderTransformOrigin$ -0.388,-0.282&��� -   $ AutoRun2��$��Auto Run Channels��$
��Left=�$��	23,48,0,0q�$	��Top=�$ -0.388,-0.282&��� $
��Left=�$��361,348,0,0q�$��By: YAMT��$
��Wrap=�$	��Top=��� $��
Donations:��$
��Left=�$��
25,166,0,0q�$	��Top=�