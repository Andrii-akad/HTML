   M S B A M L   `   `   `  ����D  @Messenger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Messenger	Messenger  5   	       Messenger.LoginForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Messenger     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  	LoginForm��5	   	   $	��450��6   $	��800��6(    � WindowStartupLocation$ CenterOwner=�64   .��5
      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    � MappingMode$ RelativeToBoundingBox=�63    �� 
StartPoint$ 0.5,0&�6W    �� RelativeTransform 5      V� 5      .~�5      ��  �� CenterY$
 0.35Q�6)    �� CenterX$	 0.8Q�68   �� 5       �� CenterY$
 0.35Q�6(   	 �� CenterX$		 0.8Q�67   
 �� AngleX$	
 -39Q�6E    �� AngleY$ 28Q�6R   �� 5       �� CenterY$
 0.35Q�6*    �� CenterX$	 0.8Q�69    �� Angle$ 21Q�6G   T� 5       T� X$ 1Q�6-    T� Y$ 1Q�63   5      .��5      �  � Color$ 	#FF0D4A74��6    � Offset$
 0.23Q�61   � 5      $ 	#FF5C4891��6   $ 0.648Q�61   � 5      $ 	#FF1F0D4F��6   $ 0.922Q�61   5      .+�5   
   �� -   5         ��Name$ 
pnlLoading��5      $��Center=�6)   $	��420��6D   
������� J� Opacity$	 0.5Q�6c    K� ZIndex$ 1��6q   $y�Hidden=�6�   �� 5   
   -   5        $��	tbLoading��5      $ 2��6%   
�������$��Center=�6I   $��40(�6f   $�� 0 180 30 180q�6t   $y�Hidden=�6�   	Loading6�   �� 5   
   $	��Top=�6   $��	0,120,0,0q�6-   $	��240��6@   .+�5      �� -   5         ��Name$ tbLogin��5      
�������$	��200��6>   $��55��6J   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Login��6V    %  !MaterialDesignFloatingHintTextBox#��[  5      $��15(�6Q   6_   G� 5      -   5         G�Name$ 
tbPassword��5      
�������$	��200��6E   $��50��6Q   $ Password��6]      
HelperText$  ��5          
Foreground �	#FF673AB7.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush �	#FF673AB7 ) %MaterialDesignFloatingHintPasswordBox#��[ 5"      $��15(�6Y   6g   �� 5#      -   5          MaterialDesignRaisedButton#��[ 5#   *   $	��120��6^   $��0 40 0 0q�6j   .��6|   Login6�   �� 5$      $	��200��6   $��30��6$    �� TextAlignment$ Center=�60   $��0 10 0 0q�6G   �� 5%      -   5         $  MaterialDesignSubtitle1Hyperlink#��[ 5%      
�������.�6�   
Registrate6�   5&      5'      5)      5*      