   M S B A M L   `   `   `  ????L  HFreelancePlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:FreelancePlatform.Assets.MVVM.Views#FreelancePlatform.Assets.MVVM.Views  5      6    0FreelancePlatform.Assets.MVVM.Views.MyOrdersView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:FreelancePlatform.Assets.MVVM.Views     5      $??0q?5	        ? 	Resources  5
       ?? 
TargetType ?? Property ?? Value??%?   '??       ?? 5   
   " ??6   .?5      ??  ?@J?Opacity$ 0Q?6(   ?? 5       ? ??$ 	0,0,-20,0q?6'   5      5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $??1* ?6   ?? 5      $	??110 ?6   .+?5   
   ?? .??5      ?? $??20q?6n   $??0??6z   ??6   ?? *
MyOrders+ ?? Mode$ TwoWay=? ?? UpdateSourceTrigger$ PropertyChanged=???5      ?? 5      .R?5      ??  ?? Padding$ 20q?6!   ???#D9D9D9$	??160??6D   $
??auto??6T   $??10q?6b   $??1q?6n   $	??780??6?    ? Cursor$
 Hand??6?   ??5      ?? 5   "   " ??6(   .?5   &   ??  ? ??
 ???? 6C   	 ?? Triggers	 5   &   P? 5   *   
 P? Property
 ?@J?IsMouseOver P? Value . . ?5   .   ??  ? ?? ?	#18D9D9D96K   5    +   5"   #    J? InputBindings 5$      d? 5%   "    d? MouseAction$ 	LeftClicke?6/    ?? Command 5&   +   ??  ?? RelativeSource ??  ?? AncestorType" ?? ?? Path$$ DataContext.SelectOrderCommand? ?? CommandParameter 5'   +   ?? *Id+._?5)      ?? .+?5*   "   ?? 
?????? $
??Wrap=?5,   4   $??Medium"?5-   4   $??
Montserrat)?5.   4   $??30(?5/   4   ???#4ECCA3$
??auto??51   4   $??Center=?52   4   $
??Left=?53   "   ??5*   ,   ?? *Topic+$ OneWay=?$ PropertyChanged=?53   "   ?? 54   "   
?????? $
??Wrap=?56   &   $??Medium"?57   &   $??
Montserrat)?58   &   $??16(?59   &   ???#D9D9D9$
??auto??5;   &   $??Center=?5<   &   $
??Left=?5=   &   $	??600??5>   &   $
??0,10q?5?   &   ??54   ,   ?? *
GoalString+$ OneWay=?$ PropertyChanged=?5?   &   ?? 5@   "   
?????? $
??Wrap=?5B   &   $??Medium"?5C   &   $??
Montserrat)?5D   &   $??16(?5E   &   ???#D9D9D9$
??auto??5G   &   $??Center=?5H   &   $
??Left=?5I   &   $	??600??5J   &   ??5@   ,   ?? *ResponseCountString+$ OneWay=?$ PropertyChanged=?5J   &   5K      5L      5M      ??5O      ?? 5P      .R?5Q      ? 5R      5T      5U      ?? 5V   
   $??60??6      WhiteButton#??[  5W      $??1??5X      $	??320??5Y      $??26(?5Z      $!??Добавить заказ??5[      $??Right=?5\      $
??30,0q?5]      ??5^      ?? *AddOrderCommand+5_      5`      