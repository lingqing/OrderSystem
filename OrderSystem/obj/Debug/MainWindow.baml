   M S B A M L   `   `   `  ����F  BOrderSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:OrderSystemOrderSystem  5   	       OrderSystem.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:OrderSystem     5   	     � Title$  
MainWindow��5   	    � Icon$ Assets/orderm.ico��5	   	    � WindowState$ 	Maximized=�5
   	    � 
ResizeMode$ NoResize=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      $��4* �6   �� 5      $��* �6   .+�5   
   � -   5        $��	TopHeader��5      $��2��6    $��Center=�5      $	��100��5      ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0,0.5&�67   .��5      �  � Color$ 	#FF5274EA��6#   	 � Offset$	 1Q�65   � 5      $ 	#FF1F47D1��6#   $	 0.007Q�65   5      .+�5      �� $��智能点餐系统��6   $
��Wrap=�5       $��黑体)�5!      $��50(�5"      
 �� TextAlignment$
 Center=�5#      
�������$��Center=�5$      5%      �� 5&   
   $��0��6   $��2��6%   $��1��69   $��Stretch=�5'      .+�5(       � -   5        $��MidFrame��5(      $	��400��5)        � NavigationUIVisibility$ Hidden=�5*      5+      5,      �� 5-   
   -   5        $��	FooterBar��5-      $��2��6&   
����� �$��2��6I   6_   5.      5/      