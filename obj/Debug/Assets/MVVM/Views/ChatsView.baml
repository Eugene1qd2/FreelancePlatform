   M S B A M L   `   `   `  ????L  HFreelancePlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:FreelancePlatform.Assets.MVVM.Views#FreelancePlatform.Assets.MVVM.Views  5      3    -FreelancePlatform.Assets.MVVM.Views.ChatsView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:FreelancePlatform.Assets.MVVM.Views     5      $??0q?5	        ? 	Resources  5
       ?? 
TargetType ?? Property ?? Value??%?   '??       ?? 5   
   " ??6   .?5      ??  ?@J?Opacity$ 0Q?6(   ?? 5       ? ??$ 	0,0,-20,0q?6'   5      5      .??5      ? .+?5   
   ?? .??5      ?? $??
20,20,20,0q?69   $??0??6M   ??6   ?? *Chats+??5      ?? 5      .R?5      ??  ?? Padding$ 20q?6!   ???#D9D9D9$	??160??6D   $
??auto??6T   $??10q?6b   $??1q?6n   $	??800??6?    ? Cursor$
 Hand??6?   ??5      ?? 5   "   " ??6(   .?5   &   ??  ? ??
 ???? 6C    ?? Triggers 5   &   P? 5   *    P? Property ?@J?IsMouseOver P? Value . . ?5   .   ??  ? ?? ?	#18D9D9D96K   5   +   5   #   	 J? InputBindings	 5       d? 5!   "   
 d? MouseAction$
 	LeftClicke?6/    ?? Command 5"   +   ??  ?? RelativeSource ??  ?? AncestorType" ?? ?? Path$# DataContext.SelectChatCommand? ?? CommandParameter 5#   +   ?? *ChatId+._?5%      ?  ? ColumnDefinitions 5&   "   ?? 5'   &   $	??200 ?67   ?? 5(   &   $??1* ?67   .+?5*   "   A? $	??150??6*   $	??150??5+   )   $??Center=?5,   )   $??Center=?5-   )   $??0??5.   )   $
 Hand??5/   )   ??50   &   ?? 51   *    j? Stretch$ UniformToFill=?52   -    ?? ImageSource 51   5   ?? *User.PhotoImg+52   -   54   #   ?? 55   "   $??1??6-   $??Center=?6=   .+?57   &   ?? 
?????? $
??Wrap=?59   4   $??Medium"?5:   4   $??
Montserrat)?5;   4   $??30(?5<   4   ???#4ECCA3$
??auto??5>   4   $??Center=?5?   4   $
??Left=?5@   4   $??0,0,0,20q?5A   ,   ??57   0   ?? *Topic+ ?? Mode$ OneWay=? ?? UpdateSourceTrigger$ PropertyChanged=?5A   ,   ?? 5B   &   
?????? $
??Wrap=?5D   4   $??Medium"?5E   4   $??
Montserrat)?5F   4   $??22(?5G   4   ???#d9d9d9$
??auto??5I   4   $??Center=?5J   4   $
??Left=?5K   4   ??5B   0   ?? *
User.FIO+5K   4   5L   #   5M      5N      5O      ??5Q      ?? 5R      .R?5S      ? 5T      5V      5W      5X      5Y      