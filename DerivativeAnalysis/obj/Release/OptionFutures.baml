   M S B A M L   `   `   `  ���� M  IDerivativeAnalysis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DerivativeAnalysisDerivativeAnalysis  &     DerivativeAnalysis.OptionFutures   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:DerivativeAnalysis     U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  OptionFutures��$	��300��$	��300��   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���  .���  � ColumnDefinitions �� $��1* ��� $��4* ��� $��4* � � RowDefinitions �� $��2* ��� $	��12* ��� $��1* �.+��� -    ��Name$ menuForOptions��$��1��$��0��.+��� -    ��Name$ textBox��$��27�� �� Left$ 24�� �� TextWrapping$
 Wrap=�$�� ��
	 �� Top$	 35��$��80���� -   
 ��Name$
 dropStrikePrice��$	 280��$	 35��$	��100��$��22��$��Verdana)�$��Center=�$��Center=��� -   $
 comboBox��$��1��$	��100��$��22��$	 150��$	 35��.@��� $��ComboBoxItem��$
��Left=�$��95���� -    ��Name$ label��$��Search��$ 24��$��24�� J� RenderTransformOrigin$ 0.675,0.625&�$
��Left=�$	��Top=�$��Verdana)�$	 6���� -   $ label1��$��ExpDate��$	 150��$	 5���� -   $ label2��$��Strike Price��$	 280��$	 5��&   System.Windows.Controls.DataGrid  -     Name$ dataGridOptions��$
��Left=�$��0,10,0,0q�$	��Top=�$	��500��$
��auto��$��1��$��1��   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   HeaderTemplate �� .R��� $��SELECT��   CellTemplate �� .R���  ��Name$ addBtn�� � Cursor$ Arrow��.��+�� -	   $ menuForFutures��$��0��$��1��$y�Hidden=�.+��� -
   $ searchFutures��$��27��$ 24��$
 Wrap=�$�� ��$	 35��$��80���� -   $
 
expDateFut��$��1��$	��100��$��22��$	 150��$	 35��.@��� $��ComboBoxItem��$
��Left=�$��95���� -   $ labelSearchFut��$��Search��$ 24��$��24��$ 0.675,0.625&�$
��Left=�$	��Top=�$��Verdana)�$	 6���� -   $ labelExpDate��$��ExpDate��$	 150��$	 5��  -   $ dataGridFutures��$
��Left=�$��1��$��1��$��0,10,0,0q�$y�Hidden=�    �� .R��� $��SELECT�� �� .R��� $ addBtn��$ Arrow��.��+�� -   $ button��$��Options��$��1��$��2��$
��Left=�$��	34,10,0,0q�$	��Top=�$��75��$ Arrow���� -   $ button1��$��Futures��$��1��$��2��$
��Left=�$��
160,10,0,0q�$	��Top=�$��75��$ Arrow��