   M S B A M L   `   `   `  ????L  HFreelancePlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FreelancePlatformFreelancePlatform  5   	   #    FreelancePlatform.ModalWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:FreelancePlatform     5   	   -   5          ?Name$  modalWindow??5   ?    ? AllowsTransparency .  ? Title$ ModalWindow??6#   $	??240??67    ? WindowStyle$
 None=?6C    ? 
ResizeMode$ NoResize=?6V    ? SizeToContent$ Height=?6l   $??0q?6?    ? WindowStartupLocation$ CenterScreen=?6?   ??5	      ?? 5
   
   .??5      ?  ? Color$ 	#FF393E46??6    ? Offset$ 0Q?6-   ? 5      $ 	#BB393E46??6   $ 1Q?6-   5      ??5      ?? 5   
   	 ?? Triggers	 5      :? 5      
 :? RoutedEvent$
 Window.Loaded??6   .[?5      ?? .??5      ?? .??5      W?  g? Duration$ 0:0:0.4D?6.    ?? TargetProperty$ Opacity?6A    W? From$ 0X?6e   	 W? To$ 1X?6n   W? 5      $ 0:0:0.4D?6.   $	 Top?6A   $ 0X?6a   $	 500X?6j   5      5      5      5      .??5      ? $
??auto??6   $	??Top=?6    ? ColumnDefinitions 5   
   ?? 5       $??1* ?6    ? RowDefinitions 5"   
   ?? 5#      $??25 ?6   ?? 5$      $
??auto ?6   .+?5&   
   ? -   5        $??0??5&      $??2??6   ???#232931 5'      ?? 5(      $??1* ?6#   ?? 5)      $??37 ?6#   .+?5+      ?? -   5        $??28(?5+      ???#D9D9D9$??1??5-      $??Center=?5.      $??Center=?63   
?????? $??37??50      $??44??51       ?? TextAlignment$ Center=?52         OpacityHoverTheme#??[  53      ×6m   54      ?? 55   
   $??1??6   .+?56      ?? $
??auto??6   $
??auto??57      $??16(?58      $??Medium"?59      $??
Montserrat)?5:      $
??Wrap=?5;       ?? Padding$ 10q?5<      ???#d9d9d9$??50??5>      ??56   %   ?? *Text+ ?? ElementName$ modalWindow??5>      ?? 5?      -   5        $??60??5?        WhiteButton#??[ 5@      $??25??5A      $
??Ок??5B      $??16(?5C      $??Medium"?5D      $??
Montserrat)?5E      $??10q?5F      $??Right=?5G      61   5H      5K      5L      