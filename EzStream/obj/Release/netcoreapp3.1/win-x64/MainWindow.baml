   M S B A M L   `   `   `  ���� R  NEzStreaming, Version=2.0.5.1, Culture=neutral, PublicKeyToken=54abe43435055e6e)clr-namespace:EzStreamingEzStreaming  _ [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fwQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions!MaterialDesignExtensions.Controls     EzStream.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:EzStreaming     amdeQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions     b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -      MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���   � 
ResizeMode$ NoResize=� � Title$ EzStreaming 2.2��$	��678��$	��641��.��� .+���   MaterialDesignTabControl#��[ .@��� $
��Main��.��� .+���  $  MaterialDesignSubtitle2TextBlock#��[ $��Channel Name��$��32,28,434,286q�
��������� -    ��Name$
 lbox��$��Stretch=�$��21,45,10,24q�$��4������ .R�� $	��0,0q� � ColumnDefinitions �� $��20 ��� $��* ��� $��50 ��� $��50 �.+�'  !MaterialDesignThemes.Wpf.PackIcon  $��0��   Kind �� *
Platform+�� $��1������ *
Channels+��  ��Name$
 btn1��-   $��2��.��   �� *start+�� $
 btn3��-   $��3��.��  $ Delete=��� $��New User��.��� .+��� -    ��Name$ Custom��$��	0,38,0,56q�.+��� -   	 ��Name$	 Channel_Name��#���   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Channel Name�� % !MaterialDesignFloatingHintTextBox#��[ $	��322�� �� Left$ 30��
 �� Top$ 35�� � Cursor$ IBeam��.������  �� Path$
 Name� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidationRules .���� -   $	 
stream_key��#���   $
 	Steam key��#��[ $�� ��$	��322��$��37��$ 30��$ 74���� -   $ extra��$y�Visible=�.+��� -	   $	 bittrate��#���   $
 Bittrate��#��[ $��1000k��$	��159��$��37��$ 30��$	 131��$ IBeam���� -
   $		 fps��#���   $	
 FPS��#��[ $��30��$	��159��$��37��$	 194��$	 131���� -    ��Name$ Plarfomr_sel��#���   $	��159��$��37�� �� 
IsReadOnly$
 True��$ 30��$	 184�� & "MaterialDesignFloatingHintComboBox#��[ $
 Platform��   
HelperText$ Select one Platform��-  'MaterialDesignThemes.Wpf.ComboBoxAssist   ClassicMode$
 True��.@���  �� 
IsSelected$
 True��$��Twitch���� $��Youtube���� $��Facebook���� $��Trovo���� -   $ 	Codec_sel��#���   $	��158��$��37��$
 True��$	 194��$	 184��#��[ $
 Codec��$ Select one Codec��$
 True��.@��� $��
h264_nvenc���� $��libx264���� -   $ Preset��#���   $	��158��$��37��$
 True��$��20(�$	 381��$	 220��${�False��$y�Hidden=�.@��� $��	ultrafast���� $��	superfast���� $��veryfast���� $��faster���� $
��fast���� $
 True��$��medium���� $
��slow���� $��slower���� $��veryslow���� $��placebo���� -    ��Name$	 cb1��#���   $��Video��$��20��$	��322��$	 380��$ 42���� -   $	 cb2��#���   $��Audio��$��24��$	��322��$	 380��$ 92���� -   $ 
Resolution��#���   $	��159��$��37��$
 True��$	 380��$	 181��#��[ $
 
Resolution��$ Select one Resolution��$
 True��.@��� $��	1920:1080���� $
 True��$��1280:720���� $��640:480���� -   $ ytvideo��#���   $��Youtube Video��$��20��$	��322��$	 380��$ 67���� -   $ ytaudio��#���   $��Youtube Audio��$��20��$	��322��$	 380��$	 116��$y�Hidden=��� -   $ bgrided��  MaterialDesignRaisedButton#��[ 3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   IsIndicatorVisible$ False��   IsIndeterminate$
 True��$
��Make��$��165,501,174,72q�$
 Hand��$	��247���� -   $ default_presets�� " MaterialDesignOutlinedComboBox#��[ #���   $
��Left=�$��	10,10,0,0q�$	��Top=�$	��612��$��LeftToRight=�.@��� $(��"MusicStreamer/MassStreamer by viri���� $9��3MusicStreamer/MassStreamer by viri - MOD GPU NVIDEA���� $6��0MusicStreamer/MassStreamer by viri - MOD GPU AMD���� $ ��autoStreamerv2 - Grand Bob���� $��
GPU NVIDEA��${�False���� $��GPU AMD��${�False���� $	��CPU��${�False���� $
 True��$��Custom���� -   $	 ytlink_video��$
��Left=�$��250,101,0,0q�$��Link Youtube�� �� TextWrapping$
 Wrap=�$	��Top=�$	��230��$��1��$y�Hidden=��� -   $	 ytlink_audio��$
��Left=�$��250,171,0,0q�$��Link Youtube��$
 Wrap=�$	��Top=�$	��230��$��1��$y�Hidden=��� $��Options��.��� .+���  $	  MaterialDesignHeadline3TextBlock#��[	 $��About��#���   $��18,291,475,250q��� $��18,364,515,201q� $
  MaterialDesignHeadline6TextBlock#��[
 �� -   #��� ��$6��0https://www.paypal.com/biz/fund?id=65SX2HLAZBQWU?� � Cursor$
 Hand��.�PayPal�� $��18,389,515,176q�#��[
 �� -   #��� ��$#��https://discord.gg/YpjxxDVK8x?�$
 Hand��.�	Discord�� $��18,413,515,152q�#��[
 �� -   #��� ��$1��+https://github.com/YouAreMyTrap/EzStreamig/?�$
 Hand��.�GitHub�� $��
Donations:��$
��Left=�$��
12,166,0,0q�$	��Top=�$y�Hidden=�$��2��$��1��)  #MaterialDesignThemes.Wpf.DialogHost  -     Name$ 
DialogHost��   DialogContent �� $��20q�.+��� -   $	 discordkey_text_dialog��#���   $
 Set Discord key��#��[ $�� ��$	��322��$��37��$ 30��$ 74���� -   $
��Save��  MaterialDesignFlatButton#��[ $��0 8 8 0q��� -   $ autostart_button_save��$
��Save��$
��Left=�$��387,184,0,0q�$	��Top=�$	��210�� J� RenderTransformOrigin$ -0.25,-0.198&�$y�Visible=�$��37���� -   $��tbMultiLine��#���    ! MaterialDesignOutlinedTextBox#��[ $%
 Write Channels Name for AutoRun��$
��Left=�$
 Wrap=� �� AcceptsReturn$
 True��$��
387,23,0,0q�$	��Top=�$	��210��$	��154��$y�Visible=�$ IBeam���� -   $ VerifyFiles��$��Check Files��$
��Left=�$��173,205,0,0q�$	��Top=��� -    $ CheckUpdates��$��Check Updates��$
��Left=�$��
18,205,0,0q�$	��Top=���  �� Orientation$ 
Horizontal=�$��12,22,435,542q�.+�d� -!     d�Name$  togglebutton_DiscordBot��$��8 0 16 0q��� -"   ! ��Name$! discord_text_togle��$��Center=�$��Discord Bot��#��[
 #���   �� $ 
Horizontal=�$��12,57,321,507q�.+�d� -#   $%  togglebutton_AutoRunEzStreaming��$��8 0 16 0q��� $��Center=�$��Auto Run EzStreaming��#��[
 #���   �� $ 
Horizontal=�$��12,92,375,472q�.+�d� -$   $"  togglebutton_AutoRunChannels��$��8 0 16 0q��� $��Center=�$��Auto Run Channels��#��[
 #���   �� $ 
Horizontal=�$��12,127,304,437q�.+�d� -%   $  togglebutton_StartVerify��$��8 0 16 0q��� $��Center=�$��Verify update on start?��#��[
 #���   �� -&   " ��Name$" discordtabitem��$��Discord Bot��$y�Hidden=�.��� .+��� -'   $	 resultTextBox��#���   #��[ $
 Discord Bot Commands��$��
39,18,36,8q�$ NoWrap=�# �� 
IsReadOnly$
# True��"$ �� VerticalScrollBarVisibility$
$ Auto=�$% �� HorizontalScrollBarVisibility$
% Auto=�$ IBeam��'  !MaterialDesignThemes.Wpf.Snackbar  -(   &  Name$& SnackbarFour��'   MessageQueue' 4  .MaterialDesignThemes.Wpf.MessageQueueExtension  