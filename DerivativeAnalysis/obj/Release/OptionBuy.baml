   M S B A M L   `   `   `  ���� M  IDerivativeAnalysis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DerivativeAnalysisDerivativeAnalysis  "    DerivativeAnalysis.OptionBuy   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:DerivativeAnalysis       � Title$  	OptionBuy��$	��525��$	��500�� � 	Resources    testBlockStyle �� 
TargetType �� Property �� Value��%f   &	        �� " ��.���  � �� �#f1f1f1��  � ��$
 Bold"���  � ��$ Verdana)�.���� $	��500��$��
0,0,-8,-55q�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ Black�� � Offset$ 0Q�� $ 	#FF454D4D��$ 1Q�.+��� -   	 ��Name$	 valueSecurityName��
 �� Left$
 35��$
��Wrap=�$
��SBIN��
 �� Top$ 30��$��30��$	��120��$��Center=�$��Center=�$��0q�#��[  $��22(��� -   $	 valueMktPrice��$	
 174��$
��Wrap=�$
��4.55��$ 31��$��33��$��Center=�$��Center=�#��[  $��20(��� -    ��Name$ valueNoOfLots��$��78��$
 35�� �� TextWrapping$
 Wrap=�$	 201��$	��133��$��Bottom=�$
��Left=�$��24(�$
��Bold"�$��Verdana)����	#FFF5EDED���	#FF374042�� -   $	 valueStrikePrice��$	
 296��$
��Wrap=�$
��1800��$ 33��$��36��$��Center=�$��Center=�#��[  $��18(��� -   $	 valueCallOrBuy��$	
 412��$
��Wrap=�$
��CALL��$ 31��#��[  $��33��$��Center=�$��Center=�$��20(��� -    ��Name$ labelSecurityName��$��Security Name��$
 35��$ 60��$��0q�$	��120��$��25��$
��Left=�$	��Top=�$��Verdana)����	#FFF9F3F3�� -   $ labelMktPrice��$��Price��$	
 174��$ 60��$��25��$
��Left=�$	��Top=�$��Verdana)����	#FFF9EFEF�� -   $ labelStrikPrice��$��Strike Price��$	
 296��$ 60��$
��Left=�$	��Top=�$��Verdana)����	#FFF3EBEB�� -	   $ labelBuyOrSell��$��Label��$	
 412��$ 60��$��25��$
��Left=�$	��Top=����	#FFF3E9E9�� -
   $	 valueOi��$	
 174��$
��Wrap=�#��[  $	��456��$	 136��$��Center=�$��Center=�$��14(�$
��Bold"�$��Verdana)��� -   $	 valueOiChange��$	
 296��$
��Wrap=�$	��56%��$	 134��#��[  $��Center=�$��Center=�$��14(�$
��Bold"�$��Verdana)��� -   $	 valueIv��$	
 412��$
��Wrap=�$��67��$	 137��#��[  $
��Left=�$	��Top=�$��14(�$��Verdana)�$
��Bold"��� -   $ labelOi��$��OpenInterest��$	
 174��$	 153��$
��Left=�$	��Top=����	#FFF3E9E9�� -   $ labelOiChange��$��	OI Change��$	
 296��$	 153��$��Verdana)����	#FFF9EAEA�� -   $ labelIv��$��IV��$	
 412��$	 155��$
��Left=�$	��Top=����	#FFFBECEC�� -   $ 
valuePrice��$��31��$	
 215��$
 Wrap=�$
��4.00��$	 248��$	��120��$��Center=�$��Center=�$
��Bold"�$��14(����	#FFFBF5F5�� -   $ labelLotSize��$
��x100��$
 35��$	 284��$��14(�$
��Bold"�$��Verdana)�$
��Left=�$��Bottom=����	#FFF5E9E9�� -   $ 
labelPrice��$��	Mkt Price��$	
 215��$	 284��$
��Left=�$	��Top=�$��Verdana)����	#FFF7E4E4�� -   $ labelTotalValue��$��
TotalValue��$	
 388��$	 284��$
��Left=�$	��Top=�$��Verdana)����	#FFF9F3F3	� -    	�Name$ boolBuy��$	��BUY��$
 35��$	 380��$��Verdana)�$��20(����	#FF17F134���	#FFF1F1E5$
��Bold"�	� -   $ boolSell��$
��SELL��$	
 202��$	 375��$��20(����	#FFF30A0A$
��Bold"��� -    ��Name$ comboBox��$	
 361��$	 377��$	��106��$��Verdana)�$
��Left=�$	��Top=�.@��� $��	Strategy1��$
��Left=�$	��104��$��25��$��Bottom=����	#FFF5E9E9���	#FF767272�� $��	Strategy2��$
��Left=�$	��104��$��Bottom=�$��21�����	#FFFBF5F5���	#FF666565�� -   $	 
valueTotal��$	
 388��$
��Wrap=�$	 263�� J� RenderTransformOrigin$ 0.059,0.783&�$
��Left=�$��Bottom=�$��Verdana)�$��14(�$
��Bold"����	#FFF9F5F5�� -    ��Name$ button��$	��ADD��$	
 202��$	 437��$��91��$��Verdana)�$
��Bold"�$��16(�