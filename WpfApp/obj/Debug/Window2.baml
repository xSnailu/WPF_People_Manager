   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   A =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp 5
   	      WpfApp.Window2   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   &localclr-namespace:WpfApp     5
   	     � AllowsTransparency  .  � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	   ���	#00000000 � Title$ Window2��5   	   $	��450��6   $	��800��6&    � 	Resources 5         SexEnum S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters M� TypeName  ValidationTemplate  AcceptButtonStyle	 �� 
TargetType
 �� Property �� Value �� Triggers ^� 
Conditions �� Binding �� Path �� ElementName �� Value  TextBoxInError � ToolTip �� Self �� RelativeSource P� Property P� Value��%�  &	        &	 j     &	 �     &	 �    S� 5   
   $ 	GetValues��6-   "  5       5      M� 5      $ 	local:SEX��6   5      �� 5   
   .R�5      ]� .+�5      �� 
���  ��$��20(�6-   !6>   �� 5      5      5      �� 5    
   "	 ��6*   .�5!      �� 
 � {� .  6*    5"      ^� 5#       5$      �� 5%       6$   �� $ (Validation.HasError)�$ NameBox��	 False6h   �� 5&       6$   �� $ (Validation.HasError)�$ 
SurnameBox��	 False6k   �� 5'       6$   �� $ (Validation.HasError)�$ EmailBox��	 False6i   �� 5(       6$   �� $ (Validation.HasError)�$ PhoneBox��	 False6i   .0�5*      �� 
 � {� . 62   5+      5-      �� 50   
   "	 ��6'   .�51      �� 
 �@=�ErrorTemplate 52      �� 53      .R�54      ]� ��. .+�55      �� 
���  ��$��2q�67   $
��Left=�6K   ._�56   "   �� 57      �� 58      $��Resources/error.jpg��6$   $��20��6A    6L   �� # Z $&  (Validation.Errors)/ErrorContent�5:      5;      5=       5?      P� 5@       �@=�HasError . . �5A      �� 
 � ��
 �  ��63   5B      5D      5F      .��5H      � .+�5I   
   � $	��350��6   $	��240��6   $��Center=�6(   $��Center=�6C   ���#FFFFFF.+�5J      �� $��4q�6   
���   �._�5K      �� .+�5L      �� $��Add new contact��6    $��Center=�67   $��20(�6T   � 5M      $	��160��6    � RowDefinitions 5N      �� 5O      $��30 �6,   �� 5P      $��30 �6,   �� 5Q      $��30 �6,   �� 5R      $��30 �6,   �� 5S      $��30 �6,   .+�5U      �� $��0��6    $
��Name��6-   �� 5V      $��1��6    $��Surname��6-   �� 5W      $��2��6    $��Email��6-   �� 5X      $��3��6    $��Phone��6-   �� 5Y      $��4��6    $��Gender��6-   �� 5]      -   5         ��Name$ NameBox��5]   "   $��0��63   $��Right=�6@   $	��150��6\   #��[ 5^   "   $��
30 10 30 0q�5_   "   ��5`   "   �� *NameW2+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . " �� ValidatesOnNotifyDataErrors . .��6�   5a      �� 5b      -   5        $ 
SurnameBox��5b   "   $��1��66   $��Right=�6C   $	��150��6_   #��[ 5c   "   $��
30 10 30 0q�5d   "   ��5e   "   �� *	SurnameW2+$ PropertyChanged=� .  . .��6�   5f      �� 5g      -   5        $ EmailBox��5g   "   $��2��64   $��Right=�6A   $	��150��6]   #��[ 5h   "   $��
30 10 30 0q�5i   "   ��5j   "   �� *	EmailW2+$ PropertyChanged=� .  . .��6�   5k      �� 5l      -   5        $ PhoneBox��5l   "   $��3��64   $��Right=�6A   $	��150��6]   #��[ 5m   "   $��
30 10 30 0q�5n   "   ��5o   "   �� *	PhoneW2+$ PropertyChanged=� .  . .��6�   5p      �� 5q      -   5         ��Name$ SexBox��5q   #   $��
30 10 30 0q�64   $��4��6I    �� SelectedIndex$ 0��6V   $��Right=�6�   $	��150��6�   ��6h   ��  �� Source# [  6�   5s      � 5t       � ColumnDefinitions 5u      �� 5v      �� 5w      .+�5y      �� -   5        #��[ 5y   !   $��0��6L   $��Add contact��6\   $��10q�6r   5{      �� 5|      -   5        $��1��5|   !   $��Close��62   $��10q�6B   6N   5}      5      5�      5�      5�      5�      