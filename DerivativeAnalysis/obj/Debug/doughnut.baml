   M S B A M L   `   `   `  ����M  IDerivativeAnalysis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DerivativeAnalysisDerivativeAnalysis  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      !    DerivativeAnalysis.doughnut   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:DerivativeAnalysis     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� -   5        $
��10 0q�5   .   .��6=   
Move All5      �� 5      -   5        .��5   ,   	Restart65   �� 5      $��Center=�6    �� Padding$
 10 0q�63   Series6J   �� 5      -   5        $��30��5   .   .��6<   +5      �� 5      -   5        $��30��5   1   .��6?   -5      �� 5      $��Center=�6   $
 10 0q�63   Values6J   �� 5      -   5        $��30��5      $��30��69   .��6G   +5      �� 5      -   5        $��30��5      $��30��6=   .��6K   -5!      5#        LiveCharts.Wpf.PieChart  5$   
   -   5        $��Chart��5$      $��1��6$   &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�5%         InnerRadius$	 100Q�6.   $
��0 15q�6@      Series 5$   1   �� *SeriesCollection+   ChartLegend 5&      "  LiveCharts.Wpf.DefaultLegend  5'         
BulletSize$ 20Q�6$   66      DataTooltip 5)      #  LiveCharts.Wpf.DefaultTooltip  5*      	   
BulletSize$	 20Q�6%   67   5,      5-      5.      