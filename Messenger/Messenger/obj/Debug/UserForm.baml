   M S B A M L   `   `   `  ����D  @Messenger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Messenger	Messenger  5   	       Messenger.UserForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Messenger     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  UserForm��5	   	   $	��450��6   $	��800��6'    � AllowsTransparency .  � WindowStyle$
 None=�6N   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    � MappingMode$ RelativeToBoundingBox=�63    �� 
StartPoint$ 0.5,0&�6W    �� RelativeTransform 5      V� 5      .~�5      ��  �� CenterY$
 0.35Q�6)   	 �� CenterX$		 0.8Q�68   �� 5      
 �� CenterY$

 0.35Q�6(    �� CenterX$	 0.8Q�67    �� AngleX$	 -39Q�6E    �� AngleY$ 28Q�6R   �� 5       �� CenterY$
 0.35Q�6*    �� CenterX$	 0.8Q�69    �� Angle$ 21Q�6G   T� 5       T� X$ 1Q�6-    T� Y$ 1Q�63   5      .��5      �  � Color$ 	#FF0D4A74��6    � Offset$
 0.23Q�61   � 5      $ 	#FF5C4891��6   $ 0.648Q�61   � 5      $ 	#FF1F0D4F��6   $ 0.922Q�61   5      .+�5   
   �� -   5        $��pnlImg��5      .+�5      A� $	��200��6   $	��200��6"   $	��Top=�6/   $
��Left=�6G   $��	80 50 0 0q�6b   ��5       �� 5!      -   5        	image�� j� Stretch$ UniformToFill=�5!   0    �� ImageSource 6H   �� *Image+5#      5$      �� 5%   
   -   5        $��pnlInfo��5%   %   $��1��6   .+�5&      ��  �� 
IsReadOnly . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Id��6(   $��	0 50 0 30q�6`   $
��Auto��6s   $
��Left=�6�   $��Bottom=�5'      
�������$��20(�6=    %  !MaterialDesignFloatingHintTextBox#��[  6K   ��5&   L   �� *Id+5'   K   �� 5(       . $
 Name��6(   $��0 0 0 30q�6d   $
��Auto��6v   $
��Left=�6�   $��Bottom=�5)      
�������$��20(�6=   #��[  6K   ��5(   N   �� *Name+5)   K   �� 5*       . $ E-mail��6(   $��0 0 0 30q�6g   $
��Auto��6y   $
��Left=�6�   $��Bottom=�5+      
�������$��20(�6=   #��[  6K   ��5*   P   �� *Email+5+   K   5,      �� 5-   
   $��2��6   $��Bottom=�6)   $��40q�6D    �� Orientation$ 
Horizontal=�6P   .+�5.      �� -   5         ��Name$ 	btnDelete��5.      $	��170��6(   $��150 0 100 0q�6P   .��6e   Delete Contact50      �� 51      -   5        $ btnAdd��51      $	��170��6%   .��6J   Add to contacts53      54      �� 55   
   -   5        $��1��55      $	��Top=�6!   $��Right=�69   $��45��6U   $��63��6a   ���	#FFA4A4E2 J� Opacity$	 0.2Q�56   (   .��57      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ CloseOutline=�6&   
�������$��Center=�6M   $��42��6j   $��58��6v   58      59      5:      