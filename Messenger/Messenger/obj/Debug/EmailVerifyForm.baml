   M S B A M L   `   `   `  ����D  @Messenger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Messenger	Messenger  5   	       Messenger.EmailVerifyForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Messenger     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  EmailVerifyForm��5	   	   $	��450��6!   $	��800��6.   .��5
      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    � MappingMode$ RelativeToBoundingBox=�63    �� 
StartPoint$ 0.5,0&�6W    �� RelativeTransform 5      V� 5      .~�5      ��  �� CenterY$
 0.35Q�6)    �� CenterX$	 0.8Q�68   �� 5       �� CenterY$
 0.35Q�6(    �� CenterX$	 0.8Q�67   	 �� AngleX$		 -39Q�6E   
 �� AngleY$
 28Q�6R   �� 5       �� CenterY$
 0.35Q�6*    �� CenterX$	 0.8Q�69    �� Angle$ 21Q�6G   T� 5       T� X$ 1Q�6-    T� Y$ 1Q�63   5      .��5      �  � Color$ 	#FF0D4A74��6    � Offset$
 0.23Q�61   � 5      $ 	#FF5C4891��6   $ 0.648Q�61   � 5      $ 	#FF1F0D4F��6   $ 0.922Q�61   5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6/   $��	0 0 0 100q�6L   .+�5      �� -   5         ��Name$ tbMail��5      
�������$	��200��6=   $��50��6I   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ E-Mail��6U   $��30q�6}    %  !MaterialDesignFloatingHintTextBox#��[  5      $��15(�6Q   �� 5      -   5          MaterialDesignRaisedButton#��[ 5      $	��120��6I    � ToolTip$/ )Resource name: MaterialDesignRaisedButton��5      $��0 40 0 0q�6I   .��6[   
Send Again5       5!      �� 5"   
   $��Bottom=�6   $��	0 0 0 100q�60   .+�5#      �� -   5        $ tbCode��5#   N      
HelperText$ Check your inbox��6   
�������$	��200��6u   $��50��5$      $ Verify Code��6"   $��15(�6O   #��[  5%      �� 5'      -   5        #��[ 5'   )   $	��120��6]   $/ )Resource name: MaterialDesignRaisedButton��5(      $��0 40 0 0q�6I   .��6[   Login5)      5+      �� 5,   
   -   5        $��50��5,   I   $��Bottom=�6T   $
��Left=�6o   $��40q�6�   ��6   0  *MaterialDesignThemes.Wpf.PackIconExtension  *ArrowLeftDropCircle+6�   5.      5/      