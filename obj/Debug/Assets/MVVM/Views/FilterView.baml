   M S B A M L   `   `   `  ????L  HFreelancePlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:FreelancePlatform.Assets.MVVM.Views#FreelancePlatform.Assets.MVVM.Views  5      4    .FreelancePlatform.Assets.MVVM.Views.FilterView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:FreelancePlatform.Assets.MVVM.Views     5      $??0q?5        ? 	Resources  5	       ?? 
TargetType ?? Property ?? Value??%?   '??       ?? 5
   
   " ??6   .?5      ??  ?@J?Opacity$ 0Q?6(   ?? 5       ? ??$ 	0,0,-20,0q?6'   5      5      .??5      ?? $??5??6   
 ? Tag$ Filter??6   $??0,1,0,1q?6'   ???#232931 ?? Padding$
 10,0q?6W   ._?5   
   ?? .+?5      ?? $??Фильтр??6   $??24(?5      $??
Montserrat)?5      $??Medium"?5      $??Center=?5      $
??0,10q?5      ???#2329315      ?? 5      
?????? ???#232931$??0,0,0,2q?6D   $??0,0,0,20q?6^   ._?5      ?? .+?5      ?? $??
Montserrat)?6    $??18(?5      $??Medium"?5      ???#232931 ?? Padding$
 20,0q?5      $??🔍 Поиск??5       ?? 5!      $??
Montserrat)?6   $??20(?5"      $??Medium"?5#      ???#232931$??40??5%      $ 
Логин??5&       ?? 	MaxLength$ 20??5'      
?????? $??0q?5)      $??
30,10,30,5q?5*      $??Bottom=?5+      ??5,      ?? *	InputText+ ?? Mode$ TwoWay=?	 ?? UpdateSourceTrigger$	 PropertyChanged=?.??6f   
 ?? 
CaretBrush
 5-      ?? 5.       ?? 
StartPoint$	 0,0&?62    ?? EndPoint$	 1,1&?6C   ??50   &   ?  ? Color$ #D9D9D9??63    ? Offset$ 0Q?6C   ? 51   &   $ #4ECCA3??63   $ 1Q?6C   53      .??54   .   55      56      57      ?? 59      
?????? ???#232931$??0,0,0,2q?6D   ._?5:      ?? .+?5;      ?? $??
Montserrat)?6    $??18(?5<      $??Medium"?5=      ???#232931$
 20,0q?5?      $??Бюджет от??5@      ?? 5A      $??
Montserrat)?6   $??20(?5B      $??Medium"?5C      ???#232931$??40??5E      $ 
Логин??5F      $ 20??5G      
?????? $??0q?5I      $??
30,10,30,5q?5J      $??Bottom=?5K      ??5L      ?? *Budget+$ TwoWay=?$	 PropertyChanged=?.??6c   
 5M      ?? 5N      $	 0,0&?62   $	 1,1&?6C   ??5P   &   ? $ #D9D9D9??63   $ 0Q?6C   ? 5Q   &   $ #4ECCA3??63   $ 1Q?6C   5S      .??5T   .   5U      5V      5W      ?? 5Y         TransparentButton#??[  6   $??40??6@   $??Применить??6L   $??20(?6`   $??20,60,20,20q?6n   ??6?   ?? *ApplyFilterCommand+5Z      5[      5]      