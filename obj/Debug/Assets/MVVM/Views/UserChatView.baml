   M S B A M L   `   `   `  ????L  HFreelancePlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:FreelancePlatform.Assets.MVVM.Views#FreelancePlatform.Assets.MVVM.Views  5      6    0FreelancePlatform.Assets.MVVM.Views.UserChatView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:FreelancePlatform.Assets.MVVM.Views     5      $??0q?5	        ? 	Resources  5
       ?? 
TargetType ?? Property ?? Value??%?   '??       ?? 5   
   " ??6   .?5      ??  ?@J?Opacity$ 0Q?6(   ?? 5       ? ??$ 	0,0,-20,0q?6'   5      5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $??85 ?6   ?? 5      $??1* ?6   ?? 5      $??65 ?6   .+?5   
   ?? $??0??6   ???#393E46._?5      ?  ? ColumnDefinitions 5      ?? 5      $	??100 ?6'   ?? 5      $??1* ?6'   .+?5      A? $??60??6   $??60??6%   $??Center=?61   $??0??6L   $??Center=?6\    J? InputBindings 5      d? 5       d? MouseAction$ 	LeftClicke?6y    ?? Command 6'   ?? *CheckProfileCommand+	 ?? CommandParameter	 6O   ?? *FirstUser.Id+6y   ??5       ?? 5!      
 j? Stretch$
 UniformToFill=?5"   -    ?? ImageSource 5!   %   ?? *FirstUser.PhotoImg+5"   -   5$      ?? 5%      $??1??6   $??Center=?6-   .+?5&      ?? $??
Montserrat)?6    $??24(?5'       $??Medium"?5(       ???#4ECCA3??5*       ?? *CurrentChat.Topic+?? 5+      $??
Montserrat)?6    $??20(?5,       $??Medium"?5-       ???#D9D9D9??5/       ?? *FirstUser.FIO+50      51      52      ?? 54   
   -   5        $??0q?55      
?????? $??1??57         ChatItem#??[  58       %? 
ScrollUnit$ Pixel=?59      ??54      ?? *
Messages+59      ?? 5<   
   $??2??6   ???#393E46._?5>      ??  ?? Orientation$ 
Horizontal=?6   .+?5?      ?? $	??730??6   $??50??5@      $??Center=?5A      $
??Left=?5B      $
??25,0q?5C      $??24(?5D      $??
Montserrat)?5E        UnderlinedTextBox#??[ 5G      
 ? Tag$) #Напишите сообщение??5H      ??5F      ?? *	InputText+ ?? Mode$ TwoWay=? ?? UpdateSourceTrigger$ PropertyChanged=?5H      ?? 5I      $??Right=?6   $??39??65   $??39??6@    5J      d? 5K      $ 	LeftClicke?6'    5L   '   ?? *SendMessageCommand+._?5N      ?? $??../../Images/Send.png??6   ??5O      ?? 5P      " ??6$   .?5Q   "   ??  ?@J?Opacity$ 1Q?6<    ?? Triggers 5R   "   P? 5S   &    P? Property ?@J?IsMouseOver P? Value . . ?5T   *   ??  ?@J?Opacity$	 0.8Q?6D   5U   '   5W      5Y      5Z      5[      5\      5^      5_      