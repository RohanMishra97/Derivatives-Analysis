   M S B A M L   `   `   `  ����M  IDerivativeAnalysis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DerivativeAnalysisDerivativeAnalysis  5   	   &     DerivativeAnalysis.OptionFutures   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:DerivativeAnalysis     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Title$  OptionFutures��5   	   $	��300��6   $	��300��6,      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   5      �� 5      $��4* �6   5      �� 5      $��4* �6   5       � RowDefinitions 5   
   �� 5      $��2* �6   5      �� 5      $	��12* �6   5       �� 5!      $��1* �6   5"      .+�5$   
   �� -   5         ��Name$ menuForOptions��5$      $��1��6)   $��0��69   .+�5%      �� -   5         ��Name$ textBox��5%      $��27��6'    �� Left$ 24��63    �� TextWrapping$
 Wrap=�6D   $�� ��6X   
	 �� Top$	 35��5&      $��80��6&   61   �� 5'      -   5        
 ��Name$
 dropStrikePrice��5'      $	 280��60   $	 35��6B   $	��100��6R   $��22��6^   $��Verdana)�6j   $��Center=�6   $��Center=�6�   �� 5(      -   5        $
 comboBox��5(      $��1��6)   $	��100��5)      $��22��6#   $	 150��60   $	 35��6B   .@�5*      �� $��ComboBoxItem��6   $
��Left=�66   $��95��6Q   5+      �� 5,      -   5         ��Name$ label��5,      $��Search��6#   $ 24��64   $��24��6E    J� RenderTransformOrigin$ 0.675,0.625&�6Q   $
��Left=�6u   $	��Top=�6�   $��Verdana)�6�   $	 6��6�   �� 5-      -   5        $ label1��5-      $��ExpDate��6$   $	 150��66   $	 5��6H   �� 5.      -   5        $ label2��5.      $��Strike Price��6$   $	 280��6;   $	 5��6M   5/      &   System.Windows.Controls.DataGrid  51   
   -   5          Name$ dataGridOptions��51      $
��Left=�6,   $��0,10,0,0q�6G   $	��Top=�52      $	��500��53      $
��auto��6    $��1��6/   $��1��6?      Columns 54      4  .System.Windows.Controls.DataGridTemplateColumn  55      ,  &System.Windows.Controls.DataGridColumn   HeaderTemplate 56      �� 57      .R�58      �� $��SELECT��6(   59         CellTemplate 5;      �� 5<      .R�5=      ��  ��Name$ addBtn��6%    � Cursor$ Arrow��65   .��6E   +6H   5>      5@      5C      �� 5E   
   -	   5        $ menuForFutures��5E      $��0��6,   $��1��69   $y�Hidden=�6I   .+�5F      �� -
   5        $ searchFutures��5F      $��27��6-   $ 24��69   $
 Wrap=�6J   $�� ��6^   $	 35��5G      $��80��6&   61   �� 5H      -   5        $
 
expDateFut��5H      $��1��6+   $	��100��5I      $��22��6#   $	 150��60   $	 35��6B   .@�5J      �� $��ComboBoxItem��6   $
��Left=�66   $��95��6Q   5K      �� 5M      -   5        $ labelSearchFut��5M      $��Search��6,   $ 24��6=   $��24��6N   $ 0.675,0.625&�6Z   $
��Left=�6~   $	��Top=�6�   $��Verdana)�6�   $	 6��6�   �� 5N      -   5        $ labelExpDate��5N      $��ExpDate��6*   $	 150��6<   $	 5��6N   5O        5P   
   -   5        $ dataGridFutures��5P      $
��Left=�6-   $��1��6H   $��1��6X   $��0,10,0,0q�6e   $y�Hidden=�5Q       5R        5S       5T      �� 5U      .R�5V      �� $��SELECT��6(   5W       5Y      �� 5Z      .R�5[      �� $ addBtn��6%   $ Arrow��65   .��6E   +6H   5\      5^      5a      �� 5b   
   -   5        $ button��5b      $��Options��6!   $��1��63   $��2��6C   $
��Left=�6P   $��	34,10,0,0q�6k   $	��Top=�5c      $��75��6)   $ Arrow��64   6C   �� 5d   
   -   5        $ button1��5d      $��Futures��6"   $��1��64   $��2��6D   $
��Left=�6R   $��
160,10,0,0q�6m   $	��Top=�5e      $��75��6)   $ Arrow��64   6C   5h      5i      