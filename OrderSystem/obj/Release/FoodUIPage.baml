   M S B A M L   `   `   `  ���� F  BOrderSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:OrderSystemOrderSystem      OrderSystem.FoodUIPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     +localclr-namespace:OrderSystem       N� ShowsNavigationUI  .   N� Title$ 
FoodUIPage�� � 	Resources ��%    .���  � ColumnDefinitions �� $��2* ��� $��* �.+��  � Orientation$ 
Horizontal=�.+��� -   $��FoodCheckBox1��$��5q�.���� $	��250��.+��� -   $��
FoodImage1��$	��180����  �� Orientation$ 
Horizontal=�.+��� -   $��	FoodName1��$��20(��� -   $��
FoodPrice1��$��20(� �� Padding$ 15 0 0 0q��� -   $��FoodCheckBox2��$��5q�.���� $	��250��.+��� -   $��
FoodImage2��$	��180���� $ 
Horizontal=�.+��� -   $��	FoodName2��$��20(��� -   $��
FoodPrice2��$��20(�$ 15 0 0 0q��� -	   $��FoodCheckBox3��$��5q�.���� $	��250��.+��� -
   $��
FoodImage3��$	��180���� $ 
Horizontal=�.+��� -   $��	FoodName3��$��20(��� -   $��
FoodPrice3��$��20(�$ 15 0 0 0q��� -   $��FoodCheckBox4��$��5q�.���� $	��250��.+��� -   $��
FoodImage4��$	��180���� $ 
Horizontal=�.+��� -   $��	FoodName4��$��20(��� -   $��
FoodPrice4��$��20(�$ 15 0 0 0q��� -   $��FoodCheckBox5��$��5q�.���� $	��250��.+��� -   $��
FoodImage5��$	��180���� $ 
Horizontal=�.+��� -   $��	FoodName5��$��20(��� -   $��
FoodPrice5��$��20(�$ 15 0 0 0q��� -   $��FoodCheckBox6��$��5q�.���� $	��250��.+��� -   $��
FoodImage6��$	��180���� $ 
Horizontal=�.+��� -   $��	FoodName6��$��20(��� -   $��
FoodPrice6��$��20(�$ 10 0 0 0q��� -   $��FoodCheckBox7��$��5q�.���� $	��250��.+��� -   $��
FoodImage7��$	��180���� $ 
Horizontal=�.+��� -   $��	FoodName7��$��20(��� -   $��
FoodPrice7��$��20(�$ 15 0 0 0q��� -   $��FoodCheckBox8��$��5q�.���� $	��250��.+��� -   $��
FoodImage8��$	��180���� $ 
Horizontal=�.+��� -   $��	FoodName8��$��20(��� -    $��
FoodPrice8��$��20(�$ 15 0 0 0q��� -!   $��
RiceChoose��$��20(�$	��100��$��30��$
��Left=� d� 	IsChecked$
 TrueY�.��米饭一份� $��1�� � RowDefinitions �� $��30 ��� $��* ��� $��30 ��� $	��100 �.+�� $��0�� �� $	��150 ��� $��60 ��� $��60 �.+��� $��0��$��菜名��$��20(�$
��Bold"�$��Center=��� $��1��$��数量��$
��Bold"�$��18(�$��Center=��� $��2��$��价格��$��20(�$
��Bold"�$��Center=��� $��1��.+��� -"   $��listView������  	 �� 
TargetType
 �� Property �� Value��%4   '��       �� "	 ��.��� 
 � y�$ 	Collapsed=� �� View �� .P��� $��菜名�� �� Width$	 150�� �� CellTemplate �� .R���  �� TextAlignment$ Center=�$��18(�$
��Bold"�����  �� Path$ FoodName��� $��数量��$ 60�� �� .R��� $��1��$ Center=�$��18(�$
��Bold"��� $ 60��$��Header="价格"�� �� .R��� $ Center=�$��20(�$
��Bold"����� $ 	FoodPrice��� -#   $��OrderedFoodsListView������ *OrderedFoods+���� .R�� $
��auto�� �� $	��150 ��� $��50 ��� $��50 �.+��� $��0��$��18(����� $ FoodName��� $��1��$��1���� $��2��$��18(����� $ 	FoodPrice��� $ 
Horizontal=�$��2��$��Center=�.+��� $��20(�	合计：�� -$   $��TextSumPrice��$��20(�$	��0.0��$ 	10 0 10 0q��� $��20(�元�� $��3��.+��� -%   $��OrderFoodBtn��$��下单��$��Stretch=�
��� � �$��50(�$	��100��