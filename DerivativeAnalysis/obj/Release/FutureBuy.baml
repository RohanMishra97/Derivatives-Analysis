   M S B A M L   `   `   `  ���� M  IDerivativeAnalysis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DerivativeAnalysisDerivativeAnalysis  "    DerivativeAnalysis.FutureBuy   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:DerivativeAnalysis       � Title$  	FutureBuy��$	��525��$	��500�� � 	Resources    testBlockStyle �� 
TargetType �� Property �� Value��%f   &	        �� " ��.���  � �� �#f1f1f1��  � ��$
 Bold"���  � ��$ Verdana)�.���� $	��500��$	��500������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ Black�� � Offset$ 0Q�� $ 	#FF454D4D��$ 1Q�.+��� -   	 ��Name$	 valueSecurityName��
 �� Left$
 35��$
��Wrap=�$
��SBIN��
 �� Top$ 32��$��30��$	��120��$��Center=�$��Center=�$��0q�#��[  $��22(��� -   $	 valueMktPrice��$	
 327��$
��Wrap=�$
��4.55��$ 32��$��33��$��Center=�$��Center=�#��[  $��20(��� -    ��Name$ valueNoOfLots��$��78��$
 35�� �� TextWrapping$
 Wrap=�$	 201��$	��133��$��Bottom=�$
��Left=�$��24(�$
��Bold"�$��Verdana)����	#FFF5EDED���	#FF374042�� -    ��Name$ labelSecurityName��$��Security Name��$
 35��$ 60��$��0q�$	��120��$��25��$
��Left=�$	��Top=�$��Verdana)����	#FFF9F3F3�� -   $ labelMktPrice��$��Price��$	
 327��$ 60��$��25��$
��Left=�$	��Top=�$��Verdana)����	#FFF9EFEF�� -   $	 	valueVwap��$
 35��$
��Wrap=�#��[  $��123.87��$	 134�� J� RenderTransformOrigin$ 0.302,0.657&�$��Center=�$��Center=�$��14(�$
��Bold"�$��Verdana)���Z� �� -   $	 valueOi��$	
 215��$
��Wrap=�#��[  $	��456��$	 137��$��Center=�$��Center=�$��14(�$
��Bold"�$��Verdana)��� -   $	 valueOiChange��$	
 361��$
��Wrap=�$	��56%��$	 131��#��[  $��Center=�$��Center=�$��14(�$
��Bold"�$��Verdana)��� -	   $ 	labelVwap��$
��VWAP��$
 35��$	 155��$��Verdana)����	#FFF7F1F1�� -
   $ labelOi��$��OpenInterest��$	
 215��$	 154��$
��Left=�$	��Top=����	#FFF3E9E9�� -   $ labelOiChange��$��	OI Change��$	
 361��$	 153��$��Verdana)����	#FFF9EAEA�� -   $ 
valuePrice��$��31��$	
 215��$
 Wrap=�$
��4.00��$	 248��$	��120��$��Center=�$��Center=�$
��Bold"�$��14(����	#FFFBF5F5�� -   $ labelLotSize��$
��x100��$
 35��$	 284��$��14(�$
��Bold"�$��Verdana)�$
��Left=�$��Bottom=����	#FFF5E9E9�� -   $ 
labelPrice��$��	Mkt Price��$	
 215��$	 284��$
��Left=�$	��Top=�$��Verdana)����	#FFF7E4E4�� -   $ labelTotalValue��$��
TotalValue��$	
 388��$	 284��$
��Left=�$	��Top=�$��Verdana)����	#FFF9F3F3	� -    	�Name$ boolBuy��$	��BUY��$
 35��$	 365��$��Verdana)�$��20(����	#FF17F134���	#FFF1F1E5$
��Bold"�	� -   $ boolSell��$
��SELL��$	
 215��$	 367��$��20(����	#FFF30A0A$
��Bold"��� -    ��Name$ comboBox��$	
 355��$	 364��$	��106��$��Verdana)�$
��Left=�$	��Top=�.@��� $��	Strategy1��$
��Left=�$	��104��$��25��$��Bottom=����	#FFF5E9E9���	#FF767272�� $��	Strategy2��$
��Left=�$	��104��$��Bottom=�$��21�����	#FFFBF5F5���	#FF666565�� -   $	 
valueTotal��$	
 388��$
��Wrap=�$	 263��$ 0.059,0.783&�$
��Left=�$��Bottom=�$��Verdana)�$��14(�$
��Bold"����	#FFF9F5F5��Z� �� -    ��Name$ button��$	��Add��$	
 219��$	 427��$��75��$ 0.401,0.537&�$��Verdana)�$��16(�$
��Bold"�