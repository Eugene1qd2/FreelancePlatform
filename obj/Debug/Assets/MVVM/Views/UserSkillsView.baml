   M S B A M L   `   `   `  ????L  HFreelancePlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:FreelancePlatform.Assets.MVVM.Views#FreelancePlatform.Assets.MVVM.Views  5      8    2FreelancePlatform.Assets.MVVM.Views.UserSkillsView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:FreelancePlatform.Assets.MVVM.Views     5      $??0q?5	        ? 	Resources  5
       ?? 
TargetType ?? Property ?? Value??%?   '??       ?? 5   
   " ??6   .?5      ??  ?@J?Opacity$ 0Q?6(   ?? 5       ? ??$ 	0,0,-20,0q?6'   5      5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $??48 ?6   ?? 5      $??1* ?6   ?? 5      $??60 ?6    ? ColumnDefinitions 5   
   ?? 5      $??1* ?6   ?? 5      $??2 ?6   ?? 5      $??1* ?6   .+?5   
   ?? $??3??6   $??0??6%   $??0??65   ???#393E46._?5      ?? $??Center=?6   $??Center=?5      $??
Montserrat)?5      $??24(?5       ???#D9D9D9$??Medium"?5"      $)??#Добавление навыков??5#      5$      ? 5%   
   $??1??6   $??0??5&      .+?5'      ?? $??35,10q?6   .+?5(      ? $??77??6   $??0,0,0,30q?6#   .+?5)      ?? 
?????? ???#D9D9D9$??0,0,0,3q?6L   $	??350??5*      ._?5+      ?? .+?5,      ?? $??
Montserrat)?6(   $??22(?5-   (   $??Medium"?5.   (   ???#D9D9D9$	??350??50   (    ?? Padding$
 20,0q?51   (   $??Поиск навыков??52   (   ?? 53      $??
Montserrat)?6&   $??26(?54   &   $??Medium"?55   &   ???#D9D9D9$	??350??57   &   $??50??58   &   
 ? Tag$ 
Логин??59   &    ?? 	MaxLength$ 20??5:   &   
?????? $??0q?5<   &   $??
20,10,20,5q?5=   &   $??Bottom=?5>   &   ??5?   &   ?? *SearchSkills+	 ?? Mode$	 TwoWay=?
 ?? UpdateSourceTrigger$
 PropertyChanged=?.??6u    ?? 
CaretBrush 5@   "   ?? 5A   &    ?? 
StartPoint$	 0,0&?6:    ?? EndPoint$	 1,1&?6K   ??5C   .   ?  ? Color$ #D9D9D9??6;    ? Offset$ 0Q?6K   ? 5D   .   $ #4ECCA3??6;   $ 1Q?6K   5F   '   .??5G   6   5H      5I      5J      5K      ?? 5L      $	??590??6   .??5M      ?? ??6#   ?? *Skills+$	 TwoWay=?$
 PropertyChanged=???5N      ?? 5O      .R?5P   "   ??  ?? Padding$
 10,5q?6)    ?? CornerRadius$ 10??68   ???#d9d9d9$??43??6_   $	??345??6n   $
??auto??6}   $??5q?6?   ._?5Q   &   ?  5R   *   ?? 5S   .   $??1* ?6?   ?? 5T   .   $??40 ?6?   .+?5V   *   ??  ?? TextWrapping$
 Wrap=?5W   4   $??Medium"?5X   4   $??
Montserrat)?5Y   4   $??20(?5Z   4   ???#232931$
??auto??5\   4   $??Center=?5]   4   
?????? $??0q?5_   6    ?? 
IsReadOnly . ??5V   2   ?? *Skill+$	 OneWay=?$
 PropertyChanged=?5`   6   ?? 5a   *   $??30??61   $??30??5b   )   $??Right=?5c   )   
?????? $??0q?5e   )   $??Center=?5f   )   $??1??5k   )   ??5g   )   ??  ?? RelativeSource ??  ?? AncestorType" ?? ?? Path$! DataContext.AddSkillCommand???5j   1   ?? *Id+.??5l   .   ?? $ ??..\..\Images\AddButton.png??64   $??30??6X   $??30??6c   ??5m   .   ?? 5n   2   " ??68   .?5o   6   ??  ? ?? 5p   :   ?? 5q   >    ?? 
TargetType" ??6N   .R?5r   B   ?? 
?????? ._?5s   F   ?? $??Center=?6W   $??Center=?6t   5t   C   5u   ?   5w   7    ?? Triggers 5x   6   P? 5y   :    P? Property ?@J?IsMouseOver P? Value . . ?5z   >   ??  ?@J?Opacity$	 0.8Q?6X   5{   ;   P? 5|   :    ? {? .  . ?5}   >   ??  ?@J?Opacity$ 0Q?6X   5~   ;   5?   3   5?   +   5?   '   5?   #   5?      ??5?      ?? 5?      .R?5?   "   ? 5?      5?      5?      5?      5?      ?? 5?   
   $??1??6   $??1??5?      ???#D9D9D9$	??670??5?      ? 5?   
   $??1??6   $??2??5?      .+?5?      ?? $??35,10q?6   .+?5?      ? $??77??6   $??0,0,0,30q?6#   .+?5?      ?? $??
Montserrat)?6    $??30(?5?       $??Medium"?5?       ???#D9D9D9$)??#Добавленные навыки??5?       $??Center=?5?       $??Center=?5?       5?      ?? 5?      $	??590??6   .??5?      ?? ??6#   ?? *
UserSkills+$	 TwoWay=?$
 PropertyChanged=???5?      ?? 5?      .R?5?   "   ?? $
 10,5q?6)   $ 10??68   ???#d9d9d9$??43??6_   $	??345??6n   $
??auto??6}   $??5q?6?   ._?5?   &   ?  5?   *   ?? 5?   .   $??1* ?6?   ?? 5?   .   $??40 ?6?   .+?5?   *   ?? $
 Wrap=?5?   4   $??Medium"?5?   4   $??
Montserrat)?5?   4   $??20(?5?   4   ???#232931$
??auto??5?   4   $??Center=?5?   4   
?????? $??0q?5?   6    . ??5?   2   ?? *Skill+$	 OneWay=?$
 PropertyChanged=?5?   6   ?? 5?   *   $??30??61   $??30??5?   )   $??Right=?5?   )   
?????? $??0q?5?   )   $??Center=?5?   )   $??1??5?   )   ??5?   )   ??  ?? " ??$$ DataContext.RemoveSkillCommand???5?   1   ?? *Id+.??5?   .   ?? $#??..\..\Images\RemoveButton.png??64   $??30??6[   $??30??6f   ??5?   .   ?? 5?   2   " ??68   .?5?   6   ??  ? ?? 5?   :   ?? 5?   >   " ??6N   .R?5?   B   ?? 
?????? ._?5?   F   ?? $??Center=?6W   $??Center=?6t   5?   C   5?   ?   5?   7    5?   6   P? 5?   :    ?@J?IsMouseOver . . ?5?   >   ??  ?@J?Opacity$	 0.8Q?6X   5?   ;   5?   3   5?   +   5?   '   5?   #   5?      ??5?      ?? 5?      .R?5?   "   ? 5?      5?      5?      5?      5?      ?? 5?   
   $??42??6   $??38??5?      $
??Left=?5?      
?????? $??0q?5?      $??Center=?5?      $??2??5?      $??0??5?      $
??30,0q?5?      ??5?      ?? *DeclineChangeSkillsCommand+.??5?      ?? $ ??..\..\Images\ArrowBack.png??6   $??42??68   $??38??6C   ??5?      ?? 5?      " ??6   .?5?      ??  ? ?? 5?      ?? 5?      " ??6.   .R?5?   "   ?? 
?????? ._?5?   &   ?? $??Center=?67   $??Center=?6T   5?   #   5?      5?       5?      P? 5?       ?@J?IsMouseOver . . ?5?      ??  ?@J?Opacity$	 0.8Q?68   5?      5?      5?      5?      5      