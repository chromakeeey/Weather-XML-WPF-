   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5   	   B >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1 5   	      WpfApp1.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   'localclr-namespace:WpfApp1     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	     � Title$  
MainWindow��5	   	   $��612.5��6   $
��1024��6+    � WindowStyle$
 None=�68      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�6;   .��5      � .+�5   
   )  #MaterialDesignThemes.Wpf.DialogHost     DialogContent 5      �� 5      TEST6"   5      �� 5   
   .+�5      � $	��Top=�6   $	��120��6+   .+�5      #  MaterialDesignThemes.Wpf.Card  +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth4=�5      $��15,15,15,15q�5      .��5      � .+�5      � $
��Left=�6   $	��Top=�6:   $��90��6R   .+�5       ��  �� Orientation$ 
Horizontal=�6)   .+�5!   "   �� $
��Left=�6(   $��35��6C   $��40,0,0,0q�6O   $��Center=�6a   $��35��6|   $��wavhand.png��6�   �� 5"   "   $��Вітаємо!��6,   $��25(�6<   $
��Bold"�6J   $��Center=�6\   $��20q�6w   5#      5$      � 5%      $��Right=�6   .+�5&      �� $ 
Horizontal=�6)   .+�5'   "   �� -   5        $��0,0,15,0q�5'   )    " MaterialDesignRaisedDarkButton#��[ 5(   !   $��30��5)   !   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��5*   !   	 � ToolTip$@	 :Смена города из готового списка��5+   !   .��5,   "   �� $��Сменить город��6,   5.      �� 5/   "   -   5        $��0,0,20,0q�5/   )   #��[ 50   !   $��30��51   !   $ 15��52   !   $<	 6Добавление нового города по ID��53   !   .��54   &   �� $!��Добавить город��60   55   #   56      57      58      59      5:      �� 5;      $!��Прогноз погоды��6   $��18(�6.   $
��Bold"�6<   $��Center=�6N   $��15,0,0,0q�6i   ���	#DD8F8F8F6{   � 5<      $	��Top=�6   $	��120��6+   .+�5=        $ Depth4=�5>      $��15,7,15,-322q�5?      .��5@      �� $��Center=�6!   $ 
Horizontal=�6>   .+�5A      � $	��Top=�6   .+�5B      �� $��Center=�6)   .+�5C   "   �� -   5        
 ��Name$
 pb_Image��5C   (   $	��120��6:   $��0,20,0,0q�6G   $��Center=�6Y   $	��120��6t   $��sun.png��6�    J� Effect 5D   &   3  -System.Windows.Media.Effects.DropShadowEffect  5E   *      	Direction$ 25Q�6;      Color$ 	#FFB6C2CB��6J      ShadowDepth$ 1Q�6\      
BlurRadius$	 200Q�6l   5G   #   �� 5H   "   -   5         ��Name$ lbl_name��5H   ,    �� TextAlignment$ Center=�6>   $��-��6U   $��30(�6^   $
��Bold"�6l   $��Center=�6~   $��0,0,0,0q�6�   �� 5I   "   -   5        $ 	lbl_state��5I   ,   $ Center=�6?   $��-��6V   $��15(�6_   $
��Bold"�6m   $��Center=�6   $��0,0,0,0q�6�   
�������6�   �� 5J   "   -   5        $ lbl_temperature��5J   ,   $ Center=�6E   $��- ‎℃��6\   $��20(�6h   $
��Bold"�6v   $��Center=�6�   $��0,5,0,15q�6�   �� 5L   "   $ Center=�6,   $'��!Направление ветра��6C   $��15(�6\   $
��Bold"�6j   $��Center=�6|   $��0,0,0,0q�6�   
�������6�   �� 5M   "   -   5        $ lbl_wind��5M   ,   $ Center=�6>   $��-��6U   $��20(�6^   $
��Bold"�6l   $��Center=�6~   $��0,0,0,10q�6�   �� 5O   "   $ Center=�6,   $!��Скорость ветра��6C   $��15(�6Y   $
��Bold"�6g   $��Center=�6y   $��0,0,0,0q�6�   
�������6�   �� 5P   "   -   5        $ lbl_windspeed��5P   ,   $ Center=�6C   $��- м/с��6Z   $��20(�6g   $
��Bold"�6u   $��Center=�6�   $��0,0,0,10q�6�   �� 5R   "   $ Center=�6,   $��Давление��6C   $��15(�6S   $
��Bold"�6a   $��Center=�6s   $��0,0,0,0q�6�   
�������6�   �� 5S   "   -	   5        $ lbl_preasure��5S   ,   $ Center=�6B   $��- мм��6Y   $��20(�6e   $
��Bold"�6s   $��Center=�6�   $��0,0,0,10q�6�   5T      5U      � 5V      $��1��6   $��100, 20, 15, 15q�6/   $	��350��6H   $	��600��6X    5W        5X   "   $ 15Q�63   $	 -90Q�6C      RenderingBias$ Quality=�6S      Opacity$ .2Q�6k   $ 1Q�6x    J� OpacityMask 5Z      !� 5[   "    !� Visual 6.   ��  �� ElementName$ Border2�� � 	Resources 5]      !   LiveCharts.Wpf.ColumnSeries �� 
TargetType   LiveCharts.Wpf.Series �� Property �� Value	   LiveCharts.Wpf.Axis �� Triggers P� Property P� Value
   LiveCharts.Wpf.Separator��%i  '        '	  �     '
  !    �� 5^   "   "  6(   .�5_   &   ��  �@ StrokeThickness$ 0Q�6H   6T   �� 5`   &    �@ Stroke
 �����6O   �� 5a   &    �@ Fill
 �����6M   �� 5b   &    �@ MaxColumnWidth$ 5Q�6G   6S   5c   #   �� 5d   "   " 	 6(   .�5e   &   ��  �@	 FontSize$ 12Q�6A   6N   �� 5f   &    �@	 
Foreground �	#64FFFFFF6W    5g   &   P� 5h   *    �@	 AxisOrientation$ Y=�6M   . �5i   .   ��  �@	 IsMerged . 6X   �� 5j   .    �@	 MaxValue$ 10Q�6I   6V   5k   +   5m   #   �� 5n   "   " 
 6(   .�5o   &   ��  �@
 StrokeThickness$ 1Q�6H   6T   �� 5p   &    �@
 Stroke �	#4BFFFFFF6S    5q   &   P� 5r   *    �@
 AxisOrientation$ X=�6M   . �5s   .   ��  � {� .  6Z   �� 5t   .    �@
 Step$ 1Q�6E   6Q   5u   +   5w   #   5x       � RowDefinitions 5y      �� 5z   "   $
��Auto �60   6@   �� 5{   "   $
��Auto �60   6@   �� 5|   "   $
��.50* �60   6@   �� 5}   "   $	��.5* �60   6?   .+�5      �� -
   5         ��Name$ Border2��5   %   $��0��66   $��4��6C     �� CornerRadius$  5��6T   
�������6e   �� 5�      $��0��6%   $��3��62   ���#EB5A136[   �� 5�      $��0��6(   $ Center=�65   ! �� Padding$! 10, 10, 0, 5q�6L   
�������$��18(�6v   Статистика5�      #   LiveCharts.Wpf.CartesianChart  5�      -   5        "  Name$" 	StatChart��5�   1   $��2��6D   $��10, 0, 10, 20q�6Q   &    LiveCharts.Wpf.Charts.Base.Chart#   	Hoverable# . $   DataTooltip$ 6z   Z� 5�      �� 5�      $��3��6)   $��Center=�66   $��25, 0q�6Q   .+�5�   "   �� % J� Opacity$% .4Q�6,   $��13(�69   '%Средняя температура�� 6\    за последние дни6{   �� 5�   "   $ 
Horizontal=�6-   .+�5�   &   �� -   5        $ lbl_averagetmp��5�   0   ���#303030$��40(�6]   $��-��6k   �� 5�   &   ���#303030$��18(�6E   $��Bottom=�6S   $
��8, 6q�6n   ℃6   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      