   M S B A M L   `   `   `  ����  
Ostoslista    Ostoslista.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
Ostoslista��5   	   $	��500��6   $	��600��6)   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   �� 5
      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� .+�5      �� $��Tuote��6   $
��Bold"�6)   �� 5      -   5         ��Name$ txtTuote��5      $	��200��6,   5      �� 5      $��10,0,0,0q�6   .+�5      �� $��Määrä��6   $
��Bold"�6)   �� 5      -   5        $ txtMaara��5      $��80��6,   5      �� 5      -   5        $��Lisää��5      $	��100��6<   $��	10,20,0,0q�6H   5      �� 5   
   -   5         ��Name$ lvOstoslista��5      $��2��6)   $��	0,10,0,10q�66    �� View 5      �� 5      .P�5      �� $��Tuote��6%    �� Width$	 300��6[    �� DisplayMemberBinding 64   �� *Tuote+6[   �� 5      $��Määrä��6%   $ 80��6[    64   �� *Maara+6[   5       5"      �� 5%   
   $ 
Horizontal=�6   $��Center=�6.   $��3��6K   $��0,10,0,0q�6X   .+�5&      �� -   5         ��Name$ 	btnPoista��5&      $��Poista��6(   $��80��6Q   $��5q�6\   ${�False��6g   �� 5'      -   5        $��	Tyhjennä��5'      $��80��6B   $��5q�6M   �� 5(      -   5        $��Tallenna��5(      $��80��6B   $��5q�6M   �� 5)      -   5        $��Lataa��5)      $��80��6<   $��5q�6G   5*      5,      5-      