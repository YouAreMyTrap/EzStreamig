   M S B A M L   `   `   `  ����R  NEzStreaming, Version=2.0.5.0, Culture=neutral, PublicKeyToken=54abe43435055e6e)clr-namespace:EzStreamingEzStreaming  5   	   _ [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fwQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions!MaterialDesignExtensions.Controls 5   	       EzStream.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:EzStreaming     5   	   amdeQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � Title$ EzStreaming 2.2��5   	   $	��678��6!   $	��641��6.   .��5      � .+�5   
   ��   MaterialDesignTabControl#��[ 6   .@�5      �� $
��Main��6   .��5      � .+�5      ��  $  MaterialDesignSubtitle2TextBlock#��[ 6    $��Channel Name��6Z   $��32,28,434,286q�6n   
�������6�   �� 5      -   5         ��Name$
 lbox��5      $��Stretch=�6,   $��21,45,10,24q�6Q   $��4��6f   ��5      �� 5      .R�5   "   � $	��0,0q�6'    � ColumnDefinitions 5   &   �� 5   *   $��20 �6;   �� 5    *   $��* �6;   �� 5!   *   $��50 �6;   �� 5"   *   $��50 �6;   .+�5%   &   '  !MaterialDesignThemes.Wpf.PackIcon  $��0��6X      Kind 6>   �� *
Platform+6X   �� 5&   &   $��1��6J   ��60   �� *
Channels+6J   �� 5(   &    ��Name$
 btn1��6-   -   5        $��2��5(   N   .��5)   *      6B   �� *start+5*   '   �� 5+   &   $
 btn3��6-   -   5        $��3��5+   N   .��5,   *     $ Delete=�6B   5-   '   5.   #   5/      51      52      53      �� 54      $��New User��6   .��55      � .+�56      �� -   5         ��Name$ Custom��56      $��	0,38,0,56q�6-   .+�58      �� -   5        	 ��Name$	 Channel_Name��58   �   #���   6"   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Channel Name��6T    % !MaterialDesignFloatingHintTextBox#��[ 6�   $	��322��6�    �� Left$ 30��6�   
 �� Top$ 35��6�    � Cursor$ IBeam��6   .��6  ��59      �� 5:   "    �� Path$
 Name�6*    �� UpdateSourceTrigger$ PropertyChanged=�66    �� ValidationRules 5;   &   5=   #   .��5>   ,   5?      �� 5@      -   5        $	 
stream_key��5@   �   #���   6"   $
 	Steam key��6T   #��[ 6   $�� ��6�   $	��322��6�   $��37��6�   $ 30��6�   $ 74��6�   �� 5A      -   5        $ extra��5A   !   $y�Visible=�60   .+�5B      �� -	   5        $	 bittrate��5B   �   #���   6&   $
 Bittrate��6X   #��[ 6�   $��1000k��6�   $	��159��6�   $��37��6�   $ 30��6�   $	 131��6  $ IBeam��6  �� 5D      -
   5        $		 fps��5D   �   #���   6&   $	
 FPS��6X   #��[ 6}   $��30��6�   $	��159��6�   $��37��6�   $	 194��6�   $	 131��6�   �� 5E      -   5         ��Name$ Plarfomr_sel��5E   Y   #���   6'   $	��159��6o   $��37��6{    �� 
IsReadOnly$
 True��6�   $ 30��6�   $	 184��6�    & "MaterialDesignFloatingHintComboBox#��[ 5F      $
 Platform��5G         
HelperText$ Select one Platform��5H      -  'MaterialDesignThemes.Wpf.ComboBoxAssist   ClassicMode$
 True��5I      .@�5J   "   ��  �� 
IsSelected$
 True��6/   $��Twitch��6A   �� 5K   "   $��Youtube��6/   �� 5L   "   $��Facebook��6/   �� 5M   "   $��Trovo��6/   5O      �� 5P      -   5        $ 	Codec_sel��5P   Y   #���   6'   $	��158��6l   $��37��6x   $
 True��6�   $	 194��6�   $	 184��6�   #��[ 5Q      $
 Codec��5R      $ Select one Codec��5S      $
 True��5T      .@�5U   "   �� $��
h264_nvenc��6/   �� 5V   "   $��libx264��6/   5W      �� 5X      -   5        $ Preset��5X   Y   #���   6'   $	��158��6i   $��37��6u   $
 True��6�   $��20(�6�   $	 381��6�   $	 220��6�   ${�False��6�   $y�Hidden=�6�   .@�5Y   "   �� $��	ultrafast��6/   �� 5Z   "   $��	superfast��6/   �� 5[   "   $��veryfast��6/   �� 5\   "   $��faster��6/   �� 5]   "   $
��fast��6/   �� 5^   "   $
 True��6/   $��medium��6A   �� 5_   "   $
��slow��6/   �� 5`   "   $��slower��6/   �� 5a   "   $��veryslow��6/   �� 5b   "   $��placebo��6/   5c      5d      �� 5e      -   5         ��Name$	 cb1��5e   U   #���   6#   $��Video��6b   $��20��6r   $	��322��6~   $	 380��6�   $ 42��6�   �� 5f      -   5        $	 cb2��5f   U   #���   6#   $��Audio��6b   $��24��6r   $	��322��6~   $	 380��6�   $ 92��6�   �� 5g      -   5        $ 
Resolution��5g   U   #���   6#   $	��159��6i   $��37��6u   $
 True��6�   $	 380��6�   $	 181��6�   #��[ 5h      $
 
Resolution��5i      $ Select one Resolution��5j      $
 True��5k      .@�5l      �� $��	1920:1080��6+   �� 5m      $
 True��6+   $��1280:720��6=   �� 5n      $��640:480��6+   5p      �� 5q      -   5        $ ytvideo��5q   U   #���   6#   $��Youtube Video��6f   $��20��6~   $	��322��6�   $	 380��6�   $ 67��6�   �� 5r      -   5        $ ytaudio��5r   U   #���   6#   $��Youtube Audio��6f   $��20��6~   $	��322��6�   $	 380��6�   $	 116��6�   $y�Hidden=�6�   �� 5t      -   5        $ bgrided��5t   !     MaterialDesignRaisedButton#��[ 5u      3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   IsIndicatorVisible$ False��6Q      IsIndeterminate$
 True��6�   $
��Make��6�   $��165,501,174,72q�6�   $
 Hand��6�   $	��247��6   5w      �� 5y      -   5        $ default_presets��5y   �    " MaterialDesignOutlinedComboBox#��[ 6   #���   6W   $
��Left=�6�   $��	10,10,0,0q�6�   $	��Top=�6�   $	��612��6�   $��LeftToRight=�6$  .@�5z      �� $(��"MusicStreamer/MassStreamer by viri��6'   �� 5{      $9��3MusicStreamer/MassStreamer by viri - MOD GPU NVIDEA��6'   �� 5|      $6��0MusicStreamer/MassStreamer by viri - MOD GPU AMD��6'   �� 5}      $ ��autoStreamerv2 - Grand Bob��6'   �� 5~      $��
GPU NVIDEA��6'   ${�False��6<   �� 5      $��GPU AMD��6'   ${�False��69   �� 5�      $	��CPU��6'   ${�False��65   �� 5�      $
 True��6'   $��Custom��69   5�      �� 5�      -   5        $	 ytlink_video��5�      $
��Left=�64   $��250,101,0,0q�6O   $��Link Youtube��6d    �� TextWrapping$
 Wrap=�6x   $	��Top=�6�   $	��230��6�   $��1��6�   $y�Hidden=�6�   �� 5�      -   5        $	 ytlink_audio��5�      $
��Left=�64   $��250,171,0,0q�6O   $��Link Youtube��6d   $
 Wrap=�6x   $	��Top=�6�   $	��230��6�   $��1��6�   $y�Hidden=�6�   5�      5�      �� 5�      $��Options��6   .��5�      � .+�5�      ��  $	  MaterialDesignHeadline3TextBlock#��[	 6    $��About��6Z   #���   6g   $��18,291,475,250q�6�   �� 5�      $��18,364,515,201q�6     $
  MaterialDesignHeadline6TextBlock#��[
 68   �� 5�      -   5        #��� ��5�   %   $6��0https://www.paypal.com/biz/fund?id=65SX2HLAZBQWU?�5�   $    � Cursor$
 Hand��6c   .�6�   PayPal5�      5�      �� 5�      $��18,389,515,176q�6    #��[
 68   �� 5�      -   5        #��� ��5�   %   $#��https://discord.gg/YpjxxDVK8x?�5�   $   $
 Hand��6P   .�6w   	Discord5�      5�      �� 5�      $��18,413,515,152q�6    #��[
 68   �� 5�      -   5        #��� ��5�   %   $1��+https://github.com/YouAreMyTrap/EzStreamig/?�5�   $   $
 Hand��6^   .�6�   GitHub5�      5�      �� 5�      $��
Donations:��6   $
��Left=�61   $��
12,166,0,0q�6L   $	��Top=�6`   $y�Hidden=�6x   $��2��6�   $��1��6�   )  #MaterialDesignThemes.Wpf.DialogHost  5�      -   5          Name$ 
DialogHost��5�   0      DialogContent 5�      �� 5�      $��20q�6)   .+�5�   "   �� -   5        $	 discordkey_text_dialog��5�   *   #���   6J   $
 Set Discord key��6|   #��[ 6�   $�� ��6�   $	��322��6�   $��37��6�   $ 30��6  $ 74��6  �� 5�   "   -   5        $
��Save��5�   )     MaterialDesignFlatButton#��[ 68   $��0 8 8 0q�6j   6{   5�      5�      �� 5�      -   5        $ autostart_button_save��5�      $
��Save��6<   $
��Left=�6K   $��387,184,0,0q�6f   $	��Top=�6{   $	��210��6�    J� RenderTransformOrigin$ -0.25,-0.198&�6�   $y�Visible=�6�   $��37��6�   �� 5�      -   5        $��tbMultiLine��5�   �   #���   6    ! MaterialDesignOutlinedTextBox#��[ 6P   $%
 Write Channels Name for AutoRun��6�   $
��Left=�6�   $
 Wrap=�6�    �� AcceptsReturn$
 True��6
  $��
387,23,0,0q�6  $	��Top=�63  $	��210��6K  $	��154��6W  $y�Visible=�6d  $ IBeam��6y  �� 5�      -   5        $ VerifyFiles��5�      $��Check Files��62   $
��Left=�6H   $��173,205,0,0q�6c   $	��Top=�6x   6�   �� 5�      -    5        $ CheckUpdates��5�      $��Check Updates��63   $
��Left=�6K   $��
18,205,0,0q�6f   $	��Top=�6z   6�   �� 5�       �� Orientation$ 
Horizontal=�6!   $��12,22,435,542q�6:   .+�5�      d� -!   5          d�Name$  togglebutton_DiscordBot��5�   '   $��8 0 16 0q�6H   6Z   �� 5�      -"   5        ! ��Name$! discord_text_togle��5�   $   $��Center=�6@   $��Discord Bot��6[   #��[
 6n   #���   6�   5�      �� 5�      $ 
Horizontal=�6!   $��12,57,321,507q�6:   .+�5�      d� -#   5        $%  togglebutton_AutoRunEzStreaming��5�   '   $��8 0 16 0q�6P   6b   �� 5�      $��Center=�6$   $��Auto Run EzStreaming��6?   #��[
 6[   #���   6�   5�      �� 5�      $ 
Horizontal=�6!   $��12,92,375,472q�6:   .+�5�      d� -$   5        $"  togglebutton_AutoRunChannels��5�   '   $��8 0 16 0q�6M   6_   �� 5�      $��Center=�6$   $��Auto Run Channels��6?   #��[
 6X   #���   6�   5�      �� 5�      $ 
Horizontal=�6!   $��12,127,304,437q�6:   .+�5�      d� -%   5        $  togglebutton_StartVerify��5�   '   $��8 0 16 0q�6I   6[   �� 5�      $��Center=�6$   $��Verify update on start?��6?   #��[
 6^   #���   6�   5�      5�      5�      �� 5�      -&   5        " ��Name$" discordtabitem��5�      $��Discord Bot��6.   $y�Hidden=�6C   .��5�      � .+�5�      �� -'   5        $	 resultTextBox��5�      #���   5�      #��[ 5�      $
 Discord Bot Commands��5�      $��
39,18,36,8q�5�      $ NoWrap=�5�      # �� 
IsReadOnly$
# True��5�      "$ �� VerticalScrollBarVisibility$
$ Auto=�5�      $% �� HorizontalScrollBarVisibility$
% Auto=�5�      $ IBeam��5�      5�      5�      5�      '  !MaterialDesignThemes.Wpf.Snackbar  5�   
   -(   5        &  Name$& SnackbarFour��5�   "   '   MessageQueue' 68   4  .MaterialDesignThemes.Wpf.MessageQueueExtension  5�      5�      