   M S B A M L   `   `   `  ���� M  IDerivativeAnalysis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DerivativeAnalysisDerivativeAnalysis  7 clr-namespace:DerivativeAnalysisDerivativeAnalysis  #    DerivativeAnalysis.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:DerivativeAnalysis     1self clr-namespace:DerivativeAnalysis     U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  
MainWindow��$
��1250��$	��650��   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���  .��� ���	#FF343540.+��� -    ��Name$ MenuOptions�� �� Orientation$ Vertical=�$
��Left=�$	��195��$��1,75,0,0q�$	��Top=�$	��158��.+���   MaterialDesignFlatButton#��[  � ToolTip$ MaterialDesignFlatButton��$��	Positions��
�������$��15(��� -    ��Name$ DashboardButton��#��[ $ MaterialDesignFlatButton��$��	Dashboard��
�������$��15(����	#FF43444F�� -   $ FutureButton��#��[ $ MaterialDesignFlatButton��$��Futures��
�������$��15(��� -   $ OptionButton��#��[ $ MaterialDesignFlatButton��$��Options��
�������$��15(��� #��[ $ MaterialDesignFlatButton��$
��Blog��
�������$��15(��� #��[ $ MaterialDesignFlatButton��$
��Team��
�������$��15(�&   System.Windows.Controls.DataGrid  -   $��
liveTicker��$
��Left=�$��	0,281,0,0q�   AutoGenerateColumns .  $	��Top=�$	��252��$	��208��$   HorizontalScrollBarVisibility$ Hidden=�"	   VerticalScrollBarVisibility$	 Hidden=�
 �� AlternationCount$
 2��   AlternatingRowBackground �	#FF43444F���	#FF343540   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Stock��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *symbol+  $ Quote��$	 100  �� *value+�� -   $ iconNav��$ 
Horizontal=�$
��Left=�$��64��$��	711,0,0,0q�$	��Top=�$	��521��.+��� -   $ BtnIcon��$��0q�
������ 
�������$��60��$	��0,3q���0  *MaterialDesignThemes.Wpf.PackIconExtension  *	ChartLine+�� -   $ BtnIcon7��$��0q�
������ 
�������$��60����  *
ChartGantt+�� -	   $ BtnIcon9��$��0q�
������ 
�������$��60��$��	0,12,0,11q���  *charttimelinevariant+�� -
   $ BtnIcon6��$��0q�
������ 
�������$��60��$
��0,16q���  *EmailMarkAsUnread+�� -   $ BtnIcon2��$��0q�
������ 
���������  *bell+�� -   $ BtnIcon3��$��0q�
������ 
���������  *flag+�� -   $ BtnIcon4��$��0q�
������ 
���������  *faceprofile+�� -    ��Name$ 	textBlock��$��Center=�$��18��$
��Wrap=�$��Harish Menon��$��Center=�$��92���� -   $ BtnIcon5��$��0q�
������ 
�������$
��Auto����  *settingsoutline+� -    �Name$ nonMenu��$
��Left=�$	��502��$��208,108,0,0q�$	��Top=�$
��1024��$y�Hidden=� � ColumnDefinitions �� $��* ��� $��* � � RowDefinitions �� $��2* ��� $	��12* �.+��� -    ��Name$ menuForOptions��$��0��$��0��.+��� -    ��Name$ searchOption��$��27�� �� Left$ 24�� �� TextWrapping$
 Wrap=�$�� ��
 �� Top$ 30��$��80���� -    ��Name$ dropStrikePrice��$	 280��$ 35��$	��100��$��22��$��Verdana)�$��Center=�$��Center=��� -   $ comboBox��$��1��$	��100��$��22��$	 150��$ 35��.@��� $��	9/26/2019��$
��Left=�$��95���� $��
10/31/2019��$
��Left=�$��95���� $��
11/28/2019��$
��Left=�$��95���� -    ��Name$ label��$��Search��$ 24��$��24�� J� RenderTransformOrigin$ 0.675,0.625&�$
��Left=�$	��Top=�$��Verdana)�$ 6���� -   $ label1��$��ExpDate��$	 150��$ 5���� -   $ label2��$��Strike Price��$	 280��$ 5��  -     Name$ dataGridOptions��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��500��$
��auto��$��0��$��1�� 4  .System.Windows.Controls.DataGridTemplateColumn     HeaderTemplate �� .R��� $��SELECT��   CellTemplate �� .R��� $ addBtn�� � Cursor$ Arrow��.��+  $ id��$ 90  �� *	option_id+  $ Symbol��$	 100  �� *symbol+  $ Expiry��$ 90  �� *expiry_date+  $	 LTP��$ 90  �� *ltp+  $ oi��$	 100  �� *oi+  $ 	oi_change��$ 90  �� *	oi_change+  $ volume��$	 100  �� *volume+  $
 Type��$	 100  �� *	op_type+  $ p_change��$ 90  �� *
p_change+  $ Strike Price��$	 100  �� *strike_price+  $ iv��$	 100  �� *iv+�� -   $ menuForFutures��$��0��$��0��$y�Hidden=�.+��� -   $ searchFuture��$��27��$ 24��$
 Wrap=�$�� ��$ 30��$��80���� -   $ 
expDateFut��$��1��$	��100��$��22��$	 150��$ 35��.@��� $��ComboBoxItem��$
��Left=�$��95���� -   $ labelSearchFut��$��Search��$ 24��$��24��$ 0.675,0.625&�$
��Left=�$	��Top=�$��Verdana)�$ 6���� -   $ labelExpDate��$��ExpDate��$	 150��$ 5��  -   $ dataGridFutures��$
��Left=�$��0��$��1��$��	10,10,0,0q�$y�Hidden=�$	��500��    �� .R��� $��SELECT�� �� .R��� $ addBtn��$ Arrow��.��+  $ id��$ 90  �� *	future_id+  $ Symbol��$	 100  �� *symbol+  $ Expiry��$ 90  �� *expiry_date+  $	 LTP��$ 90  �� *ltp+  $ oi��$	 100  �� *oi+  $ 	oi_change��$ 90  �� *	oi_change+  $ volume��$	 100  �� *volume+  $
 VWAP��$	 100  �� *vwap+�� -   $ workSpaceTitle��$��1��$��0��.+��� -    $ titleStrategies��$
��Left=�$��
33,12,0,-2q�$
��Wrap=�$��
STRATEGIES��$	��Top=�$��Verdana)�$
��Bold"����#f1f1f1$��20���� -!   $ button2��$��+ ADD STRATEGY��$
��Left=�$��318,11,-163,-1q�$	��Top=�$	��127��$��Verdana)�$��10(�$��20��� -"   $ 	workspace��$��1��$��1��$��28,10,-149,10q�.+�R� -#     R�Name$  strategyTree��! � 	Resources! " �� DataType!	  DerivativeAnalysis.Strategy# �� ItemsSource'
  !DerivativeAnalysis.StrategyMember��%�  (��       *,	 +)(�� �     *,
 +)�� "" 	 # �� *	Members+.R��� $ 
Horizontal=�.+��� ���� *Name+�� ���� *Dt+�� $�� [��
��������� 
����������� *Members.Count+�� $��]��
��������� $��Analyse�����#999�� "" 
 .R��� $ 
Horizontal=�.+��� ���� *Name+�� $�� (��
��� � ��� ���� *Age+�� $�� years)��
��� � �� -$   $ DashboardMenu��