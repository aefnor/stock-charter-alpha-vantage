   M S B A M L   `   `   `  ����A  =Stocks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:StocksStocks  5   	       Stocks.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Stocks     5   	   R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  6,     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � $��	64,56,0,0q�6   .+�5
   
   �� -   5         ��Name$ StockTicker��5
      $
��Left=�6'   $��
-1,-38,0,0q�6B    �� TextWrapping$
 Wrap=�6V   $	��Top=�6j   $	��120��6�   4  .System.Windows.Automation.AutomationProperties   HelpText$ Enter Ticker��6�   �� 5   
   $��Ticker��6   $
��Left=�6!   $��-56,-42,0,0q�6<   $	��Top=�6Q   �� 5   
   -   5         ��Name$	 ROE��5      $	��ROE��6   $
��Left=�6+   $��412,-42,0,0q�6F   $	��Top=�6[   �� 5   
   -   5        $��Chart��5      $
��Left=�6!   $��139,-39,0,0q�6<   $	��Top=�6Q   6i     OxyPlot.Wpf.Plot  5   
   -   5          Name$ 
TickerPlot��5      $��-35,0,223,37q�6?      Title 6'   �� *Title+   Series 5        OxyPlot.Wpf.LineSeries  5      ��6!   �� *PointsClose+  5      ��6!   �� *
PointsOpen+  5      ��6!   �� *
PointsHigh+  5      ��6!   �� *	PointsLow+5      �� 5   
   -   5         ��Name$ Volume_Per_Day��5      $��518,10,0,37q�6+   	 �� View	 5      �� 5      .P�5      �� 5      5      �� 5   
   -   5        
 ��Name$

 Zoom��5      $
��Zoom��6   $
��Left=�6.   $��206,-38,0,0q�6I   $	��Top=�6^   6v   �� 5   
   -   5         ��Name$ 	Timeframe��5      $
��Left=�6&   $��269,-38,0,0q�6A   $	��Top=�6V   $	��120��6n   6z   5      5       