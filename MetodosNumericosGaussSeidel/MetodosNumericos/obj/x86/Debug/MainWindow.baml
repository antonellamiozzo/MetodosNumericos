   M S B A M L   `   `   `  ����D  @Controles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:Controles;assembly=Controles	Controles  5       MetodosNumericos!   MetodosNumericos.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9my*clr-namespace:Controles;assembly=Controles     5      -   5          � Title$  Gauss-Seidel��5   	   $	��482��6   $	��669��6+   .��5      � ��5   
   �� 5	       �� ImageSource$= 7/MetodosNumericos;component/Images/hojas_de_cristal.jpg��5
       � ColumnDefinitions 5   
   �� 5      $	��475 �5      �� 5      $
��192* �5       � RowDefinitions 5   
   �� 5      $	��120 �5      �� 5      $
��Auto �5      �� 5      $
��182* �5      �� 5      $
��Auto �5      .+�5   
   �� -   5        $��	tbxMatrix��5       �� AcceptsReturn . $��Consolas)�5      $��13(�5       $
��Bold"�5!      $ �� HorizontalScrollBarVisibility$ Visible=�5"      " �� VerticalScrollBarVisibility$ Visible=�5#       �� 
IsReadOnly . $��2��5%      $��2��5&      $��
10,10,10,0q�5'         SimpleTextBox#���   6!   
�������  
GlyphBrush#���  6\   �� 5(   
   -   5        $��	tbkResult��5*      $��3��5)      $�� ��5+      $��25,0,0,0q�5,      $��2��5-      $��10,10,35,10q�5.      $��50��5/       �� 
AcceptsTab .  . #���   51      
�������#���  6Z   .��6�   	 J� OpacityMask	 52      �� 53      
 �� EndPoint$
 0.995,0.502&�6     �� 
StartPoint$ 0,0.5&�67   .��54      �  � Color$ Black��6    � Offset$
 0.28Q�6(   � 55      $ 1Q�6   56      .��57       58      � 59   
   -   5        $��grid1��5;      $��1��5:      $
��0,10q�5<      ���	#33000000 5=      �� 5>      $
��Auto �5?      �� 5@      $
��Auto �5A       5C      �� 5D      $
��Auto �5E      �� 5F      $
��Auto �5G      .+�5I      �� -   5        $��
textBlock1��5J      $��No Ecuaciones��5K      $��Center=�5L      $��Center=�5M      $��
10,10,10,0q�5N      
�������6%   �� 5O      -   5        $��btnGauss��5Q      $��CALCULAR��5P      $��1��5S      $��2��5T      $��10q�5U      $��34��5V        SimpleButton#���  6    J� Effect 5W      3  -System.Windows.Media.Effects.DropShadowEffect  5X      5Z      �� 5[      -   5        $	��cbx��5]      $��1��5\       �� SelectedIndex$ 0��5^      $��50��5`      $��
10,10,10,0q�5a        SimpleComboBox#���  6%   5b         Controles.MatrixIn  5c   
   -   5        $��matrixIn��5d      $��
0,10,10,10q�5e      ���	#4C0000006!   �� 5f   
   -	   5        $��
textBlock2��5i      $��2��5g      $��1��5h      $��METODO DE GAUSS - SEIDEL��5j       �� TextAlignment$ Center=�5k      $��Charlemagne Std)�6$    �� Padding$
 0,10q�6A   $��16(�6P   
����������	#660000006q   5l      5m      