   M S B A M L   `   `   `  ����D  @Messenger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Messenger	Messenger  5   	        Messenger.RegistrationForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   #localclr-namespace:Messenger  5   	     � Title$  RegistrationForm��5
   	   $	��420��6"   $	��560��6/    � WindowStartupLocation$ CenterOwner=�6;    � 
ResizeMode$ CanMinimize=�6_   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��159* �6   �� 5      $
��118* �6   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    � MappingMode$ RelativeToBoundingBox=�63    �� 
StartPoint$ 0.5,0&�6W    �� RelativeTransform 5      V� 5      .~�5      ��  �� CenterY$
 0.35Q�6)   	 �� CenterX$		 0.8Q�68   �� 5      
 �� CenterY$

 0.35Q�6(    �� CenterX$	 0.8Q�67    �� AngleX$	 -39Q�6E    �� AngleY$ 28Q�6R   �� 5       �� CenterY$
 0.35Q�6*    �� CenterX$	 0.8Q�69    �� Angle$ 21Q�6G   T� 5       T� X$ 1Q�6-    T� Y$ 1Q�63   5      .��5      �  � Color$ 	#FF0D4A74��6    � Offset$
 0.23Q�61   � 5      $ 	#FF5C4891��6   $ 0.648Q�61   � 5      $ 	#FF1F0D4F��6   $ 0.922Q�61   5      .+�5   
   �� -   5         ��Name$ panel��5      $��Right=�6$   $	��Top=�6A   $��	0,20,70,0q�6Y   $	��362��6l   $��0��6y   $	��200��6�   .+�5       �� -   5         ��Name$ tbEmail��5       
�������$	��200��6>   $��50��6J   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ E-Mail��6V    %  !MaterialDesignFloatingHintTextBox#��[  5!      $��15(�6Q   6_   �� 5"      -   5        $ tbName��5"      
�������$	��200��6=   $��50��6I   $
 Name��6U   #��[  5#      $��15(�6Q   6_   �� 5$      -   5        $ tbLogin��5$      
�������$	��200��6>   $��50��6J   $ Login��6V   #��[  5%      $��15(�6Q   6_   G� 5&      -   5         G�Name$ 
tbPassword��5&      
�������$	��200��6E   $��50��6Q   $ Password��6^      
Foreground �	#FF673AB7.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush �	#FF673AB7 ) %MaterialDesignFloatingHintPasswordBox#��[ 5(      $��15(�6Y   6g   G� 5)      -   5        $ tbPassword2��5)      
�������$	��200��6F   $��50��6R   $ Confirm Password��6^    �	#FF673AB7 �	#FF673AB7#��[ 5+      $��15(�6Y   6g   �� 5,      -   5          MaterialDesignRaisedButton#��[ 5,   .   $	��120��6b   $��0 40 0 0q�5-      .��6'   
Registrate5.      �� 5/      $	��200��6   $��30��6$    �� TextAlignment$ Center=�60   $��0 10 0 0q�6G   �� 50      -   5         $  MaterialDesignSubtitle1Hyperlink#��[ 50      
�������.�6�   Login6�   51      52      �� 53   
   $��1��6   .+�54      A� $	��200��6   $	��200��6"   $	��Top=�6/   $��0 50 0 0q�6G   ��55      �� 56      -	   5        	image�� j� Stretch$ UniformToFill=�56   0   58      �� 59      -
   5        $��btnImage��59      #��[ 6%   $��Bottom=�6Y   $	��140��6t   $��	0 50 0 80q�6�   .��5:   &   Choose Image5<      5=      5>      5?      